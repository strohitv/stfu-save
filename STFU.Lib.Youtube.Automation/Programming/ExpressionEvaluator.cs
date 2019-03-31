using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using STFU.Lib.Youtube.Automation.Interfaces.Model;

namespace STFU.Lib.Youtube.Automation.Programming
{
	public class ExpressionEvaluator
	{
		private IReadOnlyDictionary<string, Func<string, string, string>> GlobalVariables =>
			new ReadOnlyDictionary<string, Func<string, string, string>>(new Dictionary<string, Func<string, string, string>>
		{
			{ "file", (path, template) => path },
			{ "filename", (path, template) => Path.GetFileNameWithoutExtension(path) },
			{ "fileext", (path, template) => new FileInfo(path).Extension },
			{ "filenameext", (path, template) => new FileInfo(path).Name },
			{ "folder", (path, template) => new FileInfo(path).DirectoryName },
			{ "foldername", (path, template) => new FileInfo(path).Directory.Name },
			{ "template", (path, template) => template }
		});

		private string FilePath { get; set; }
		private string TemplateName { get; set; }
		private string CSharpPreparationScript { get; set; }
		private string CSharpCleanupScript { get; set; }
		private string ReferencedAssembliesText { get; set; }

		private ScriptState<object> CsScript { get; set; }
		private ScriptOptions Options { get; set; }

		private IList<IPlannedVideo> PlannedVideos { get; set; } = new List<IPlannedVideo>();

		public ExpressionEvaluator(string filepath, string templatename, IList<IPlannedVideo> plannedVideos, string csharpPreparationScript, string csharpCleanupScript, string referencedAssembliesText)
		{
			FilePath = filepath;
			TemplateName = templatename;
			PlannedVideos = plannedVideos;

			CSharpPreparationScript = csharpPreparationScript;
			CSharpCleanupScript = csharpCleanupScript;
			ReferencedAssembliesText = referencedAssembliesText;

			CreateExpressionEvaluator().Wait();
		}

		private async Task CreateExpressionEvaluator()
		{
			Options = ScriptOptions.Default;

			var assemblyLines = ReferencedAssembliesText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			foreach (var line in assemblyLines)
			{
				if (!line.StartsWith("//") && !string.IsNullOrWhiteSpace(line))
				{
					var trimmed = line.Trim();

					try
					{
						var assembly = Assembly.LoadFrom(trimmed);
						Options = Options.AddReferences(assembly);
					}
					catch (Exception ex1)
					{
						try
						{
							var netAssembly = Assembly.Load(trimmed);
							Options = Options.AddReferences(netAssembly);
						}
						catch (Exception ex2)
						{
							try
							{
								var gacAssemblyPath = AssemblyNameResolver.GetAssemblyPath(trimmed);
								var gacAssembly = Assembly.LoadFrom(gacAssemblyPath);
								Options = Options.AddReferences(gacAssembly);
							}
							catch (Exception ex3)
							{
								LogException(ex1, $"Die Referenz {trimmed} sollte geladen werden.");
								LogException(ex2, $"Die Referenz {trimmed} sollte geladen werden.");
								LogException(ex3, $"Die Referenz {trimmed} sollte geladen werden.");
							}
						}
					}
				}
			}

			foreach (var func in StandardFunctions.GlobalFunctions)
			{
				if (CsScript == null)
				{
					CsScript = await CSharpScript.RunAsync(func);
				}
				else
				{
					CsScript = await CsScript.ContinueWithAsync(func);
				}
			}

			foreach (var var in GlobalVariables)
			{
				string func = $"const string {var.Key} = @\"{var.Value(FilePath, TemplateName)}\";";
				CsScript = await CsScript.ContinueWithAsync(func);
			}

			try
			{
				CsScript = await CsScript.ContinueWithAsync(CSharpPreparationScript, Options);
			}
			catch (CompilationErrorException ex)
			{
				CsScript = await CSharpScript.RunAsync("using System;");
				LogException(ex, CSharpPreparationScript);
			}
		}

		private void LogException(Exception ex, string script)
		{
			if (!Directory.Exists("errors"))
			{
				Directory.CreateDirectory("errors");
			}

			if (!Directory.Exists(@"errors\csharp"))
			{
				Directory.CreateDirectory(@"errors\csharp");
			}

			using (StreamWriter writer = new StreamWriter($@"errors\csharp\{DateTime.Now.ToString("yyyy-MM-dd")}.txt", true))
			{
				writer.WriteLine($"Exception aufgetreten. Zeitpunkt: {DateTime.Now.ToString()}");
				writer.WriteLine();
				WriteException(ex, writer, script);

				writer.WriteLine();
				writer.WriteLine("=======================");
				writer.WriteLine();
				writer.WriteLine();
			}
		}

		public async Task CleanUp()
		{
			try
			{
				CsScript = await CsScript.ContinueWithAsync(CSharpCleanupScript, Options);
			}
			catch (CompilationErrorException ex)
			{
				LogException(ex, CSharpCleanupScript);
			}

			CsScript = null;
		}

		public static bool IsFieldOnlyInDescription(string fieldname, ITemplate template)
		{
			var field = fieldname.ToLower();

			return FindFieldNames(template.Description).Contains(field)
				&& !FindFieldNames(template.Title).Contains(field)
				&& !FindFieldNames(template.Tags).Contains(field)
				&& !FindFieldNames(template.ThumbnailPath).Contains(field);
		}

