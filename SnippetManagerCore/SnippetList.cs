using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SnippetManagerCore
{
    public class CollectionToStringTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return false;
        }
        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        {
            return destinationType is not null && destinationType == typeof(string);
        }
        public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (value is not null && destinationType == typeof(string))
            {
                if (value is not IEnumerable)
                {
                    throw new ArgumentException($"Type '{value.GetType().Name}' is not a collection");
                }
                var elements = value as IEnumerable;
                List<string> strings = new();
                foreach (object o in elements)
                {
                    strings.Add(o.ToString());
                }
                return $"[{string.Join(", ", strings.ToArray())}]";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    public class SnippetList : List<CodeSnippet>
    {
        public IEnumerable<CodeSnippet> FindSnippetsByTypes(params SnippetType[] types)
        {
            return this.Where(s => types.Any(t => s.Types.Contains(t)));
        }

        public IEnumerable<CodeSnippet> FindSnippetsByLanguage(SnippetLanguage lang)
        {
            return this.Where(s => s.Lang == lang);
        }

        public IEnumerable<CodeSnippet> FindSnippetsByComplexity(SnippetComplexity complexity)
        {
            return this.Where(s => s.Complexity == complexity);
        }

        public record FindSnippetByOptions
        {
            public string? Name;
            public SnippetType[]? Types;
            public SnippetLanguage? Lang;
            public SnippetComplexity? Complexity;
            public ThreeValueEnum IsRunnable;
            public ThreeValueEnum HasExtendedDescription;
            // helper property to allow setting 'Type' property without creating an array
            public SnippetType Type {
                set
                {
                    if (Types is not null)
                    {
                        throw new InvalidOperationException("Cannot set 'Type' property when 'Types' is already set");
                    }
                    Types = new SnippetType[] { value };
                }
            }

            public FindSnippetByOptions(string? Name = null, SnippetType[]? Types = null, SnippetLanguage? Lang = null, SnippetComplexity? Complexity = null, ThreeValueEnum IsRunnable = ThreeValueEnum.Any, ThreeValueEnum HasExtendedDescription = ThreeValueEnum.Any)
            {
                this.Name = Name;
                this.Types = Types;
                this.Lang = Lang;
                this.Complexity = Complexity;
                this.IsRunnable = IsRunnable;
                this.HasExtendedDescription = HasExtendedDescription;
            }

            // this one requires to provide Name parameter in addition to Type, because Type can't be optional (due to ambiguity with the other constructor), and so Name needs to be mandatory as well, because optional parameters can't be used before required ones
            public FindSnippetByOptions(string Name, SnippetType Type, SnippetLanguage? Lang = null, SnippetComplexity? Complexity = null, ThreeValueEnum IsRunnable = ThreeValueEnum.Any, ThreeValueEnum HasExtendedDescription = ThreeValueEnum.Any)
                : this(Name, new SnippetType[] { Type }, Lang, Complexity, IsRunnable, HasExtendedDescription) { }

            // allows unpacking this record into multiple variables with one statement
            public void Deconstruct(out string? Name, out SnippetType[]? findTypes, out SnippetLanguage? findLang, out SnippetComplexity? findComplexity, out ThreeValueEnum isRunnable, out ThreeValueEnum hasExtendedDescription)
            {
                Name = this.Name;
                findTypes = this.Types;
                findLang = this.Lang;
                findComplexity = this.Complexity;
                isRunnable = this.IsRunnable;
                hasExtendedDescription = this.HasExtendedDescription;
            }
        }

        public IEnumerable<CodeSnippet> FindSnippetsBy(FindSnippetByOptions opt)
        {
            var (Name, findTypes, findLang, findComplexity, isRunnable, hasExtendedDescription) = opt;
            Func<CodeSnippet, bool> checkTypes = s => findTypes == null || findTypes.Any(t => t == SnippetType.Any || s.Types.Contains(t));
            return this
                .Where(snip => Name is null || snip.Name.ToLower().Contains(Name.ToLower()))
                .Where(checkTypes)
                .Where(snip => findLang == null || findLang == SnippetLanguage.All || snip.Lang == findLang)
                .Where(snip => findComplexity == null || findComplexity == SnippetComplexity.Any || snip.Complexity == findComplexity)
                .Where(snip => isRunnable == ThreeValueEnum.Any || (isRunnable == ThreeValueEnum.Yes && snip.IsRunnable) || (isRunnable == ThreeValueEnum.No && !snip.IsRunnable))
                .Where(snip => hasExtendedDescription == ThreeValueEnum.Any || (hasExtendedDescription == ThreeValueEnum.Yes && snip.ExtendedDesc is not null) || (hasExtendedDescription == ThreeValueEnum.No && snip.ExtendedDesc is null));
        }

        public SnippetList() : base() { }

        public SnippetList(IEnumerable<CodeSnippet> codeSnippets) : base(codeSnippets)
        {
        }

        private SnippetList LoadFromFileCommon(string filename)
        {
            try
            {
                using FileStream f = File.Open(filename, FileMode.Open);
                SnippetList? l = JsonSerializer.Deserialize(f, typeof(SnippetList)) as SnippetList;
                return l ?? new();
            }
            catch (JsonException e)
            {
                throw new exceptions.SnippetLoadingException($"JSON error while loading snippets from file '{filename}': {e.Message}", e);
            }
            catch (IOException e)
            {
                throw new exceptions.SnippetLoadingException($"IO error while loading snippets from file '{filename}': {e.Message}", e);
            }
        }

        public void LoadFromFile(string filename)
        {
            var l = LoadFromFileCommon(filename);
            this.Clear();
            this.AddRange(l);
        }

        public static SnippetList LoadFromFileStatic(string filename)
        {
            return new SnippetList().LoadFromFileCommon(filename);
        }

        public void AppendFromFile(string filename)
        {
            var l = LoadFromFileCommon(filename);
            this.AddRange(l);
        }

        public delegate void SnippetLoadCallbackType(SnippetList me, SnippetList loaded);

        public void LoadFromFileAndExecute(string filename, SnippetLoadCallbackType callback)
        {
            var l = LoadFromFileCommon(filename);
            callback(this, l);
        }

        public void SaveToFile(string filename)
        {
            try
            {
                using FileStream f = File.Open(filename, FileMode.Create);
                JsonSerializer.Serialize(f, this);
            }
            catch (JsonException e)
            {
                var newExp = new exceptions.SnippetSavingException($"JSON error while saving snippets to file '{filename}': {e.Message}", e);
                Debug.WriteLine(newExp.StackTrace);
                throw newExp;
            }
            catch (IOException e)
            {
                var newExp = new exceptions.SnippetSavingException($"IO error while saving snippets to file '{filename}': {e.Message}", e);
                Debug.WriteLine(newExp.StackTrace);
                throw newExp;
            }
        }

        public delegate void SnippetSaveCallbackType(SnippetList me, FileStream file);

        public void SaveToFileCustom(string filename, SnippetSaveCallbackType callback)
        {
            try
            {
                using FileStream f = File.Open(filename, FileMode.Create);
                callback(this, f);
            }
            catch (IOException e)
            {
                var newExp = new exceptions.SnippetSavingException($"IO error while saving snippets to file '{filename}': {e.Message}", e);
                Debug.WriteLine(newExp.StackTrace);
                throw newExp;
            }
        }
    }
}
