using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScintillaNET;
using SnippetManagerCore;

namespace SnippetManagerGuiAppWinForms
{
    public class MyScintillaControl : Scintilla
    {
        public MyScintillaControl() : base()
        {
            this.Margins[0].Type = MarginType.Number;
            Margins[0].Width = 20;
        }

        private void SetAllKeywordSets(SnippetLanguage lang)
        {
            int i = 0;
            string? keywords = lang.GetScintillaLexerKeywords(0);
            do
            {
                SetKeywords(i, keywords);
                keywords = lang.GetScintillaLexerKeywords(++i);
            } while (keywords != null);
        }

        public void ChangeLanguage(SnippetLanguage lang)
        {
            LexerLanguage = lang.GetScintillaLexerType();
            LexerName = lang.GetScintillaLexerType();
            SetAllKeywordSets(lang);

            this.StyleClearAll();
            switch (lang) 
            {
                case SnippetLanguage.Lua:
                    Styles[ScintillaNET.Style.Lua.Comment].ForeColor = Color.Green;
                    Styles[ScintillaNET.Style.Lua.CommentLine].ForeColor = Color.ForestGreen;
                    Styles[ScintillaNET.Style.Lua.CommentDoc].ForeColor = Color.YellowGreen;
                    Styles[ScintillaNET.Style.Lua.Number].ForeColor = Color.SeaGreen;
                    Styles[ScintillaNET.Style.Lua.Word].ForeColor = Color.Blue;
                    Styles[ScintillaNET.Style.Lua.String].ForeColor = Color.Orange;
                    Styles[ScintillaNET.Style.Lua.Word2].ForeColor = Color.Maroon;
                    Styles[ScintillaNET.Style.Lua.Word3].ForeColor = Color.LightSeaGreen;
                    Styles[ScintillaNET.Style.Lua.Word4].ForeColor = Color.Olive;
                    Styles[ScintillaNET.Style.Lua.Label].ForeColor = Color.IndianRed;
                    break;
                case SnippetLanguage.Python:
                    Styles[ScintillaNET.Style.Python.Word].ForeColor = Color.Chocolate;
                    Styles[ScintillaNET.Style.Python.DefName].ForeColor = Color.IndianRed;
                    Styles[ScintillaNET.Style.Python.Word2].ForeColor = Color.MediumSeaGreen;
                    break;
                case SnippetLanguage.Csharp:
                case SnippetLanguage.Cpp:
                case SnippetLanguage.Java:
                    Styles[ScintillaNET.Style.Cpp.Comment].ForeColor = Color.DimGray;
                    Styles[ScintillaNET.Style.Cpp.CommentLine].ForeColor = Color.DimGray;
                    Styles[ScintillaNET.Style.Cpp.CommentDoc].ForeColor = Color.DimGray;
                    Styles[ScintillaNET.Style.Cpp.Number].ForeColor = Color.Tomato;
                    Styles[ScintillaNET.Style.Cpp.Word].ForeColor = Color.Blue;
                    Styles[ScintillaNET.Style.Cpp.String].ForeColor = Color.Orange;
                    Styles[ScintillaNET.Style.Cpp.Operator].ForeColor = Color.DarkSlateGray;
                    Styles[ScintillaNET.Style.Cpp.Regex].ForeColor = Color.DarkGoldenrod;
                    Styles[ScintillaNET.Style.Cpp.Word2].ForeColor = Color.SteelBlue;
                    Styles[ScintillaNET.Style.Cpp.StringRaw].ForeColor = Color.SandyBrown;
                    break;
            }
        }
    }
}

// keyword sets:
// lua:
/*
    Keywords
    Basic functions
    String, (table) & math functions
    (coroutines), I/O & system facilities
    user1
    user2
    user3
    user4
*/

// python:
/*
    Keywords
    Highlighted identifiers
*/

// cpp:
/*
    Primary keywords and identifiers
    Secondary keywords and identifiers
    Documentation comment keywords
    Global classes and typedefs
    Preprocessor definitions
    Task marker and error marker keywords
*/