# Copilot Instructions for ECommerceApi

## Project Overview

This is an ASP.NET Core Web API project for a small e-commerce application.

## Technology Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Repository Pattern
- DTO-based API design

## Architecture Rules

- Use controller-based Web API.
- Keep controllers thin.
- Do not write database queries directly inside controllers.
- Use repositories for data access.
- Use interfaces for repositories.
- Use DTOs for request and response models.
- Use async and await for database operations.
- Register dependencies in Program.cs.

## Naming Conventions

- Controllers must end with `Controller`.
- Repository interfaces must start with `I`.
- Repository classes must end with `Repository`.
- DTO classes must end with `Dto`.
- Model classes must use PascalCase.
- Properties must use PascalCase.

## API Rules

- Return 200 OK for successful GET.
- Return 201 Created for successful POST.
- Return 204 NoContent for successful DELETE.
- Return 400 BadRequest for validation failures.
- Return 404 NotFound when the record does not exist.

## EF Core Rules

- Use DbContext inside repository classes only.
- Use DbSet properties in AppDbContext.
- Configure relationships clearly.
- Use migrations for schema creation.

## Output Rules

- Mention which file should be created or updated.
- Do not modify unrelated files.
- Explain important code briefly.
