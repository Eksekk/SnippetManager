using Microsoft.Scripting.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IronPython.Modules._ast;

namespace SnippetManagerCore
{
    public static class ExampleSnippets
    {
        public static SnippetList Get()
        {
            SnippetList Snippets = new();
            Snippets.Add(new()
            {
                Name = "Hello World",
                Lang = SnippetLanguage.Csharp,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = @"using System;
Console.WriteLine(""Hello, World!"");",
                IsRunnable = true
            });
            Snippets.Add(new()
            {
                Name = "Hello World",
                Lang = SnippetLanguage.Cpp,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = "std::cout << \"Hello, World!\" << std::endl;"
            });
            Snippets.Add(new()
            {
                Name = "Hello World",
                Lang = SnippetLanguage.Java,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = "System.out.println(\"Hello, World!\");",
                ExtendedDesc = new SnippetExtendedDescription()
                {
                    Description = "This is a simple snippet to print 'Hello, World!' to the console",
                    Urls = new() { "https://en.wikipedia.org/wiki/%22Hello,_World!%22_program" }
                }
            });

            // lua snippets
            Snippets.Add(new()
            {
                Name = "Hello World",
                Lang = SnippetLanguage.Lua,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = "print(\"Hello, World!\")",
                IsRunnable = true
            });
            Snippets.Add(new()
            {
                Name = "Basic syntax",
                Lang = SnippetLanguage.Lua,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = @"-- Hello World
print(""Hello, world!"")

-- Variables and arithmetic
local a = 10
local b = 5
local result = a + b
print(""Result:"", result)
",
                IsRunnable = true
            });
            Snippets.Add(new()
            {
                Name = "Conditional statements",
                Lang = SnippetLanguage.Lua,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = @"-- If statement
local num = 10
if num > 0 then
    print(""Number is positive"")
elseif num < 0 then
    print(""Number is negative"")
else
    print(""Number is zero"")
end",
                IsRunnable = true
            });
            Snippets.Add(new()
            {
                Name = "Loops",
                Lang = SnippetLanguage.Lua,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = @"-- For loop
for i = 1, 5 do
    print(""Count:"", i)
end

-- While loop
local count = 0
while count < 5 do
    print(""Count:"", count)
    count = count + 1
end",
                IsRunnable = true
            });
            Snippets.Add(new()
            {
                Name = "Tables",
                Lang = SnippetLanguage.Lua,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.DataStructure, SnippetType.Syntax }.ToList(),
                Content = @"-- Creating a table
local person = {
    name = ""John"",
    age = 30,
    city = ""New York""
}

-- Accessing table elements
print(""Name:"", person.name)
print(""Age:"", person[""age""])

-- Iterating over table
for key, value in pairs(person) do
    print(key, value)
end",
                IsRunnable = true
            });
            Snippets.Add(new()
            {
                Name = "Functions",
                Lang = SnippetLanguage.Lua,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = @"-- Function definition
local function add(a, b)
    return a + b
end

-- Function call
print(""Result:"", add(10, 20))",
                IsRunnable = true
            });
            Snippets.Add(new()
            {
                Name = "Metatables",
                Lang = SnippetLanguage.Lua,
                Complexity = SnippetComplexity.MediumLow,
                Types = new[] { SnippetType.LanguageFeature }.ToList(),
                Content = @"-- Creating a metatable
local mt = {
    __add = function (self, other)
        return {self[1] + other[1], self[2] + other[2]}
    end
}

-- Creating tables with metatables
local t1 = {10, 20}
local t2 = {30, 40}
setmetatable(t1, mt)
setmetatable(t2, mt)

-- Adding tables
local result = t1 + t2
print(""Result:"", result[1], result[2])",
                IsRunnable = true
            });
            Snippets.Add(new()
            {
                Name = "Calculations",
                Lang = SnippetLanguage.Lua,
                Complexity = SnippetComplexity.MediumLow,
                Types = new[] { SnippetType.StandardLibrary }.ToList(),
                Content = @"-- calculate the area of a circle
local pi = math.pi
local radius = 12
local area = pi * radius * radius
print(string.format(""Area of a circle with radius %d is %.2f"", radius, area))
local t = setmetatable({}, {
    __index = function(tab)
        print(""Indexing a table"")
    end
})
local x = t[0]",
                IsRunnable = true
            });

            // python snippets
            Snippets.Add(new()
            {
                Name = "Hello World",
                Lang = SnippetLanguage.Python,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = @"print(""Hello, World!"")",
                IsRunnable = true
            });
            Snippets.Add(new()
            {
                Name = "Variables and arithmetic",
                Lang = SnippetLanguage.Python,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = @"# Variables and arithmetic
a = 10
b = 5
result = a + b
print(""Result:"", result)",
                IsRunnable = true
            });
            Snippets.Add(new()
            {
                Name = "Conditional statements",
                Lang = SnippetLanguage.Python,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = @"# If statement
num = -8
if num > 0:
    print(""Number is positive"")
elif num < 0:
    print(""Number is negative"")
else:
    print(""Number is zero"")",
                IsRunnable = true
            });
            Snippets.Add(new()
            {
                Name = "Loops",
                Lang = SnippetLanguage.Python,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = @"# For loop
for i in range(1, 6):
    print(""Count:"", i)

# While loop
count = 0
while count < 5:
    print(""Count:"", count)
    count += 1",
                IsRunnable = true
            });
            Snippets.Add(new()
            {
                Name = "Lists",
                Lang = SnippetLanguage.Python,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.DataStructure, SnippetType.Syntax }.ToList(),
                Content = @"# Creating a list
numbers = [1, 2, 3, 4, 5]

# Accessing list elements
print(""First number:"", numbers[0])

# Iterating over list
for num in numbers:
    print(""Number:"", num)",
                IsRunnable = true
            });
            Snippets.Add(new()
            {
                Name = "Functions",
                Lang = SnippetLanguage.Python,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.LanguageFeature, SnippetType.Syntax }.ToList(),
                Content = @"# Function definition
def add(a, b):
    return a + b

# Function call
print(""Result:"", add(10, 20))
# Inline function call
print(""Result:"", (lambda x, y: x + y)(10, 20))",
                IsRunnable = true
            });
            Snippets.Add(new()
            {
                Name = "Classes and objects",
                Lang = SnippetLanguage.Python,
                Complexity = SnippetComplexity.MediumLow,
                Types = new[] { SnippetType.LanguageFeature, SnippetType.Syntax }.ToList(),
                Content = @"# Class definition
class Person:
    def __init__(self, name, age):
        self.name = name
        self.age = age

    def greet(self):
        print(""Hello, my name is"", self.name, ""and I am"", self.age, ""years old."")

# Creating objects
person1 = Person(""John"", 30)
person2 = Person(""Alice"", 25)

# Accessing object attributes
print(""Name:"", person1.name)
print(""Age:"", person2.age)

# Calling object methods
person1.greet()
person2.greet()",
                IsRunnable = true
            });
            Snippets.Add(new()
            {
                Name = "Dictionaries",
                Lang = SnippetLanguage.Python,
                Complexity = SnippetComplexity.MediumLow,
                Types = new[] { SnippetType.DataStructure, SnippetType.Syntax }.ToList(),
                Content = @"# Creating a dictionary
person = {
    ""name"": ""John"",
    ""age"": 30,
    ""city"": ""New York""
}

# Accessing dictionary elements
print(""Name:"", person[""name""])
print(""Age:"", person.get(""age""))

# Iterating over dictionary
for key, value in person.items():
    print(key, "":"", value)",
                IsRunnable = true
            });

            return Snippets;
        }
    }
}
