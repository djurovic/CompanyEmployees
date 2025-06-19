# ASP.NET Core Web API - Complete Implementation Guide

A comprehensive ASP.NET Core Web API project implementing enterprise-level patterns and best practices.

## 📋 Table of Contents

- [Project Overview](#project-overview)
- [Architecture](#architecture)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Configuration](#configuration)
- [Implementation Details](#implementation-details)
- [API Documentation](#api-documentation)
- [Deployment](#deployment)
- [Performance Optimizations](#performance-optimizations)

## 🎯 Project Overview

This project demonstrates a complete ASP.NET Core Web API implementation following enterprise patterns and best practices. It covers everything from basic CRUD operations to advanced concepts like CQRS, JWT authentication, caching, and API versioning.

## 🏗️ Architecture

The project implements **Onion Architecture** with clear separation of concerns:

- **Presentation Layer**: Controllers and API endpoints
- **Service Layer**: Business logic and application services
- **Repository Layer**: Data access abstraction
- **Domain Layer**: Entities and core business models
- **Infrastructure Layer**: External concerns (database, logging, etc.)

### Advantages of Onion Architecture
- High testability and maintainability
- Loose coupling between layers
- Dependency inversion principle
- Framework independence

## ✨ Features

### Core Functionality
- **CRUD Operations**: Complete Create, Read, Update, Delete operations
- **RESTful Design**: Following REST principles and conventions
- **Entity Relationships**: Parent/child resource management
- **Global Error Handling**: Centralized exception management
- **Content Negotiation**: Support for multiple media types

### Advanced Features
- **Authentication & Authorization**: JWT-based security with refresh tokens
- **Role-Based Access Control**: User roles and permissions
- **API Versioning**: Multiple versioning strategies
- **Caching**: Response caching and cache validation
- **Rate Limiting**: Request throttling and rate limiting
- **HATEOAS**: Hypermedia as the Engine of Application State
- **Data Shaping**: Dynamic field selection
- **Filtering & Searching**: Advanced query capabilities
- **Sorting & Paging**: Result set manipulation
- **Validation**: Comprehensive input validation
- **Asynchronous Programming**: Non-blocking operations
- **Action Filters**: Cross-cutting concerns
- **Swagger Documentation**: Interactive API documentation

### Performance & Scalability
- **Asynchronous Operations**: All database operations are async
- **Response Optimization**: Efficient data transfer
- **Caching Strategies**: Multiple caching approaches
- **Rate Limiting**: Protection against abuse

## 🔧 Prerequisites

- .NET 6.0 SDK or later
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code
- Postman (for API testing)

## 🚀 Getting Started

### 1. Clone the Repository
```bash
git clone <repository-url>
cd <project-directory>
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Database Setup
```bash
# Update database connection string in appsettings.json
# Run migrations
dotnet ef database update
```

### 4. Run the Application
```bash
dotnet run
```

The API will be available at `https://localhost:5001` (HTTPS) and `http://localhost:5000` (HTTP).

## 📁 Project Structure

```
├── CompanyEmployees/              # Main API project
│   ├── Controllers/              # API controllers
│   ├── Extensions/               # Extension methods
│   ├── Filters/                  # Action filters
│   ├── Middleware/               # Custom middleware
│   └── Program.cs               # Application entry point
├── CompanyEmployees.Service/      # Service layer
│   ├── Contracts/               # Service interfaces
│   └── Services/                # Service implementations
├── CompanyEmployees.Repository/   # Data access layer
│   ├── Contracts/               # Repository interfaces
│   └── Repositories/            # Repository implementations
├── CompanyEmployees.Entities/     # Domain entities
│   ├── Models/                  # Entity models
│   └── DTOs/                    # Data transfer objects
├── CompanyEmployees.Shared/       # Shared utilities
│   └── DataTransferObjects/     # Shared DTOs
└── LoggerService/                # Logging infrastructure
```

## ⚙️ Configuration

### Launch Settings
The `launchSettings.json` file configures different hosting profiles:

```json
{
  "profiles": {
    "Development": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

### Database Configuration
Connection strings are configured in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CompanyEmployeesDb;Trusted_Connection=true;"
  }
}
```

### Logging Configuration
NLog is configured for structured logging with different targets and levels.

## 🔨 Implementation Details

### 1. Repository Pattern
- Generic repository base class for common operations
- Specific repositories for entity-specific logic
- Repository manager for coordinating multiple repositories

### 2. Service Layer
- Business logic encapsulation
- DTO transformations using AutoMapper
- Validation and error handling

### 3. Authentication & Security
- JWT token-based authentication
- Refresh token implementation
- Role-based authorization
- CORS configuration

### 4. HTTP Methods Implementation
- **GET**: Retrieve resources with filtering, sorting, and paging
- **POST**: Create new resources with validation
- **PUT**: Update existing resources (full replacement)
- **PATCH**: Partial updates using JSON Patch
- **DELETE**: Remove resources with cascade handling
- **OPTIONS**: Discover available methods
- **HEAD**: Get headers without body

### 5. Advanced Querying
- **Paging**: Efficient large dataset handling
- **Filtering**: Dynamic property-based filtering
- **Searching**: Full-text search capabilities
- **Sorting**: Multi-column sorting with direction
- **Data Shaping**: Return only requested fields

### 6. Content Negotiation
- Support for JSON, XML, and custom formats
- Custom formatters for specialized content types
- Media type validation

### 7. Caching Strategy
- Response caching with cache headers
- ETag support for cache validation
- Cache store implementation
- Expiration and validation models

## 📚 API Documentation

The API is documented using Swagger/OpenAPI:

- **Swagger UI**: Available at `/swagger`
- **OpenAPI Spec**: Available at `/swagger/v1/swagger.json`
- **Authentication**: Swagger UI includes JWT authentication support

### Sample Endpoints

```
GET    /api/companies                    # Get all companies
GET    /api/companies/{id}               # Get company by ID
POST   /api/companies                    # Create new company
PUT    /api/companies/{id}               # Update company
PATCH  /api/companies/{id}               # Partial update
DELETE /api/companies/{id}               # Delete company

GET    /api/companies/{id}/employees     # Get employees for company
POST   /api/companies/{id}/employees     # Create employee for company
```

### Query Parameters
- `pageNumber` & `pageSize`: Paging
- `searchTerm`: Search functionality
- `orderBy`: Sorting (e.g., "name desc,age")
- `fields`: Data shaping (e.g., "name,age")
- `minAge` & `maxAge`: Age filtering

## 🚀 Deployment

### IIS Deployment
1. **Publish the Application**:
   ```bash
   dotnet publish -c Release -o ./publish
   ```

2. **Install Hosting Bundle**: Install the .NET Core Hosting Bundle on the target server

3. **Configure IIS**: Set up application pool and website

4. **Environment Configuration**: Set `ASPNETCORE_ENVIRONMENT` appropriately

5. **Database Migration**: Run migrations on production database

### Docker Deployment
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyEmployees.dll"]
```

## ⚡ Performance Optimizations

### Response Performance Improvements
- Implemented response wrapper pattern
- Optimized database queries
- Efficient AutoMapper configuration
- Async/await throughout the application

### Caching Strategies
- Response caching for GET requests
- ETag implementation for cache validation
- Memory caching for frequently accessed data

### Rate Limiting
- Request throttling to prevent abuse
- Configurable rate limits per endpoint
- Client-specific rate limiting

## 📝 Configuration Options

### Environment-Based Settings
- Development: Detailed logging, Swagger UI
- Staging: Reduced logging, performance monitoring
- Production: Minimal logging, security hardening

### Options Pattern
Configuration is bound using the Options pattern:
```csharp
services.Configure<JwtConfiguration>(configuration.GetSection("JwtSettings"));
```


*This project demonstrates enterprise-level ASP.NET Core Web API development with comprehensive coverage of modern patterns and practices.*