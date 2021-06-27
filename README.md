# DHS
 Aplication Domain Driven Design using Visual Studio 2019
 
 ## Design patterns and concepts using DDD (Domain Driven Desing) 
 This project has concepts and techniques based on the vast material of studies on DDD and my experience over the years.
 Some of these are: Entities, AggregateRoot Class, Domain Events, Data Transfer Objects, Validation, Abstration of Domain Layer,
 Repository, AutoMapper, CrossCutting, Swagger, Entity-framework-core, Code Fisrt...
 
 ## Config database and project on vs
 Access the appSerttings file from the `src/DHS.Presentation.Web` path and change it to the sqlserver server instance and credentials settings.
 Example `"Default": "Server=YourSQL\\SQL; Database=DHSDb; user=yourUser; pwd=yourPass;"`. Then run the update-database command in the visual studio
 pakage-console, pointing to the `DHS.Infrastructure.Data` project. Check your MSSMS if the database has been created. Now set the startup project 
 DHS.Presentation.Web`. Now run.
 
 ## Build
 Aplication using .Net.5.0, EntityFrameworkCore 5.x runing IIS, Swagger, SqlServer
 https://localhost:44365/swagger/index.json
