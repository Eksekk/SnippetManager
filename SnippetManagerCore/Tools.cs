using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SnippetManagerCore
{
    public static class Tools
    {
        public static string ExtractColorComponents(Color color)
        {
            // for RGB (111, 222, 225) returns 111;222;225
            return string.Join(";", color.R, color.G, color.B);
        }

        public static string UseColor(string tekst, Color kolor)
        {
            // wrap in ansi escape sequence
            return $"\u001b[38;2;{ExtractColorComponents(kolor)}m{tekst}\u001b[0m";
        }

        public static string UsePropertyColor(string tekst) => UseColor(tekst, Color.DarkSeaGreen);

        public static string UsePromptTextColor(string tekst) => UseColor(tekst, Color.DodgerBlue);

        public static string UseErrorTextColor(string tekst) => UseColor(tekst, Color.Red);

        public static string UseSuccessTextColor(string tekst) => UseColor(tekst, Color.LimeGreen);

        public static string UsePreOperationTextColor(string tekst) => UseColor(tekst, Color.DarkOrange);
        public static string UsePostOperationTextColor(string tekst) => UseColor(tekst, Color.Orchid);
        public static string UseResultLineTextColor(string tekst) => UseColor(tekst, Color.DarkTurquoise);
        public static string UseGenericMethodNameTextColor(string tekst) => UseColor(tekst, Color.Red);

        public static string GenericClassObjectInfoToString(object obj, Color classNameColor, bool useNewlines = false)
        {
            Type type = obj.GetType();
            // TODO: handle superclasses?
            var props = type.GetProperties();
            string[] propStrings = new string[props.Length];
            int i = 0;
            foreach (PropertyInfo prop in props)
            {
                string val = prop.GetValue(obj)?.ToString() ?? "null";
                // hack to support indented subclasses
                if (val.Contains('\n')) // subclass
                {
                    val = val.Replace("\n", "\n\t"); // support indented subclasses
                    propStrings[i++] = $"{val}"; // no property name - it would be redundant
                }
                else
                {
                    propStrings[i++] = $"{UsePropertyColor(prop.Name)}: {val}";
                }
            }
            if (useNewlines)
            {
                for (int j = 0; j < propStrings.Length; j++)
                {
                    propStrings[j] = $"\t{propStrings[j]}";
                }
            }
            string propString = string.Join(useNewlines ? "\n" : ", ", propStrings);
            if (useNewlines)
            {
                return $"{UseColor(type.Name, classNameColor)}:\n{propString}";
            }
            else
            {
                return $"{UseColor(type.Name, classNameColor)} {{{propString}}}";
            }
        }

        // a generic method which takes an enum type as argument and outputs string with "command menu" for the enum

        public static string GetMenuForActionEnum<T>(Dictionary<T, string>? descriptions = null) where T : Enum
        {
            Array values = Enum.GetValues(typeof(T));
            string[] names = Enum.GetNames(typeof(T));
            int namesIndex = 0;
            List<string> lines = new();
            foreach (int value in values)
            {
                T val = (T)Enum.Parse(typeof(T), value.ToString(), true);
                Debug.Assert(Enum.IsDefined(typeof(T), val), "Enum value is invalid");
                string desc = descriptions is null || !descriptions.ContainsKey(val) ? names[namesIndex++].ToLower().Replace("_", " ") : descriptions[val];
                lines.Add($"{value}. {desc}");
            }
            return string.Join("\n", lines);
        }

        public static string StripAnsiColorEscapeSequences(this string text)
        {
            // I don't want to understand that regex, but it works
            return Regex.Replace(text, @"\x1b\[[0-9;]*m", "");
        }
        public static string[] ConvertTextWithHeadersIntoTable(string[] headers, object[][] rows)
        {
            int[] MaxLengths = new int[headers.Length];
            for (int col = 0; col < headers.Length; ++col)
            {
                int max = headers[col].Length;
                for (int row = 0; row < rows.Length; ++row)
                {
                    max = Math.Max(max, rows[row][col].ToString().StripAnsiColorEscapeSequences().Length);
                }
                MaxLengths[col] = max;
            }
            string[] res = new string[rows.Length + 1]; // + 1 for headers
            Func<object[], string> processLine = (object[] line) =>
            {
                StringBuilder sb = new StringBuilder();
                for (int col = 0; col < headers.Length; ++col)
                {
                    sb.Append(line[col].ToString().StripAnsiColorEscapeSequences().PadRight(MaxLengths[col], ' '));
                    if (col != headers.Length - 1)
                    {
                        sb.Append(" | ");
                    }
                }
                return sb.ToString();
            };
            res[0] = processLine(headers);
            for (int row = 0; row < rows.Length; ++row)
            {
                Debug.Assert(rows[row].Length == headers.Length, "Row length mismatch");
                res[row + 1] = processLine(rows[row]);
            }
            return res;
        }

        public static string[] ConvertGenericObjectPropertiesToTable<T>(T[] objects)
        {
            Type t = objects.GetType().GetElementType();
            PropertyInfo[] props = t.GetProperties();
            object[,] data = new object[objects.Length, props.Length]; // contiguous 2d array
            var propNames = props.Select(prop => prop.Name);
            int objIndex = 0;
            foreach (T obj in objects)
            {
                int propIndex = 0;
                foreach (var prop in props)
                {
                    data[objIndex, propIndex++] = prop.GetValue(obj);
                }
                ++objIndex;
            }
            return ConvertTextWithHeadersIntoTable(propNames.ToArray(), TwoDimensionalArrayToJaggedArray(data));
        }

        public static string[] ConvertGenericObjectPropertiesToTable<T>(T obj) => ConvertGenericObjectPropertiesToTable(new T[] { obj });

        public static T[][] TwoDimensionalArrayToJaggedArray<T>(T[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            T[][] data = new T[rows][];
            for (int row = 0; row < rows; ++row)
            {
                T[] dataRow = new T[cols];
                for (int col = 0; col < cols; ++col)
                {
                    dataRow[col] = array[row, col];
                }
                data[row] = dataRow;
            }
            return data;
        }

        // a setter for property which can be set only once
        public static void SingleTimeSetter<T>(ref T field, T value, string? what = null)
        {
            if (field is not null)
            {
                throw new InvalidOperationException($"{what ?? typeof(T).Name} can be set only once");
            }
            field = value;
        }

        // this method is commented out, because I don't want to take time to force visual studio to correctly add Windows Forms library to this project
        //         public static void AppendText(this RichTextBox box, string text, Color color)
        //         {
        //             box.SelectionStart = box.TextLength;
        //             box.AppendText(text);
        //             box.SelectionLength = text.Length;
        //             box.SelectionColor = color;
        //         }

        public static string[] SplitIntoCommaDelimitedTrimmedStrings(string text)
        {
            return text.Split(',').Select(s => s.Trim()).ToArray();
        }

        public static string StringizeSingleParameter<T>(T? val)
        {
            if (val is null)
            {
                return "null";
            }
            else if (val is not string && val.GetType().GetInterfaces().Contains(typeof(IEnumerable))) // special check for strings, because they are IEnumerable but we don't want to treat them as collections
            {
                List<string> strings = new();
                foreach (object o in (IEnumerable)val)
                {
                    strings.Add(StringizeSingleParameter(o));
                }
                return strings.Count > 0 ? $"[{string.Join(", ", strings)}]" : "[]";
            }
            else if (val is Enum e)
            {
                return EnumHelpers.GetValueName(e);
            }
            else
            {
                return val.ToString();
            }
        }
    }
}
