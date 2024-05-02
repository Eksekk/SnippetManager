# CODE SNIPPET MANAGER
## Description
The program is designed to collect code snippets from various programming languages for informational purposes. For example, for C# there would be several showing how to use delegates or write extension methods, for Java examples of using streams, for C++ examples of using the bitset class, and for Python examples of using list comprehension. 

## Features
- Adding, editing, deleting snippets
- Syntax highlighting
- Snippet persistence (saving to file)
- Multiple programming languages supported
- Categorizing snippets by topic, programming language, level of advancement
- Some snippets may be runnable directly in the program to instantly check output and behavior, in particular after changing the snippet (this feature may be available only in dynamic programming languages)
- Extended description for some snippets (along with links to websites where the topic is discussed), accessible by clicking a button
- Cheat-sheets, i.e. condensed but long code with comments showing the syntax, built-in functions, etc. of a programming language
- Graphical user interface
- Sorting by clicking on column headers

## Various notes
- Whole project will be split into core library implementing most of functionality, and GUI application using this library.
- Should make top menu like in most windows programs and use some icons.
- Should use some kind of database to store snippets (could be simply JSON/XML).
- Snippet viewer/editor should use tabbed interface, to support editing multiple snippets at once.
- Need to make snippet viewer/editor support programming languages where you might need multiple files for single snippet (C++)