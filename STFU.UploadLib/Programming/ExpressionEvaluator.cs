using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace STFU.UploadLib.Programming
{
	public class ExpressionEvaluator
	{
		private string FilePath { get; set; }
		private string TemplateName { get; set; }
		private IReadOnlyDictionary<string, Variable> Variables { get; set; }

		public ExpressionEvaluator(string filepath, string templatename, IReadOnlyDictionary<string, Variable> variables)
		{
			FilePath = filepath;
			TemplateName = templatename;
			Variables = variables;
		}

		public string Evaluate(string text)
		{
			for (int currentPos = 0; currentPos < text.Length; currentPos++)
			{
				if (text[currentPos] == '<')
				{
					int closingPos = FindClosingPosition(text, currentPos);
					if (closingPos > currentPos)
					{
						var replacement = EvaluateExpression(text.Substring(currentPos + 1, closingPos - currentPos - 1));
						text = $"{text.Substring(0, currentPos)}{replacement}{text.Substring(closingPos + 1)}";
					}
				}
			}

			return text;
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
			else
			{
				switch (identifier.ToLower())
				{
					case "file":
						result = FilePath;
						break;
					case "filename":
						result = Path.GetFileNameWithoutExtension(FilePath);
						break;
					case "fileext":
						result = new FileInfo(FilePath).Extension;
						break;
					case "filenameext":
						result = new FileInfo(FilePath).Name;
						break;
					case "folder":
						result = new FileInfo(FilePath).DirectoryName;
						break;
					case "foldername":
						result = new FileInfo(FilePath).Directory.Name;
						break;
					case "template":
						result = TemplateName;
						break;

					default:
						break;
				}
			}

			return result;
		}

		private string EvaluateFunction(string result, string function, List<string> arguments)
		{
			switch (function.ToLower())
			{
				case "readfile":
					if (arguments.Count == 1 && File.Exists(arguments.First()))
					{
						using (StreamReader reader = new StreamReader(arguments.First()))
						{
							StringBuilder builder = new StringBuilder();
							while (builder.Length < 5000 && reader.Peek() >= 0)
							{
								builder.Append((char)reader.Read());
							}
							result = builder.ToString();
						}
					}
					break;
				default:
					break;
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
