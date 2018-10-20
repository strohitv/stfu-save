using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using MoonSharp.Interpreter;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using mss = MoonSharp.Interpreter;

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

		private ScriptState<object> CsScript { get; set; }

		private IList<IPlannedVideo> PlannedVideos { get; set; } = new List<IPlannedVideo>();

		public ExpressionEvaluator(string filepath, string templatename, IList<IPlannedVideo> plannedVideos, string csharpPreparationScript, string csharpCleanupScript)
		{
			FilePath = filepath;
			TemplateName = templatename;
			PlannedVideos = plannedVideos;

			CSharpPreparationScript = csharpPreparationScript;
			CSharpCleanupScript = csharpCleanupScript;

			CreateExpressionEvaluator().Wait();
		}

		private async Task CreateExpressionEvaluator()
		{
			foreach (var var in GlobalVariables)
			{
				string func = $"const string {var.Key} = @\"{var.Value(FilePath, TemplateName)}\";";

				if (CsScript == null)
				{
					CsScript = await CSharpScript.RunAsync(func);
				}
				else
				{
					CsScript = await CsScript.ContinueWithAsync(func);
				}
			}

			try
			{
				CsScript = await CsScript.ContinueWithAsync(CSharpPreparationScript);
			}
			catch (CompilationErrorException ex)
			{
				CsScript = await CSharpScript.RunAsync("using System;");

				if (!Directory.Exists("errors"))
				{
					Directory.CreateDirectory("errors");
				}

				using (StreamWriter writer = new StreamWriter($"errors/{DateTime.Now.ToString("yyyy-MM-dd")}.txt", true))
				{
					writer.WriteLine($"Exception aufgetreten. Zeitpunkt: {DateTime.Now.ToString()}");
					writer.WriteLine();
					WriteException(ex, writer, CSharpPreparationScript);

					writer.WriteLine();
					writer.WriteLine("=======================");
					writer.WriteLine();
					writer.WriteLine();
				}
			}
		}

		public async Task CleanUp()
		{
			try
			{
				CsScript = await CsScript.ContinueWithAsync(CSharpCleanupScript);
			}
			catch (CompilationErrorException ex)
			{
				if (!Directory.Exists("errors"))
				{
					Directory.CreateDirectory("errors");
				}

				using (StreamWriter writer = new StreamWriter($"errors/{DateTime.Now.ToString("yyyy-MM-dd")}.txt", true))
				{
					writer.WriteLine($"Exception aufgetreten. Zeitpunkt: {DateTime.Now.ToString()}");
					writer.WriteLine();
					WriteException(ex, writer, CSharpPreparationScript);

					writer.WriteLine();
					writer.WriteLine("=======================");
					writer.WriteLine();
					writer.WriteLine();
				}
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
					if (scriptType.HasFlag(ScriptType.Simple))
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
					if (scriptType.HasFlag(ScriptType.Simple))
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

						if (script.StartsWith("c", StringComparison.InvariantCultureIgnoreCase)
							|| script.StartsWith("l", StringComparison.InvariantCultureIgnoreCase))
						{
							script = script.Remove(0, 1);
						}

						string result = string.Empty;

						if (scriptType.HasFlag(ScriptType.CSharp))
						{
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
								if (!Directory.Exists("errors"))
								{
									Directory.CreateDirectory("errors");
								}

								using (StreamWriter writer = new StreamWriter($"errors/{DateTime.Now.ToString("yyyy-MM-dd")}.txt", true))
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
						}

						if (scriptType.HasFlag(ScriptType.LUA) && result == string.Empty)
						{
							try
							{
								DynValue res = mss.Script.RunString(script);
								result = res.ToPrintString();
							}
							catch (InterpreterException ex)
							{
								// TODO: Logging
								Console.WriteLine(ex);
							}
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

			if (isComplex && text.ToLower()[currentPos + 3] == 'c')
			{
				type = ScriptType.CSharp;
			}
			else if (isComplex && text.ToLower()[currentPos + 3] == 'l')
			{
				type = ScriptType.LUA;
			}
			else if (isComplex)
			{
				type = ScriptType.CSharp | ScriptType.LUA;
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

			expression = expression.Trim();
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
