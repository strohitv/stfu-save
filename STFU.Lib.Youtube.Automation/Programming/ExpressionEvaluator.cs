using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
		private string FilePath { get; set; }
		private string TemplateName { get; set; }
		private string CSharpPreparationScript { get; set; }
		private string CSharpCleanupScript { get; set; }
		private IReadOnlyDictionary<string, IVariable> Variables { get; set; }

		private ScriptState<object> CsScript { get; set; }

		public ExpressionEvaluator(string filepath, string templatename, IReadOnlyDictionary<string, IVariable> variables, string csharpPreparationScript, string csharpCleanupScript)
		{
			FilePath = filepath;
			TemplateName = templatename;
			Variables = variables;

			CSharpPreparationScript = csharpPreparationScript;
			CSharpCleanupScript = csharpCleanupScript;

			CreateExpressionEvaluator().Wait();
		}

		private async Task CreateExpressionEvaluator()
		{
			foreach (var var in Variable.GlobalVariables)
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
							var replacement = EvaluateExpression(text.Substring(currentPos + 1, closingPos - currentPos - 1));
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

		private ScriptType FindScriptType(string text, int currentPos)
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

		private int FindComplexClosingPosition(string text, int currentPos)
		{
			return text.IndexOf(">>>", currentPos);
		}

		private string EvaluateExpression(string expression)
		{
			expression = expression.Trim();

			// Innere Expressions auswerten
			for (int currentPos = 0; currentPos < expression.Length; currentPos++)
			{
				if (expression[currentPos] == '<')
				{
					int closingPos = FindClosingPosition(expression, currentPos);
					if (closingPos > currentPos)
					{
						var replacement = EvaluateExpression(expression.Substring(currentPos + 1, closingPos - currentPos - 1));
						expression = $"{expression.Substring(0, currentPos)}{replacement}{expression.Substring(closingPos + 1)}";
					}
				}
			}

			string result = string.Empty;
			StringBuilder currentExpression = new StringBuilder();
			for (int currentPos = 0; currentPos < expression.Length; currentPos++)
			{
				char currentCharacter = expression[currentPos];

				if (currentCharacter == '(')
				{
					// Funktion
					List<string> arguments = new List<string>();
					string currentArgument = string.Empty;
					for (int functionEndPos = currentPos + 1; functionEndPos < expression.Length; functionEndPos++)
					{
						char currentChar = expression[functionEndPos];

						if (currentChar == ')')
						{
							arguments.Add(currentArgument);

							currentPos = functionEndPos;
							result = EvaluateFunction(result, currentExpression.ToString(), arguments);
							currentExpression = new StringBuilder();
							break;
						}
						else if (currentChar == ',')
						{
							currentArgument += currentChar;
							arguments.Add(currentArgument);
							currentArgument = string.Empty;
						}
						else
						{
							currentArgument += currentChar;
						}
					}
				}
				else if (currentCharacter == '.')
				{
					if (currentExpression.Length > 0)
					{
						// Identifier => auswerten
						result = EvaluateIdentifier(currentExpression.ToString());
						currentExpression = new StringBuilder();
					}
				}
				else
				{
					currentExpression.Append(currentCharacter);
				}
			}

			if (currentExpression.Length > 0)
			{
				// Identifier => auswerten
				result = EvaluateIdentifier(currentExpression.ToString());
			}

			return result;
		}

		private string EvaluateIdentifier(string identifier)
		{
			string result = identifier;

			if (Variables.ContainsKey(identifier.ToLower()))
			{
				result = Evaluate(Variables[identifier.ToLower()].Content);
			}
			else if (Variable.GlobalVariables.ContainsKey(identifier.ToLower()))
			{
				result = Variable.GlobalVariables[identifier.ToLower()](FilePath, TemplateName);
			}

			return result;
		}

		private string EvaluateFunction(string result, string function, List<string> arguments)
		{
			switch (function.ToLower())
			{
				case "readfile":
					result = ReadFile(result, arguments);
					break;
				case "findnumber":
					result = FindNumber(result, arguments);
					break;
				case "substring":
					result = FindSubstring(result, arguments);
					break;
				case "removeleadingzeros":
					result = RemoveLeadingZeros(result);
					break;
				case "getpassage":
					result = GetPassage(result, arguments);
					break;
				default:
					break;
			}

			return result;
		}

		private static string GetPassage(string result, List<string> arguments)
		{
			if (arguments.Count > 0)
			{
				string passageName = arguments.First();

				var splits = result.Split(new[] { $"<{passageName}>" }, StringSplitOptions.None);
				if (splits.Length > 1)
				{
					result = splits[1];
				}
			}

			return result;
		}

		private static string RemoveLeadingZeros(string result)
		{
			int removecount = 0;
			for (int i = 0; i < result.Length; i++)
			{
				if (result[i] == '0')
				{
					removecount++;
				}
				else
				{
					break;
				}
			}
			result = result.Substring(removecount);

			if (result.Length == 0 && removecount > 0)
			{
				result = "0";
			}

			return result;
		}

		private static string FindSubstring(string result, List<string> arguments)
		{
			int start = 0;
			int end = 0;
			if (arguments.Count == 1 && int.TryParse(arguments.First(), out end) && end >= 0)
			{
				// kein <= weil result.substring(0, end) == result, wenn end == result.length
				// => unnötige Operation
				if (end < result.Length)
				{
					result = result.Substring(0, end);
				}
			}
			else if (arguments.Count > 1
				&& int.TryParse(arguments[0], out start)
				&& int.TryParse(arguments[1], out end)
				&& start >= 0
				&& end >= start)
			{
				if (start <= result.Length - 1)
				{
					if (start + end < result.Length)
					{
						result = result.Substring(start, end);
					}
					else
					{
						result = result.Substring(start, result.Length - start);
					}
				}
				else
				{
					result = string.Empty;
				}
			}

			return result;
		}

		private static string FindNumber(string result, List<string> arguments)
		{
			int numberToFind = 0;
			if (arguments.Count > 0)
			{
				int.TryParse(arguments.First(), out numberToFind);
				numberToFind--;
			}

			var decimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

			var numbers = new List<string>();
			bool decimalSeparatorAppeared = false;
			StringBuilder currentNumber = new StringBuilder();
			foreach (var letter in result)
			{
				if (char.IsDigit(letter))
				{
					currentNumber.Append(letter);
				}
				else if (!decimalSeparatorAppeared && letter == decimalSeparator)
				{
					decimalSeparatorAppeared = true;
					currentNumber.Append(letter);
				}
				else if (currentNumber.Length > 0)
				{
					numbers.Add(currentNumber.ToString());
					decimalSeparatorAppeared = false;
					currentNumber = new StringBuilder();
				}
			}

			result = string.Empty;
			if (numbers.Count >= numberToFind + 1)
			{
				result = numbers[numberToFind];
			}

			return result;
		}

		private static string ReadFile(string result, List<string> arguments)
		{
			if (arguments.Count > 0 && File.Exists(arguments.First()))
			{
				using (StreamReader reader = new StreamReader(arguments.First()))
				{
					// Keine Begrenzung auf 5k Zeichen, da er ja möglicherweise eine Passage lesen will.
					result = reader.ReadToEnd();
				}
			}

			return result;
		}

		private int FindClosingPosition(string text, int start)
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
