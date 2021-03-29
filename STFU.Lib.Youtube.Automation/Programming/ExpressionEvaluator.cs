using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using STFU.Lib.Youtube.Automation.Interfaces.Model;

namespace STFU.Lib.Youtube.Automation.Programming
{
	public class ExpressionEvaluator
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(ExpressionEvaluator));

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
			LOGGER.Info($"Creating expression evaluator for path: '{filepath}' and template: '{templatename}'");

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

					LOGGER.Info($"Attempting to load assembly: '{trimmed}'");

					try
					{
						var assembly = Assembly.LoadFrom(trimmed);
						Options = Options.AddReferences(assembly);

						LOGGER.Info($"Loaded assembly: '{trimmed}' via 'Assembly.LoadFrom'");
					}
					catch (Exception ex1)
					{
						try
						{
							var netAssembly = Assembly.Load(trimmed);
							Options = Options.AddReferences(netAssembly);

							LOGGER.Info($"Loaded assembly: '{trimmed}' via 'Assembly.Load'");
						}
						catch (Exception ex2)
						{
							try
							{
								var gacAssemblyPath = AssemblyNameResolver.GetAssemblyPath(trimmed);
								var gacAssembly = Assembly.LoadFrom(gacAssemblyPath);
								Options = Options.AddReferences(gacAssembly);

								LOGGER.Info($"Loaded assembly: '{trimmed}' via 'AssemblyNameResolver.GetAssemblyPath'");
							}
							catch (Exception ex3)
							{
								LOGGER.Error($"Couldn't load assembly {trimmed} via 'Assembly.LoadFrom'", ex1);
								LOGGER.Error($"Couldn't load assembly {trimmed} via 'Assembly.Load'", ex2);
								LOGGER.Error($"Couldn't load assembly {trimmed} via 'AssemblyNameResolver.GetAssemblyPath'", ex3);
							}
						}
					}
				}
			}

			CsScript = null;

			foreach (var func in StandardFunctions.GlobalFunctions)
			{
				LOGGER.Debug($"Loading standard function: '{func}'");

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

				LOGGER.Info($"Loading global variable: '{func}'");

				CsScript = await CsScript.ContinueWithAsync(func);
			}

			try
			{
				LOGGER.Info($"Executing preparation script");
				LOGGER.Debug($"Preparation script: {CSharpPreparationScript}");

				CsScript = await CsScript.ContinueWithAsync(CSharpPreparationScript, Options);

				LOGGER.Info($"Executed preparation script");
			}
			catch (CompilationErrorException ex)
			{
				CsScript = await CSharpScript.RunAsync("using System;");
				LOGGER.Error($"Couldn't execute preparation script: {CSharpPreparationScript}", ex);
			}

			LOGGER.Info($"Expression evaluator creation finished");
		}

		public async Task CleanUp()
		{
			try
			{
				LOGGER.Info($"Executing cleanup script");
				LOGGER.Debug($"Cleanup script: {CSharpCleanupScript}");

				CsScript = await CsScript.ContinueWithAsync(CSharpCleanupScript, Options);

				LOGGER.Info($"Executed cleanup script");
			}
			catch (CompilationErrorException ex)
			{
				LOGGER.Error($"Couldn't execute cleanup script: {CSharpCleanupScript}", ex);
			}
		}

		public static bool IsValid(string expression)
		{
			var valid = true;

			if (expression == null)
			{
				expression = string.Empty;
			}

			for (int currentPos = 0; currentPos < expression.Length; currentPos++)
			{
				if (expression[currentPos] == '<')
				{
					ScriptType scriptType = FindScriptType(expression, currentPos);

					// Get if it is a simple script
					if (scriptType == ScriptType.Simple)
					{
						int closingPos = FindClosingPosition(expression, currentPos);
						if (closingPos < 0)
						{
							LOGGER.Error($"Field: '{expression}' is not valid because there is a simple script that hasn't been closed");

							valid = false;
							break;
						}
						else
						{
							currentPos = closingPos + 1;
						}
					}
					else
					{
						currentPos = FindComplexClosingPosition(expression, currentPos);
						if (currentPos < 0)
						{
							LOGGER.Error($"Field: '{expression}' is not valid because there is a c# script that hasn't been closed");

							valid = false;
							break;
						}
					}
				}
			}

			return valid;
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

			LOGGER.Info($"Searching for all field names");

			result.AddRange(FindFieldNames(template.Title));
			result.AddRange(FindFieldNames(template.Description));
			result.AddRange(FindFieldNames(template.Tags));
			result.AddRange(FindFieldNames(template.ThumbnailPath));

			var resultList = result.Distinct().ToList();

			LOGGER.Info($"Finished search, found {resultList.Count} field names");

			return resultList;
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

							LOGGER.Info($"Found field name: '{fieldName}'");

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
			LOGGER.Info($"Starting text evaluation");
			LOGGER.Info($"Text: '{text}'");

			if (text == null)
			{
				text = string.Empty;
			}

			for (int currentPos = 0; currentPos < text.Length; currentPos++)
			{
				if (text[currentPos] == '<')
				{
					ScriptType scriptType = FindScriptType(text, currentPos);

					LOGGER.Info($"Found a script of type: {scriptType}");

					// Get if it is a simple script or a C# one
					if (scriptType == ScriptType.Simple)
					{
						// Old simple script interpreter
						int closingPos = FindClosingPosition(text, currentPos);
						if (closingPos > currentPos)
						{
							var field = text.Substring(currentPos + 1, closingPos - currentPos - 1);

							var replacement = EvaluateField(field);
							text = $"{text.Substring(0, currentPos)}{replacement}{text.Substring(closingPos + 1)}";

							LOGGER.Info($"Replaced placeholder field: '{field}' with value: '{replacement}'");
						}
					}
					else
					{
						int closingPos = FindComplexClosingPosition(text, currentPos);
						if (closingPos > currentPos)
						{
							string wholeText = text.Substring(currentPos, closingPos + 3 - currentPos);
							string script = wholeText.Substring(3, closingPos - currentPos - 3);

							string result = string.Empty;

							try
							{
								LOGGER.Info($"Running found script: '{script}'");

								var state = CsScript.ContinueWithAsync(script);

								if (state.Status != TaskStatus.Faulted)
								{
									state.Wait();

									result = state.Result.ReturnValue?.ToString() ?? string.Empty;

									LOGGER.Info($"Script returned result: '{result}'");
								}
							}
							catch (CompilationErrorException ex)
							{
								LOGGER.Error($"Couldn't execute script: {script}", ex);
							}

							string before = text.Substring(0, currentPos);
							string after = text.Substring(closingPos + 3);

							text = $"{before}{result}{after}";
						}
					}
				}
			}

			LOGGER.Info($"Final evaluated text: '{text.Replace("<", "").Replace(">", "")}'");

			return text.Replace("<", "").Replace(">", "");
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
