# Lenus Blood Pressure Sample
This application is an example of using Lenus to capture Blood Pressure measurements, and have a clinician review and act on the readings.

Features:

* Clinician can invite a patient to the service.
* Patient receives invitiation and registers or logs in with Lenus to complete the onboarding process.
* Patient submits a blood pressure reading (via this web app, not a separate one)
* Clinician is notified if reading is in hypertension range 
    * Two stage 1 hypertension in a row
    * One stage 2 hypertension
* Clinician can send message to the patient, and patient can respond.

This sample attempts to use Domain Driven Design and Clean Architecture.  

## Code Features

Clean Architecture project structure inspired by the Jason Taylor template.

* Domain - entities, enums, value objects, core interfaces and domain logic
* Application - depends on domain, contains all application logic.  Interfaces, but not implementations
* Infrastructure - implementation of application interfaces, integrations with external resources.
* WebUI - the UI layer, depends on application layer.  Any dependency on infrastructure should only be in Startup.cs to enable DI

Value Object taken from MS Microservices example.

MediatR used _only_ for WebUI to Application communication.

Automapper used sparingly, using IMapFrom interface and ProjectTo extensions.

Repository setup taken from MyWarehouse sample code.  The domain has no reference to Entity Framework, so all persistence is managed
in the Infrastructure project.  I've deliberately avoided referencing EF DbSet in the application repository interfaces, which I'm still not 100%
sold on

Guard clauses from Ardalis.Guard nuget package

ASPNet Core HealthChecks

Logging using SeriLog

Editor config settings taken from the aspnetcore repository https://github.com/dotnet/aspnetcore/blob/main/.editorconfig, with some custom additions.

Secure Coding Guidelines

* UseHttpsRedirection() in Startup
* AddHsts() in startup, with updated Hsts options
* SslProtocols set in Program.cs (TLS 1.2 and 1.3 only)
* UseDeveloperExceptionPage() in Startup, only for Developer environments
* Security headers added as Middleware (X-XSS-Protection, X-Content-Type-Options, X-Frame-Options, Referrer-Policy)
* Kestrel server header removed in Program.cs
* CookieOptions secure policy set to Always
* Added Content Security Policy


### To-Do

* Try and remove need for Mediator reference in domain for notifications
* Communication with Lenus to save / retrieve data samples
* Implement Outbox pattern for domain to integration events, so that integration events aren't fired until the db transaction is completed
* Authorization policies
* Proper build script, including outdated packages reported as part of build using  `dotnet list package --vulnerable`
* Background processing using Hangfire
* Azure pipeline files
* Bicep deployment files


## VS Code Remote development

The application has been developed using a number of tools

* VS 2019 on Windows 10
* VS Code on Windows 10
* VS Code on Windows, using docker in WSL2
* VS Code on Chromebook, using remote docker container in Azure

## Acknowledgements

This project uses code from the following sources, either directly, adapted, or for inspiration:

* Jason Taylor Clean Architecture Template
* Northwind Sample Application
* Microsoft eShop on Web
* Microsoft eShop on Containers
* MyWarehouse sample application
* "Ardalis" Clean Architecture Template
* ASP.NET Core 5 Secure Coding Cookbook (Packt Publishing)


