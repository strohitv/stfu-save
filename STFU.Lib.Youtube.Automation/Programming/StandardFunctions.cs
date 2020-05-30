namespace STFU.Lib.Youtube.Automation.Programming
{
	public static class StandardFunctions
	{
		
		public static string[] GlobalFunctions =>
			new[] {
@"/// <summary>
/// Der Code in diesem Textfeld kann nicht geändert werden.
/// 
/// Der folgende Code wird jeweils bei der Initalisierung eines Uploas als erstes ausgeführt.
/// Dadurch stehen die usings und Funktionen sowohl im Upload-Vorbereitungs- und -Nachbereitungsskript,
/// als auch in den Textfeldern Titel, Beschreibung, Tags und Thumbnail-Pfad zur Verfügung.
/// </summary>


using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;",

@"
/// <summary>
/// Liest eine Datei ein
/// </summary>
/// <param name=""path"">Der Dateipfad der einzulesenden Datei</param>
string ReadFile(string path)
{
	string result = string.Empty;
	if (File.Exists(path))
	{
		using (StreamReader reader = new StreamReader(path))
		{
			result = reader.ReadToEnd();
		}
	}

	return result;
}",

@"
/// <summary>
/// Findet eine Zahl im übergebenen Text
/// </summary>
/// <param name=""input"">Der Text, in dem die Zahl gesucht werden soll</param>
/// <param name=""numberToFind"">Die wie-vielte Zahl soll gefunden werden? Index startet bei 1, nicht bei 0!</param>
string FindNumber(string input, int numberToFind = 1)
{
	numberToFind--;

	var decimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

	var numbers = new List<string>();
	bool decimalSeparatorAppeared = false;
	StringBuilder currentNumber = new StringBuilder();
	foreach (var letter in input)
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

	if (currentNumber.Length > 0)
	{
		numbers.Add(currentNumber.ToString());
	}

	string result = string.Empty;
	if (numbers.Count > numberToFind)
	{
		result = numbers[numberToFind];
	}

	return result;
}",

@"
/// <summary>
/// Entfernt alle überflüssigen führenden 0 am Anfang des Strings.
/// </summary>
/// <param name=""input"">Die Zahl (als string), deren führenden Nullen entfernt werden sollen.</param>
string RemoveLeadingZeros(string input)
{
	int removecount = 0;
	for (int i = 0; i < input.Length; i++)
	{
		if (input[i] == '0')
		{
			removecount++;
		}
		else
		{
			break;
		}
	}

	string result = input.Substring(removecount);

	if (result.Length == 0 && removecount > 0)
	{
		result = ""0"";
	}

	return result;
}"};
	}
}
