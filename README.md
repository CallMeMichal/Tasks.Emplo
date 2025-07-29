## 🚀 Tech Stack

### **Backend Framework**
- **ASP.NET Core 9.0** - Modern web framework for building REST APIs
- **C# 13** - Latest version of C# programming language

### **Database & ORM**
- **Entity Framework Core 9.0** - Object-Relational Mapping for database management
- **In-Memory Database** - In-memory database for testing and development
- **Entity Framework Core Proxies** - Lazy loading for automatic related data loading

### **Architecture & Patterns**
- **Repository Pattern** - Data access abstraction layer
- **Service Layer Pattern** - Business logic separated from controllers
- **Dependency Injection** - Built-in DI container of ASP.NET Core
- **DTO Pattern** - Data Transfer Objects for API responses

### **API Documentation**
- **Swagger/OpenAPI** - Automatic API documentation
- **Swashbuckle.AspNetCore** - Swagger UI generator

### **Testing Framework**
- **xUnit** - Unit testing framework
- **Moq** - Mocking framework for unit tests
- **Microsoft.NET.Test.Sdk** - Test SDK
- **coverlet.collector** - Code coverage analysis

### **Development Tools**
- **Visual Studio 2022** / **VS Code** - Recommended IDEs
- **Git** - Version control
- **GitHub** - Repository hosting

---
```
## 🏗️ Project Structure
📁 Solution 'Tasks.Emplo' (3 projects)
├── 📁 Task1.Emplo/              # Task 1 - Employee hierarchy structure
├── 📁 Task2.Emplo/              # Task 2 - Vacation management system (main)
│   ├── Controllers/             # API endpoints
│   ├── Services/               # Business logic layer
│   ├── Repositories/           # Data access layer
│   ├── Models/
│   │   ├── Database/           # Entity Framework models
│   │   └── DTO/                # Data Transfer Objects
│   ├── Interfaces/             # Service contracts
│   └── Program.cs              # Application entry point
└── 📁 Tests.Emplo/             # Unit tests project
└── UnitTest1.cs            # Test cases
```
---

## 🗃️ Database Schema

### **Entities**
| Entity | Description |
|--------|-------------|
| **Employee** | Employee information with team and vacation package references |
| **Team** | Team structure (.NET, Java, Frontend, DevOps) |
| **VacationPackage** | Vacation entitlements by role and year |
| **Vacation** | Individual vacation requests and usage |

### **Relationships**
Employee → Team (Many-to-One)
Employee → VacationPackage (Many-to-One)
Employee → Vacations (One-to-Many)

---

## 📦 NuGet Packages
- `Microsoft.AspNetCore.OpenApi (9.0.0)`
- `Microsoft.EntityFrameworkCore.InMemory (9.0.0)`
- `Microsoft.EntityFrameworkCore.Proxies (9.0.0)`
- `Swashbuckle.AspNetCore (6.8.1)`

---

**Built with ❤️ using .NET 9.0** 🎯
