[![.NET Core](https://github.com/ardalis/CleanArchitecture/workflows/.NET%20Core/badge.svg)](https://dotnet.microsoft.com/en-us/apps/aspnet)
[![Ardalis.CleanArchitecture.Template on NuGet](https://img.shields.io/nuget/v/Ardalis.CleanArchitecture.Template?label=Ardalis.CleanArchitecture.Template)](https://www.nuget.org/packages/Ardalis.CleanArchitecture.Template/)

# Introductions

This is a Back-End test project for a [job](https://ddfinance.com/jobs/dev/) opening at [DDFinance](https://ddfinance.com/). It is an ASP.NET Core project based off of [Clean Architecture](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html). A Domain Driven, loosely-coupled and dependency-inverted design architecture.

However, while this project applies the Clean Architecture template, it only applies the three main layers out of the four that are synonimous with the design. These layers include, the `DDFinancePolicy.Web` layer, the `DDFinancePolicy.Core` layer and the `DDFinancePolicy.Infrastructure` layer

## Table Of Contents

- [Introduction](#introductions)
  - [Table Of Contents](#table-of-contents)
- [Project Properties](#project-propertise)
  - [.NET Version](#net-version)
  - [APIs](#apis)
  - [The Core Project](#the-core-project-ddfinancepolicycore)
  - [The Infrastructure Project](#the-infrastructure-project-ddfinancepolicyinfrastructure)
  - [The Web Project](#the-web-project-ddfinancepolicyweb)
  - [The SharedKernel Project](#the-sharedkernel-package)
  - [The Test Projects](#the-test-projects)
- [Patterns Used](#patterns-used)
  - [Domain Events](#domain-events)
  - [Related Projects](#related-projects)

# Project Propertise

## .NET Version

The project is using **.NET 9** which corresponds to the lates template version 10.x.

## APIs

This solution only has support for API Endpoints using the [FastEndpoints](https://fast-endpoints.com/) library.

## The Core Project (`DDFinancePolicy.Core`)

The Core project is the center of the design, and all other project dependencies point toward it. As such, it has very few external dependencies. The Core project include the Domain Model including the following:

- Entities
- Aggregates
- Value Objects
- Domain Events
- Domain Event Handlers
- Domain Services
- Specifications
- Interfaces
- DTOs

The central focus here is on Entities and business rules and since this is a Domain-Driven Design, this is therefore the Domain Model.

Entities that are related and change together are grouped into an Aggregate employing encapsulation and minimize public setters. They can leverage Domain Events to communicate changes to other parts of the system.

Entities define Specifications that can be used to query for them and for mutable access, Entities are accessed through a Repository interface.

Read-only ad hoc queries use separate Query Services that don't use the Domain Model.

## The Infrastructure Project (`DDFinancePolicy.Infrastructure`)

Most of your application's dependencies on external resources are implemented in classes defined in this project. These classes implement interfaces defined in Core. The project includes data access and domain event implementations, but you would also include things like email providers, file access, web api clients, etc. so they're not adding coupling to the Core or UI projects.

## The Web Project (`DDFinancePolicy.Web`)

The entry point of the application is the ASP.NET Core web project. This is actually a console application, with a `public static void Main` method in `Program.cs`. It leverages [FastEndpoints](https://fast-endpoints.com/) and the REPR pattern to organize the API endpoints.

## The SharedKernel Package

A [Shared Kernel](https://deviq.com/domain-driven-design/shared-kernel) is used to share common elements between bounded contexts.

## The Test Projects

The test projects are organized based on the kind of test, with unit, functional and integration test projects existing in this solution. The testing is however not extensive owing to the goal of the project.

# Patterns Used

The solution has code built in to support a few common patterns, especially Domain-Driven Design patterns. Here is a brief overview of how a few of them work.

## Domain Events

Domain events are a great pattern for decoupling a trigger for an operation from its implementation. This is especially useful from within domain entities since the handlers of the events can have dependencies while the entities themselves typically do not.

## Related Projects

- [GuardClauses](https://github.com/ardalis/guardclauses)
- [HttpClientTestExtensions](https://github.com/ardalis/HttpClientTestExtensions)
- [Result](https://github.com/ardalis/result)
- [SharedKernel](https://github.com/ardalis/Ardalis.SharedKernel)
- [SmartEnum](https://github.com/ardalis/SmartEnum)
- [Specification](https://github.com/ardalis/specification)
- [FastEndpoints](https://fast-endpoints.com/)

