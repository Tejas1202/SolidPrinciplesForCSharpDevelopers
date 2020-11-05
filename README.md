# Solid Principles For C# Developers (ISP violation)
- This is the branch in which SRP, OCP and LSP were already applied, but in addition to that some fat interfaces have been added after https://github.com/Tejas1202/SolidPrinciplesForCSharpDevelopers/tree/master-upto-SOL-principlesonly branch.
- In this branch, IRatingContext interface (the "fat" interface) has been added and Rating Engine uses it's instance instead of seperate ConsoleLogger, FilePolicySource properties etc. as a dependency
- So in short, this branch just depicts how ISP is been violated and the fix for it will be in the main https://github.com/Tejas1202/SolidPrinciplesForCSharpDevelopers/tree/master branch
