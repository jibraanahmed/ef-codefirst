# ef-codefirst
Implementation of Entity Framework [CodeFirst Approach] using MVC .NETCORE 7!

// Steps to execute code!

Create a project using .NET CORE 7 of any template (Console,MVC or any). Now install nugets of Entity Framework. Now just copy the code of classes attached in this project. Get following files & folders replaced => models, contexts, controllers, appsettings.json, program.cs. Program.cs is the new Startup.cs in latest .Net in which we will have to add DbContext! insert your queryString/connectionString in appsettings.json, make sure it contains TrustServerCertificate as true i.e. [TrustServerCertificate=True] Rebuild code and open Nuget Manage Console and type two simple commands. 1) Add-Migration Initial 2) Update-Database. You're good to hit URL's using PostMan, now if you're new to EF you may implement Departments module which I have left empty!
