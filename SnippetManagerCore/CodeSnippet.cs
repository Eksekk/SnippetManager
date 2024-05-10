using System.ComponentModel;
using System.Drawing;
using System.Text.Json.Serialization;

namespace SnippetManagerCore
{
    public enum ThreeValueEnum
    {
        Any,
        Yes,
        No
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SnippetLanguage
    {
        All,
        [EnumText("C#")]
        Csharp,
        [EnumText("C++")]
        Cpp,
        Lua,
        Python,
        Java
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SnippetComplexity
    {
        Any,
        Low,
        [EnumText("Medium-low")]
        MediumLow,
        Medium,
        [EnumText("Medium-high")]
        MediumHigh,
        High
    }
    [TypeConverter(typeof(CollectionToStringTypeConverter))]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SnippetType
    {
        Any,
        Syntax,
        [EnumText("Standard library")]
        StandardLibrary,
        [EnumText("Language feature")]
        LanguageFeature,
        Algorithm,
        [EnumText("Data structure")]
        DataStructure,
        [EnumText("Design pattern")]
        DesignPattern,
    }
    // will contain extended description (very long one, which will be displayed in a separate window), and some helpful information urls for special handling (for example, to easily make links clickable)
    public struct SnippetExtendedDescription
    {
        public string Description { get; set; }
        public List<string> Urls { get; set; }

        public static bool operator==(SnippetExtendedDescription a, SnippetExtendedDescription b)
        {
            return a.Description == b.Description
                && a.Urls.SequenceEqual(b.Urls);
        }

        public static bool operator!=(SnippetExtendedDescription a, SnippetExtendedDescription b)
        {
            return !(a == b);
        }
    }
    public class CodeSnippet : ICloneable, IEquatable<CodeSnippet>
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

        public CodeSnippet()
        {
            Name = "<unnamed>";
            Content = "";
            Lang = SnippetLanguage.Python;
            Complexity = SnippetComplexity.Low;
            Types = new[] { SnippetType.Syntax }.ToList();
            ExtendedDesc = null;
            IsRunnable = false;
        }

        public override string ToString() => Tools.GenericClassObjectInfoToString(this, Color.Black);

        public object Clone()
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

        public static bool operator==(CodeSnippet a, CodeSnippet b)
        {
            return a.Lang == b.Lang
                && a.Complexity == b.Complexity
                && a.Types.OrderBy(t => t).SequenceEqual(b.Types.OrderBy(t => t))
                && a.Name == b.Name
                && a.Content == b.Content
                && a.ExtendedDesc == b.ExtendedDesc
                && a.IsRunnable == b.IsRunnable;
        }

        public bool Equals(CodeSnippet other)
        {
            return this == other;
        }

        public static bool operator !=(CodeSnippet a, CodeSnippet b)
        {
            return !(a == b);
        }

        public void AssignPropertiesOf(CodeSnippet other)
        {
            Lang = other.Lang;
            Complexity = other.Complexity;
            Types = new List<SnippetType>(other.Types);
            Name = other.Name;
            Content = other.Content;
            ExtendedDesc = other.ExtendedDesc;
            IsRunnable = other.IsRunnable;
        }

        // this is probably a horrible "algorithm", but I did it just so there is an option of proper expansion in the future
        public SnippetComplexity NaiveCalculateComplexity()
        {
            string[] code = Content.Split('\n');
            int result = code.Length * 30 + Content.Length;
            if (result < 100)
            {
                return SnippetComplexity.Low;
            }
            else if (result < 200)
            {
                return SnippetComplexity.MediumLow;
            }
            else if (result < 300)
            {
                return SnippetComplexity.Medium;
            }
            else if (result < 400)
            {
                return SnippetComplexity.MediumHigh;
            }
            else
            {
                return SnippetComplexity.High;
            }
        }

        private static readonly SnippetLanguage[] NonRunnableLangs = new[] { SnippetLanguage.Cpp, SnippetLanguage.Java };
        // validates whether IsRunnable property is valid only by language (some languages are never runnable)
        public bool ValidateIsRunnableByLanguage()
        {
            return IsLanguageRunnable(Lang);
        }
        public static bool IsLanguageRunnable(SnippetLanguage Lang)
        {
            if (NonRunnableLangs.Contains(Lang))
            {
                return false;
            }
            return true;
        }
    }
}
