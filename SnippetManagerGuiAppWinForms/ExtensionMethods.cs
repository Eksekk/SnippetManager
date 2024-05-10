using SnippetManagerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManagerGuiAppWinForms
{
    public static class ExtensionMethods
    {
        public static string GetScintillaLexerType(this SnippetLanguage lang)
        {
            switch (lang)
            {
                case SnippetLanguage.Csharp:
                case SnippetLanguage.Cpp:
                case SnippetLanguage.Java:
                    return "cpp";
                case SnippetLanguage.Lua:
                    return "lua";
                case SnippetLanguage.Python:
                    return "python";
                default:
                    throw new InvalidOperationException("Unknown language");
            }
        }

        private static readonly Dictionary<SnippetLanguage, string[]> keywordsByLanguage = new() {
            { SnippetLanguage.Lua, new string[] {
                "and break do else elseif end false for function goto if in local nil not or repeat return then true until while",
                "getmetatable"
            } },

        };

        public static string GetScintillaLexerKeywords(this SnippetLanguage lang, int keywordSet = 0)
        {
            string[]? keywordTable = keywordsByLanguage.ContainsKey(lang) ? keywordsByLanguage[lang] : null;
            if (keywordTable is not null)
            {
                if (keywordSet >= 0 && keywordSet < keywordTable.Length)
                {
                    return keywordTable[keywordSet];
                }
            }
            return "";
        }
    }
}
