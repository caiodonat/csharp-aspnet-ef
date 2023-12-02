# csharp-aspnet-ef

Getting started with C# ecosystem

## Info

### Database schema

<!-- [![ER Diagram on DBDiagram](src/database/docs/erd.png)](https://dbdiagram.io/) -->

### File structure

```dir
# DDD
ProjectName/
└── src
	├── Application
	│	├── Controllers
	│	└── Middlewares
	├── Domain
	│	├── DTOs
	│	├── Entities
	│	├── Exceptions
	│	├── Services
	│	└── Validators
	└── Infrastructure
	 	├── Database
	 	├── Migrations
	 	└── Repositories
```

## Tech Stack

### Main Techs

- Language : `C#` (7.0.401)
- Web Application framework : `ASP.NET` (7.0.11)
- Database : `PostgreSQL` (15.4)
- Object-Relational Mapping (ORM) : `Entity Framework` (7.0.12)
- Build : `MSBuild` (17.7.3)

### Libraries

- Package manager : `NuGet` (6.7.0)
- Schema validation : `Fluent Validator` ()
- API documentation : `Swagger` () | `OpenAPI` (3.0.3)
- Technical documentation : `docfx` (?)

### Development Environment

- OS : `Win` (11) | `WSL 2` (Ubuntu 22.04) | `Dev Container`
- IDE : `VS Code` (^1.83.0)

---

## Getting Started Guide

After clone repo, is require install all dependencies (packages), like `npm i` you can use:

```bash
dotnet restore
```

Some commands require Entity Framework CLI (`dotnet-ef`), you can install this "Tool" with:

```bash
dotnet tool install --global dotnet-ef --version 7.0.12
```

Apply all migration on Database

```bash
dotnet-ef database update
```

Run project:

```bash
donet watch run
```

---

---

## TIPs and Tricks

### CLI

```bash
# Get repo statistics
tokei --exclude *.sql *.toml --sort code > .vscode/detail/$(date --utc +%FT%TZ)
```
