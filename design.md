# CODE SNIPPET MANAGER
## Description
The program is designed to collect code snippets from various programming languages for informational purposes. For example, for C# there would be several showing how to use delegates or write extension methods, for Java examples of using streams, for C++ examples of using the bitset class, and for Python examples of using list comprehension. 

## Features
- Adding, editing, deleting snippets
- Cloning snippets, to quickly create variations of them
- Syntax highlighting
- Snippet persistence (saving to file)
- Multiple programming languages supported
- Categorizing snippets by topic, programming language, level of advancement
- Some snippets may be runnable directly in the program to instantly check output and behavior, in particular after changing the snippet (this feature may be available only in dynamic programming languages)
- Extended description for some snippets (along with links to websites where the topic is discussed), accessible by clicking a button
- Cheat-sheets, i.e. condensed but long code with comments showing the syntax, built-in functions, etc. of a programming language
- Graphical user interface
- Sorting by clicking on column headers

## TODO features
### Advanced Search and Filtering
- Tagging System: Allow users to add custom tags to snippets for better organization and searchability.
- Advanced Search Filters: Enable searching by specific criteria such as tags, date added, complexity, or keywords within the snippet or description.
- Fuzzy Search: Implement a fuzzy search algorithm to find snippets even if the search terms are slightly misspelled or not exact matches.
### Collaboration and Sharing
- Snippet Sharing: Provide functionality to share snippets via a link, export them as a file, or directly share to code-sharing platforms like GitHub Gist or Pastebin.
- Version Control: Integrate basic version control for snippets, allowing users to track changes, revert to previous versions, or merge changes from multiple users.
### User Customization and Preferences
- Custom Syntax Highlighting Themes: Allow users to choose or create custom themes for syntax highlighting.
- User Preferences: Save user preferences for the interface layout, default programming language, and other settings.
### Snippet Utilization and Automation
- Code Templates: Offer predefined templates for common tasks or patterns in various languages.
- Snippet Integration: Allow integration with IDEs or text editors via plugins or extensions, enabling quick insertion of snippets directly into the user's development environment.
- Automated Code Analysis: Provide tools for static analysis or linting of snippets to ensure best practices and code quality.
### Learning and Documentation
- Interactive Tutorials: Create interactive tutorials where users can follow along with guided examples and edit code live.
- Code Challenges: Include coding challenges or exercises that users can solve using the snippets, helping reinforce learning.
- Detailed Documentation: Generate detailed documentation for each snippet, including potential use cases, common pitfalls, and optimization tips.
### Enhanced Usability Features
- ~~Snippet Cloning: Allow users to clone existing snippets to quickly create variations.~~
- Snippet Metrics: Track and display metrics such as the number of times a snippet has been used or run, its average execution time

## Various notes
- Whole project will be split into core library implementing most of functionality, and GUI application using this library.
- Should make top menu like in most windows programs and use some icons.
- Should use some kind of database to store snippets (could be simply JSON/XML).
- Snippet viewer/editor should use tabbed interface, to support editing multiple snippets at once.
- Need to make snippet viewer/editor support programming languages where you might need multiple files for single snippet (C++)