using HarmonyLib;
using IronPython.Hosting;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Scripting.Hosting;
using Neo.IronLua;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using System.Text.Json.Serialization;
using static IronPython.Modules.PythonWeakRef;

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

        public RunCodeResult LastRunCodeResult { get; set; }

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

        public record RunCodeResult
        {
            public string Output { get; init; }
            public bool Success { get; init; }
            public bool Failure { get; init; }
            public RunCodeResult(string output, bool success)
            {
                Output = output;
                Success = success;
                Failure = !success;
            }
        }

        Lua lua = new Lua();// TODO: cleanup on exit
        LuaGlobal? luaEnvironment;
        private RunCodeResult TryRunLua(bool persistEnvironment)
        {
            if (Lang != SnippetLanguage.Lua)
            {
                throw new InvalidOperationException("Cannot run Lua code when snippet is not written in Lua language");
            }
            string output = "";
            if (luaEnvironment is null || !persistEnvironment)
            {
                luaEnvironment = lua.CreateEnvironment();
            }
            dynamic dynenv = luaEnvironment;
            // replace built-in print function to capture its output
            dynenv.print = new Func<object[], LuaResult>(args =>
            {
                output += string.Join("\t", args) + "\n";
                return new LuaResult();
            });

            try
            {
                var res = luaEnvironment.DoChunk(Content, "snippet");
                if (res.Count > 0)
                {
                    output += "----------------------------------\nScript Results: \n" + string.Join("\n", res.Values.Select(r => r.ToString()));
                }
                return new RunCodeResult(output, true);
            }
            catch (LuaRuntimeException ex)
            {
                output += "----------------------------------\nScript execution failed: " + ex.Message; // TODO: make it print nice stack trace with line numbers etc.
                ex.StackTrace.Split('\n').ToList().ForEach(line => output += line + "\n");
                return new RunCodeResult(output, false);
            }
            catch (LuaParseException ex)
            {
                output += $"Script parsing failed (line {ex.Line}): {ex.Message}";
                return new RunCodeResult(output, false);
            }
        }

        private static ScriptEngine pythonEngine = Python.CreateEngine();
        private static ScriptScope pythonScope;
        delegate void MyPythonPrint(params object[] args);
        public RunCodeResult TryRunPython(bool persistEnvironment)
        {
            if (Lang != SnippetLanguage.Python)
            {
                throw new InvalidOperationException("Cannot run Python code when snippet is not written in Python language");
            }
            if (pythonScope is null || !persistEnvironment)
            {
                pythonScope = pythonEngine.CreateScope();
            }
            dynamic pythonGlobals = pythonScope;
            string output = "";
            pythonGlobals.print = new MyPythonPrint((args =>
            {
                output += string.Join("\t", args) + "\n";
            }));
            try
            {
                ScriptSource source = pythonEngine.CreateScriptSourceFromString(Content);
                dynamic res = source.Execute(pythonScope);
                return new RunCodeResult(output, true);
            }
            catch (Exception ex)
            {
                output += "----------------------------------\nScript execution failed: " + ex.Message; // TODO: make it print nice stack trace with line numbers etc.
                return new RunCodeResult(output, false);
            }
        }

        public class Injection
        {
            public static void install(MethodInfo original, MethodInfo patch)
            {
                RuntimeHelpers.PrepareMethod(original.MethodHandle);
                RuntimeHelpers.PrepareMethod(patch.MethodHandle);

                unsafe
                {
                    if (IntPtr.Size == 4)
                    {
                        int* inj = (int*)patch.MethodHandle.Value.ToPointer() + 2;
                        int* tar = (int*)original.MethodHandle.Value.ToPointer() + 2;
#if DEBUG
                        Console.WriteLine("\nVersion x86 Debug\n");

                        byte* injInst = (byte*)*inj;
                        byte* tarInst = (byte*)*tar;

                        int* injSrc = (int*)(injInst + 1);
                        int* tarSrc = (int*)(tarInst + 1);

                        *tarSrc = (((int)injInst + 5) + *injSrc) - ((int)tarInst + 5);
#else
                    Console.WriteLine("\nVersion x86 Release\n");
                    *tar = *inj;
#endif
                    }
                    else
                    {

                        long* inj = (long*)patch.MethodHandle.Value.ToPointer() + 1;
                        long* tar = (long*)original.MethodHandle.Value.ToPointer() + 1;
#if DEBUG
                        Console.WriteLine("\nVersion x64 Debug\n");
                        byte* injInst = (byte*)*inj;
                        byte* tarInst = (byte*)*tar;


                        int* injSrc = (int*)(injInst + 1);
                        int* tarSrc = (int*)(tarInst + 1);

                        *tarSrc = (((int)injInst + 5) + *injSrc) - ((int)tarInst + 5);
#else
                    Console.WriteLine("\nVersion x64 Release\n");
                    *tar = *inj;
#endif
                    }
                }
            }
        }

        static Assembly mainAssembly = Assembly.GetExecutingAssembly();
        public static List<string> outputListForPatching;
        [HarmonyPatch(typeof(System.Console), nameof(System.Console.WriteLine))]
        public static void PrefixHandler(string value)
        {
            // this if statement will hopefully disable patch when I myself call Console.WriteLine()
            if (Assembly.GetCallingAssembly() != mainAssembly)
            {
                outputListForPatching.Add(value + "\n");
            }
        }

        static AssemblyLoadContext LastAssemblyLoadContext = new AssemblyLoadContext(null, true);
        // note: hooking Console.WriteLine for now only works with strings
        public RunCodeResult TryRunCsharp()
        {
            var provider = new Microsoft.CSharp.CSharpCodeProvider();

            //var parms = new CompilerParameters();
            //parms.ReferencedAssemblies.Add("System.dll");
            //parms.ReferencedAssemblies.Add("System.Core.dll");
            //parms.GenerateInMemory = true;
            //parms.IncludeDebugInformation = true;
            //// enable top-level code
            //parms.CompilerOptions = "/t:library /unsafe /langversion:9 /top-level-statements+";

            //CompilerResults result = provider.
            //    CompileAssemblyFromSource(parms, this.Content);
            List<string> outputList = new();

            var refs = new HashSet<Assembly>()
            {
                typeof(object).Assembly,
                typeof(Console).Assembly,
            };
            foreach (var t in new Type[]{ typeof(string) })
            {
                refs.Add(t.Assembly);

            }

            foreach (var a in AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic
                    && a.ExportedTypes.Count() == 0
                    && (a.FullName.Contains("netstandard") || a.FullName.Contains("System.Runtime,"))))
                refs.Add(a);

            var options = CSharpParseOptions.Default
                .WithLanguageVersion(LanguageVersion.Latest);

            var compileOptions = new CSharpCompilationOptions(OutputKind.WindowsRuntimeApplication)
                .WithAssemblyIdentityComparer(DesktopAssemblyIdentityComparer.Default);

            var compilation = CSharpCompilation.Create("Dynamic",
                new[] { SyntaxFactory.ParseSyntaxTree(this.Content, options) },
                refs.Select(a => MetadataReference.CreateFromFile(a.Location)),
                compileOptions
            );

            if (LastAssemblyLoadContext is not null)
            {
                LastAssemblyLoadContext.Unload();
                LastAssemblyLoadContext = null; // unloading will not occur while there are references to it
            }
            LastAssemblyLoadContext = new AssemblyLoadContext("snippet", true);

            using var ms = new MemoryStream();
            var e = compilation.Emit(ms);
            if (!e.Success)
            {
                e.Diagnostics.ToList().ForEach(d => outputList.Add(d.ToString()));
                return new RunCodeResult(string.Join("Failed to compile the code! Reason below:\n\n", outputList), false);
            }
            ms.Seek(0, SeekOrigin.Begin);
            var ass = LastAssemblyLoadContext.LoadFromStream(ms);

            MethodInfo? consolePrint = ass.GetReferencedAssemblies().SelectMany(asName =>
            {
                return Assembly.Load(asName.Name).GetTypes().SelectMany(t => t.GetMethods().Where(method => method.Name == "WriteLine"));
            }).First();
            if (consolePrint is null)
            {
                throw new InvalidOperationException("Couldn't get Console.WriteLine() method of compiled code");
            }
            var myMethod = typeof(System.Console).GetMethod("WriteLine", new Type[] { typeof(string) });
            var myIL = myMethod.GetMethodBody().GetILAsByteArray();
            //Array.Resize(ref consolePrint.GetMethodBody().GetILAsByteArray(), myIL.Length);
            var harmony = new Harmony("write-line-patch");

            // setup handler to unhook function when dynamic assembly is unloaded (because it seems that multiple assemblies referencing same function/class directly "contain it", and modifying one modifies it for all other assemblies, there's no jump to right place like in assembly, which would allow to ignore unpatching
            //LastAssemblyLoadContext.Unloading += (context) => { harmony.Unpatch(consolePrint, patch); };
            
            //Injection.install(consolePrint!, myMethod);

            // actually run generated assembly's code
            MethodInfo? main = ass.EntryPoint;
            if (main is not null)
            {
                // note: not only parameter types must match, parameter NAMES also need to be identical! (if you use them, can skip in patch method signature)
                outputListForPatching = outputList;
                var method = typeof(System.Console).GetMethod("WriteLine", new Type[] { typeof(string) });
                var patch = harmony.Patch(method, new HarmonyMethod(PrefixHandler));
                object? methodReturn = main.Invoke(null, new object[] { Array.Empty<string>() });
                harmony.Unpatch(method, typeof(CodeSnippet).GetMethod("PrefixHandler"));
                string results = string.Empty;
                outputList.ForEach(s => results += s + "\n");
                if (outputList.Count == 0)
                {
                    results += "<no output>";
                }
                return new RunCodeResult(results, true);
            }
            return new RunCodeResult("Could not execute entry point of this code", false);


            //Console.WriteLine(methResult);
        }

        public RunCodeResult TryRunCode(bool persistEnvironment)
        {
            switch(Lang)
            {
                case SnippetLanguage.Lua:
                    {
                        LastRunCodeResult = TryRunLua(persistEnvironment);
                        return LastRunCodeResult;
                    }
                case SnippetLanguage.Python:
                    {
                        LastRunCodeResult = TryRunPython(persistEnvironment);
                        return LastRunCodeResult;
                    }
                case SnippetLanguage.Csharp:
                    {
                        LastRunCodeResult = TryRunCsharp();
                        return LastRunCodeResult;
                    }
                case SnippetLanguage.All:
                    // FIXME: throw exception here
                    return new("Cannot run code without language specified", false);
                default:
                    throw new NotImplementedException($"Running {EnumHelpers.GetValueName(Lang)} is not implemented yet");
            }
            
        }
    }
}
