WPFSharp
========

WPFSharp - WPF fluent API for layout in C#.   Replaces need for XAML in small projects

Introduction
------------

WPFSharp is a Fluent API for WPF functions.  It is designed to be a DSL in C# that helps code WPF layouts.  It is intended for two use cases:

1) Small projects where a XAML file is inconvient 
2) Complex run-time generated WPF layouts where the code-behind gets messy

Add/Removing WPF Controls
---------------------------

The source for WPFSharp is automatically generated using System.Reflection.  The Project WPFSharpBuilderBuilder contains console application that builds the C# file Builder.cs  

If you want to add or remove WPF controls, simple add the controls to the Controls array.  If they are not part of the .NET package, you will also need to update the references.  Then run WPFSharpBuilderBuilder and rebuild the WPFSharp project.


