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

        public void ChangeLanguage(SnippetLanguage lang)
        {
            LexerLanguage = lang.GetScintillaLexerType();
            LexerName = lang.GetScintillaLexerType();
            SetKeywords(0, lang.GetScintillaLexerKeywords());

            this.StyleClearAll();
            switch (lang) 
            {
                case SnippetLanguage.Lua:
                    Styles[Style.Lua.Operator].ForeColor = Color.Tan;
                    Styles[Style.Lua.Comment].ForeColor = Color.YellowGreen;
                    Styles[Style.Lua.CommentLine].ForeColor = Color.Green;
                    Styles[Style.Lua.String].ForeColor = Color.Orange;
                    Styles[Style.Lua.Identifier].ForeColor = Color.IndianRed;
                    Styles[Style.Lua.Word].ForeColor = Color.Blue; // keywords
                    Styles[Style.Lua.Number].ForeColor = Color.DarkOrchid;
                    break;
                case SnippetLanguage.Python:
                    Styles[Style.Python.Operator].ForeColor = Color.Green;
                    break;
                case SnippetLanguage.Csharp:
                case SnippetLanguage.Cpp:
                case SnippetLanguage.Java:
                    Styles[Style.Cpp.Operator].ForeColor = Color.Green;
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