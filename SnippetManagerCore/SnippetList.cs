﻿using System;
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
                return "[" + string.Join(", ", strings.ToArray()) + "]";
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

        public IEnumerable<CodeSnippet> FindSnippetsBy(SnippetType[]? findTypes = null, SnippetLanguage? findLang = null, SnippetComplexity? findComplexity = null)
        {
            Func<CodeSnippet, bool> checkTypes = s => findTypes == null || findTypes.Any(t => t == SnippetType.Any || s.Types.Contains(t));
            return this.Where(snip => checkTypes(snip) && (findLang == null || findLang == SnippetLanguage.All || snip.Lang == findLang) && (findComplexity == null || findComplexity == SnippetComplexity.Any || snip.Complexity == findComplexity));
        }

        public IEnumerable<CodeSnippet> FindSnippetsBy(SnippetType? findType, SnippetLanguage? findLang = null, SnippetComplexity? findComplexity = null)
        {
            return FindSnippetsBy(new[] {findType ?? SnippetType.Any}, findLang, findComplexity);
        }

        public SnippetList() : base() { }

        public SnippetList(IEnumerable<CodeSnippet> codeSnippets) : base(codeSnippets)
        {
        }

        public void LoadFromFile(string filename)
        {
            try
            {
                using FileStream f = File.Open(filename, FileMode.Open);
                SnippetList? l = JsonSerializer.Deserialize(f, typeof(SnippetList)) as SnippetList;
                this.Clear();
                this.AddRange(l ?? new());
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
    }
}
