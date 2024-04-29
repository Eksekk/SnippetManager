using System.ComponentModel;
using System.Drawing;

namespace SnippetManagerCore
{
    public enum ThreeValueEnum
    {
        Any,
        Yes,
        No
    }
    public enum SnippetLanguage
    {
        All,
        Csharp,
        Cpp,
        Lua,
        Python,
        Java
    }
    public enum SnippetComplexity
    {
        Any,
        Low,
        MediumLow,
        Medium,
        MediumHigh,
        High
    }
    [TypeConverter(typeof(CollectionToStringTypeConverter))]
    public enum SnippetType
    {
        Any,
        Syntax,
        StandardLibrary,
        LanguageFeature,
        Algorithm,
        DataStructure,
    }
    // will contain extended description (very long one, which will be displayed in a separate window), and some helpful information urls for special handling (for example, to easily make links clickable)
    public struct SnippetExtendedDescription
    {
        public string Description { get; set; }
        public List<string> Urls { get; set; }
    }
    public class CodeSnippet
    {
        // language the snippet is written in
        public SnippetLanguage Lang { get; set; }
        // complexity of the snippet
        public SnippetComplexity Complexity { get; set; }
        // types of the snippet, like syntax, standard library, language feature etc.
        // using a list here, because some snippets may belong to multiple categories, in particular cheatsheets
        public List<SnippetType> Types { get; set; }
        public bool IsOfType(SnippetType type) => Types.Contains(type);
        // name of the snippet, used for displaying to user
        public string Name { get; set; }
        // actual code of the snippet
        public string Content { get; set; }
        // optional extended description (text + links to websites with info)
        // this can be nullable, because not all snippets will have an extended description
        public SnippetExtendedDescription? ExtendedDesc { get; set; }
        // determines whether snippet is automatically runnable or not (to check instantly its result in console, test changes etc.)
        // this only shows if snippet is suitable for and was intended to be instantly testable, language also affects this (C++ snippets won't be runnable for example, because I won't bundle and integrate C++ compiler)
        public bool IsRunnable { get; set; }

        public override string ToString() => Tools.GenericClassObjectInfoToString(this, Color.Black);

        public CodeSnippet Clone()
        {
            return new CodeSnippet
            {
                Lang = Lang,
                Complexity = Complexity,
                Types = new List<SnippetType>(Types),
                Name = Name,
                Content = Content,
                ExtendedDesc = ExtendedDesc,
                IsRunnable = IsRunnable
            };
        }
    }
}
