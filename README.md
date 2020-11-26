# Solid Principles For C# Developers (By Steve Smith aka Ardalis on PluralSight)

Breif overview about the course:

It's easy to write software that fulfills its users' immediate needs, but is difficult to extend and maintain. 
Such software becomes a burden for companies striving to remain competitive. 
In this course, SOLID Principles for C# Developers, you will learn five fundamental principles of object-oriented design that will keep your software loosely coupled, testable, and maintainable.

- First, you will see how to keep classes small and focused, and how to extend their behavior without having to edit their source code. 
- Then, you will discover the importance of properly designing interfaces and abstractions in your systems. 
- Finally, you will explore how to arrange dependencies in your system so different implementations can be added or plugged in as needed, allowing a truly modular design. 

When you are finished with this course, you will understand how to build maintainable, extensible, and testable applications using C# and .NET.

To make the most out of this repository, follow this steps:
1. Visit this branch first : https://github.com/Tejas1202/SolidPrinciplesForCSharpDevelopers/tree/master-upto-SOL-principlesonly . It contains the initial code and it's refactored version after applying SRP, OCP and LSP principle
2. After that, go to https://github.com/Tejas1202/SolidPrinciplesForCSharpDevelopers/tree/master-upto-SOL-before-applying-ISP where one fat interface is added containing all the functionality our main RatingEngine class needs but this violates ISP principle
3. And at last, visit https://github.com/Tejas1202/SolidPrinciplesForCSharpDevelopers/tree/master (i.e. master) branch in which ISP and DIP is followed. One Web API is also added just to depict how our Core business logic can be reused in different projects irrespective of the what we use as UI

Some Useful Links:
For OCP:
- https://hackernoon.com/why-the-open-closed-principle-is-the-one-you-need-to-know-but-dont-176f7e4416d
- https://blog.cleancoder.com/uncle-bob/2014/05/12/TheOpenClosedPrinciple.html
- https://codeblog.jonskeet.uk/2013/03/15/the-open-closed-principle-in-review/

For LSP:
- https://ardalis.com/nulls-break-polymorphism/

Some architectural guide
- https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles

Original Code:
- https://github.com/ardalis/SolidSample/
