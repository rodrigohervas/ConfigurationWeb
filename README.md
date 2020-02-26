# Access configuration from files and DB in ASP.NET Core 2

ConfigurationWeb is an ASP.NET Core 2.1 web app that shows how to access configuration info stored in various json files (appsettings.json, appsettings.[Environment].json, appsettings.Team.json, etc.), and in a SQL Server database.

Access to the database is done with Entity Framework Core 2.1.

All the configuration information is made available to the application at startup in the Program class, and later injected into the MVC controller classes via constructor injection.

Technologies used:

Front-End: ASP.NET MVC Core 2.1, HTML, CSS, Flexbox, Bootstrap, Javascript
Back-End: Framework .Net Core 2.1, C#, EF Core 2.1

## Live Site: 
https://configurationweb.azurewebsites.net/
