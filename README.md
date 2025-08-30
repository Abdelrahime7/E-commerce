
Integrated E-Commerce & Services Platform

An integrated e-commerce & services platform built with ASP.NET Core Web API, designed using Service-Driven Design and Clean Architecture.

This project provides a modular and scalable solution for showcasing, selling, and tracking product variants while supporting multiple payment methods, shipping, and advanced analytics.


---

🚀 Features

Showcase and sell product variants

Manage shipping & information services

Support multiple payment methods

Track and analyze sales, discounts & claims

Authorized roles with JWT authentication

Customer accounts or guest checkout

Unit testing for core services and business logic



---

🛠️ Tech Stack

ASP.NET Core Web API with API Controllers

Service-Driven Design with Clean Architecture

Entity Framework Core – database access

MediatR – CQRS and request/response handling

Serilog – structured logging

FluentValidation – input validation

AutoMapper – object mapping

JWT Bearer Tokens – authentication & role-based authorization

xUnit / NUnit – unit testing framework



---

🏗️ Architecture

The solution follows Clean Architecture with clear separation of concerns:



Presentation Layer → API Controllers

Application Layer → Services, MediatR, Validation, Mapping

Domain Layer → Entities, Business Rules, Service-Driven Design

Infrastructure Layer → EF Core, Serilog, JWT, Database, External Services

shared layer for avoid forbiden references 

---

✅ Unit Testing

Core business rules are tested with xUnit (or NUnit)

Mocking dependencies using Moq

Test coverage includes:

Services (business logic)

Validation rules

Authorization/role checks




---

📦 Getting Started

Prerequisites

.NET 8 SDK

SQL Server (or SQLite for dev)


Installation

git clone https://github.com/your-username/ecommerce-platform.git
cd ecommerce-platform/src
dotnet restore
dotnet build

Run Migrations

dotnet ef database update

Run the API

dotnet run --project WebApi

Run Unit Tests

dotnet test


---

🤝 Contributing

Contributions, issues, and feature requests are welcome!
Feel free to fork the repo and submit PRs.


---

📄 License

This project is licensed under the MIT License.

