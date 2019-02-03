using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace STFU.Executable.AutoUploader.WPF.Helpers
{
    public static class TextToInline
    {
        private const char COMMENT_CHAR = '$';
        private const char HEADING_CHAR = '#';
        private const char EQUALS_CHAR = '=';

        struct TextStyle
        {
            public static TextStyle Default
            {
                get { return new TextStyle(); }
            }

            public static TextStyle Heading
            {
                get { return new TextStyle() { Bold = true }; }
            }

            public static TextStyle SourceCode
            {
                get { return new TextStyle() { Code = true }; }
            }

            private static readonly FontFamily defaultFont = new FontFamily("Segoe UI");
            private static readonly FontFamily codeFont = new FontFamily("Consolas");

            public static FontFamily DefaultFont { get { return defaultFont; } }
            public static FontFamily CodeFont { get { return codeFont; } }

            public bool Bold;
            public bool Italic;
            public bool Code;
        }

        public static IEnumerable<Inline> LoadFile(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentException("file needs to be a valid filename", nameof(file));
            Uri uri = new Uri(file, UriKind.RelativeOrAbsolute);
            List<Inline> data = new List<Inline>();
            using (StreamReader reader = new StreamReader(Application.GetResourceStream(uri).Stream))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Length == 0)
                    {
                        data.Add(new LineBreak());
                        continue;
                    }

                    switch (line[0])
                    {
                        case COMMENT_CHAR: break;
                        case HEADING_CHAR:
                            data.AddRange(CreateHeading(line));
                            break;
                        default:
                            data.AddRange(CreateLine(line));
                            break;
                    }
                }
            if (data.Count >= 0 && data[data.Count - 1] is LineBreak)
                data.RemoveAt(data.Count - 1);
            return data;
        }

        private static IEnumerable<Inline> CreateLine(string line)
        {
            int equalsLocation = line.IndexOf(EQUALS_CHAR);
            if (equalsLocation >= 0)
            {
                if (equalsLocation > 0)
                    equalsLocation--;
                string code = line.Substring(0, equalsLocation);
                string description = line.Substring(equalsLocation);

                return new List<Inline>
                {
                    CreateRun(code, TextStyle.SourceCode),
                    CreateRun(description, TextStyle.Default),
                    new LineBreak()
                };
            }

            return new List<Inline>
            {
                CreateRun(line, TextStyle.Default),
                new LineBreak()
            };
        }

        private static IEnumerable<Inline> CreateHeading(string line)
        {
            if (line.Length == 0)
                return new List<Inline>() { new LineBreak() };
            if (line[0] == HEADING_CHAR)
                line = line.Substring(1).TrimStart();
            List<Inline> inlines = new List<Inline>
            {
                CreateRun(line, TextStyle.Heading),
                new LineBreak()
            };
            return inlines;
        }

        private static Inline CreateRun(string line, TextStyle heading)
        {
            int index = line.IndexOf(COMMENT_CHAR);
            if (index >= 0)
                line = line.Substring(0, index).TrimEnd();

            Run run = new Run(line)
            {
                FontWeight = heading.Bold ? FontWeights.Bold : FontWeights.Regular,
                FontStyle = heading.Italic ? FontStyles.Italic : FontStyles.Normal,
                FontFamily = heading.Code ? TextStyle.CodeFont : TextStyle.DefaultFont
            };
            return run;
        }
    }
}