		public static IList<string> GetFieldNames(ITemplate template)
		{
			List<string> result = new List<string>();

			result.AddRange(FindFieldNames(template.Title));
			result.AddRange(FindFieldNames(template.Description));
			result.AddRange(FindFieldNames(template.Tags));
			result.AddRange(FindFieldNames(template.ThumbnailPath));

			return result.Distinct().ToList();
		}

		private static IList<string> FindFieldNames(string text)
		{
			IList<string> result = new List<string>();

			if (text == null)
			{
				text = string.Empty;
			}

			for (int currentPos = 0; currentPos < text.Length; currentPos++)
			{
				if (text[currentPos] == '<')
				{
					ScriptType scriptType = FindScriptType(text, currentPos);

					// Get if it is a simple script
					if (scriptType == ScriptType.Simple)
					{
						int closingPos = FindClosingPosition(text, currentPos);
						if (closingPos > currentPos)
						{
							var fieldName = text.Substring(currentPos + 1, closingPos - currentPos - 1).ToLower().Trim();
							result.Add(fieldName);
						}
					}
					else
					{
						currentPos = FindComplexClosingPosition(text, currentPos);
					}
				}
			}

			return result;
		}

		public string Evaluate(string text)
		{
			if (text == null)
			{
				text = string.Empty;
			}

			for (int currentPos = 0; currentPos < text.Length; currentPos++)
			{
				if (text[currentPos] == '<')
				{
					ScriptType scriptType = FindScriptType(text, currentPos);

					// Get if it is a simple script, a C# one or a LUA one
					if (scriptType == ScriptType.Simple)
					{
						// Old simple script interpreter
						int closingPos = FindClosingPosition(text, currentPos);
						if (closingPos > currentPos)
						{
							var replacement = EvaluateField(text.Substring(currentPos + 1, closingPos - currentPos - 1));
							text = $"{text.Substring(0, currentPos)}{replacement}{text.Substring(closingPos + 1)}";
						}
					}
					else
					{
						int closingPos = FindComplexClosingPosition(text, currentPos);

						string wholeText = text.Substring(currentPos, closingPos + 3 - currentPos);
						string script = wholeText.Substring(3, closingPos - currentPos - 3);

						string result = string.Empty;

						try
						{
							var state = CsScript.ContinueWithAsync(script);

							if (state.Status != TaskStatus.Faulted)
							{
								state.Wait();

								result = state.Result.ReturnValue?.ToString() ?? string.Empty;
							}
						}
						catch (CompilationErrorException ex)
						{
							LogException(ex, script);
						}

						string before = text.Substring(0, currentPos);
						string after = text.Substring(closingPos + 3);

						text = $"{before}{result}{after}";
					}

				}
			}

			return text;
		}

		private void WriteException(Exception ex, StreamWriter writer, string script)
		{
			WriteException(ex, writer, script, "");
		}

		private void WriteException(Exception ex, StreamWriter writer, string script, string prefix)
		{
			writer.WriteLine($"{prefix}Fehlermeldung: {ex.Message}");
			writer.WriteLine($"{prefix}Source: {ex.Source}");
			writer.WriteLine($"{prefix}Stacktrace: {ex.StackTrace}");
			writer.WriteLine($"{prefix}TargetSite: {ex.TargetSite}");
			writer.WriteLine($"{prefix}Hilfelink: {ex.HelpLink}");

			if (script != null)
			{
				writer.WriteLine($"{prefix}Auszuführendes Script: {script}");
			}

			if (ex.InnerException != null)
			{
				WriteException(ex.InnerException, writer, null, "        ");
			}
		}

		private static ScriptType FindScriptType(string text, int currentPos)
		{
			ScriptType type = ScriptType.Simple;

			bool isComplex = text.Length > currentPos + 3
				&& text[currentPos + 1] == '<'
				&& text[currentPos + 2] == '<';

			if (isComplex)
			{
				type = ScriptType.CSharp;
			}

			return type;
		}

		private static int FindComplexClosingPosition(string text, int currentPos)
		{
			return text.IndexOf(">>>", currentPos);
		}

		private string EvaluateField(string expression)
		{
			string result = string.Empty;

			expression = expression.Trim().ToLower();
			var fileName = Path.GetFileNameWithoutExtension(FilePath).ToLower();
			var fileNameExt = Path.GetFileName(FilePath).ToLower();

			var plannedVideo = PlannedVideos.FirstOrDefault(v => v.Name.ToLower() == fileName || v.Name.ToLower() == fileNameExt);

			if (plannedVideo != null && plannedVideo.Fields.ContainsKey(expression))
			{
				result = plannedVideo.Fields[expression];
			}

			return result;
		}

		private static int FindClosingPosition(string text, int start)
		{
			int openedCount = 0;
			int closingPosition = -1;

			for (int current = start + 1; current < text.Length; current++)
			{
				if (text[current] == '>' && openedCount == 0)
				{
					closingPosition = current;
					break;
				}
				else if (text[current] == '<')
				{
					openedCount++;
				}
				else if (text[current] == '>')
				{
					openedCount--;
				}
			}

			return closingPosition;
		}
	}
}
