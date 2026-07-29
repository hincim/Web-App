# Web-App (ShopApp)

An ASP.NET Core e-commerce solution composed of multiple projects for web UI, API, business logic, data access, and entities.

## Solution Overview

The repository contains a Visual Studio solution: `ShopApp.sln` with these projects:

- `ShopApp.WebUI` — MVC storefront and admin UI
- `ShoppApp.WebApi` — REST API project
- `ShopApp.Business` — business/service layer
- `ShopApp.Data` — Entity Framework Core data access layer
- `ShopApp.Entity` — domain entities

There is also a root `package.json` with a frontend dependency on `ckeditor`.

## Key Features (from codebase)

- Product listing, filtering by category, search, and product detail pages (`ShopController`)
- Shopping cart and checkout flow scaffolding (`CartController`)
- Account registration, login/logout, email confirmation, and password reset (`AccountController`)
- Role/user/product/category management for admin users (`AdminController`)
- Product CRUD API endpoints in `ShoppApp.WebApi/Controllers/ProductsController.cs`
- EF Core data seeding for sample products/categories (`ShopApp.Data/Configurations/ModelBuilderExtension.cs`)
- Identity seeding for roles/users from configuration (`ShopApp.WebUI/Identity/SeedIdentity.cs`)

## Tech Stack

- .NET Core / ASP.NET Core 3.1 (`netcoreapp3.1` target in all `.csproj` files)
- ASP.NET Core MVC + Identity
- Entity Framework Core (SQL Server and SQLite packages are referenced)
- Newtonsoft.Json
- CKEditor

## Prerequisites

- .NET Core 3.1 SDK (or compatible SDK that can build `netcoreapp3.1` projects)
- SQL Server instance (default configuration uses SQL Server connection strings)

## Configuration

Primary configuration files:

- `ShopApp.WebUI/appsettings.json`
- `ShoppApp.WebApi/appsettings.json`

Update at least:

- `ConnectionStrings:MsSqlConnection`
- `EmailSender` settings (for email flows)

`ShopApp.WebUI` also reads seed roles/users from the `Data` section in `appsettings.json`.

## Build

From repository root:

```bash
dotnet restore ShopApp.sln
dotnet build ShopApp.sln
```

## Run

Run Web UI:

```bash
dotnet run --project ShopApp.WebUI/ShopApp.WebUI.csproj
```

Run API:

```bash
dotnet run --project ShoppApp.WebApi/ShoppApp.WebApi.csproj
```

> Note: Both projects currently define `https://localhost:5001;http://localhost:5000` in their launch settings. If running both at once, update one project's URLs to avoid port conflicts.

## Database Behavior

- `ShopApp.WebUI` runs migrations on startup via `MigrateDatabase()` in `Program.cs`.
- EF Core model seed data is configured in `ShopApp.Data/Configurations/ModelBuilderExtension.cs`.
- Identity roles/users are seeded at startup in `ShopApp.WebUI/Startup.cs` via `SeedIdentity.Seed(...)`.

## API Endpoints (ProductsController)

Base route: `/api/products`

- `GET /api/products/{id}`
- `POST /api/products`
- `PUT /api/products/{id}`
- `DELETE /api/products/{id}`

## Repository Notes

- No dedicated test projects were found in this repository.
- The repository includes generated `bin/` and `obj/` directories inside project folders.
