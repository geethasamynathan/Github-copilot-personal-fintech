# ASP.NET Core Fundamentals with GitHub Copilot

## API Generation, Repository Pattern, and Entity Framework Core

## Small E-Commerce API Tutorial using VS Code and GitHub Copilot Auto Mode

This document is a trainer-ready tutorial for using **GitHub Copilot in VS Code Auto mode** to build an **ASP.NET Core Web API for a small e-commerce application** with:

```text
ASP.NET Core Fundamentals
API Generation using Copilot
Repository Pattern
Entity Framework Core
SQL Server database
```

---

# 1. Project Goal

We are going to create an ASP.NET Core Web API for a small e-commerce system.

The API will manage:

```text
1. Products
2. Categories
3. Customers
4. Orders
5. Order items
```

For the first implementation, we will focus mainly on:

```text
Product API
Category API
Repository Pattern
Entity Framework Core
SQL Server database
```

---

# 2. What is ASP.NET Core?

**ASP.NET Core** is Microsoft’s modern framework for building web applications, REST APIs, microservices, and backend services.

ASP.NET Core fundamentals include concepts like:

```text
Program.cs
Dependency Injection
Middleware
Configuration
Controllers
Routing
Model Binding
Validation
HTTP status codes
Entity Framework Core integration
```

Trainer explanation:

> ASP.NET Core is the foundation for building modern .NET web applications and APIs. In API development, it receives HTTP requests, executes application logic, and returns HTTP responses.

---

# 3. What is ASP.NET Core Web API?

ASP.NET Core Web API is used to build HTTP services that can be consumed by:

```text
React frontend
Angular frontend
Mobile applications
Desktop applications
Other backend services
Third-party integrations
```

Example API endpoints:

```text
GET    /api/products
GET    /api/products/1
POST   /api/products
PUT    /api/products/1
DELETE /api/products/1
```

Trainer explanation:

> ASP.NET Core Web API receives HTTP requests, sends them to controller actions, executes business or data logic, and returns HTTP responses such as 200 OK, 201 Created, 404 Not Found, or 400 Bad Request.

---

# 4. What is GitHub Copilot’s role here?

GitHub Copilot helps us generate and understand code faster.

In this project, we will use Copilot to generate:

```text
1. Project rules
2. Models
3. DbContext
4. DTOs
5. Repository interfaces
6. Repository implementations
7. Controllers
8. Entity Framework Core setup
9. Validation
10. Test prompts
```

Trainer explanation:

> Copilot is not replacing the developer. Copilot helps generate code faster, but the developer must know the architecture and review whether the generated code is correct.

---

# 5. What is Copilot Auto Mode?

In VS Code Copilot Chat, you can choose a model from the model selector.

For this tutorial, choose:

```text
Auto
```

Trainer explanation:

> Auto mode lets Copilot select an appropriate available model for the task. We control the output quality using good prompts, project instructions, context variables, and clear file references.

---

# 6. What is Repository Pattern?

The **Repository Pattern** is a design pattern used to separate data access logic from business/API logic.

Without repository pattern:

```text
Controller directly talks to DbContext
Controller becomes heavy
Testing becomes difficult
Database logic is scattered
```

With repository pattern:

```text
Controller → Repository Interface → Repository Implementation → DbContext → Database
```

Example:

```text
ProductsController
        ↓
IProductRepository
        ↓
ProductRepository
        ↓
AppDbContext
        ↓
SQL Server
```

Trainer explanation:

> Repository Pattern makes the application clean, testable, and maintainable. Controllers should not directly contain database query logic.

---

# 7. What is Entity Framework Core?

**Entity Framework Core**, or **EF Core**, is Microsoft’s object-relational mapper for .NET.

It allows us to work with database tables using C# classes.

Example:

```csharp
public DbSet<Product> Products { get; set; }
```

Instead of writing SQL manually for every operation, we can write:

```csharp
var products = await _context.Products.ToListAsync();
```

Trainer explanation:

> EF Core maps C# classes to database tables. It reduces the need to manually write SQL for every CRUD operation.

---

# 8. What are EF Core Migrations?

EF Core migrations help keep the database schema in sync with your C# model classes.

Example:

```text
Add Product model
Create migration
Apply migration
Database table is created
```

Common commands:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Trainer explanation:

> Migration is like a version history of database structure. When your model changes, migration helps update the database structure.

---

# 9. Project Architecture

We will create this structure:

```text
ECommerceApi
│
├── Controllers
│   ├── ProductsController.cs
│   └── CategoriesController.cs
│
├── Data
│   └── AppDbContext.cs
│
├── DTOs
│   ├── ProductCreateDto.cs
│   ├── ProductUpdateDto.cs
│   ├── ProductResponseDto.cs
│   ├── CategoryCreateDto.cs
│   └── CategoryResponseDto.cs
│
├── Models
│   ├── Product.cs
│   ├── Category.cs
│   ├── Customer.cs
│   ├── Order.cs
│   └── OrderItem.cs
│
├── Repositories
│   ├── IProductRepository.cs
│   ├── ProductRepository.cs
│   ├── ICategoryRepository.cs
│   └── CategoryRepository.cs
│
├── Exceptions
│   └── NotFoundException.cs
│
├── Program.cs
└── appsettings.json
```

---

# 10. Request Flow

The request flow will be:

```text
Client / Swagger / React
        ↓
Controller
        ↓
Repository Interface
        ↓
Repository Implementation
        ↓
AppDbContext
        ↓
SQL Server Database
```

Example:

```text
GET /api/products
        ↓
ProductsController.GetAllProducts()
        ↓
IProductRepository.GetAllAsync()
        ↓
ProductRepository.GetAllAsync()
        ↓
AppDbContext.Products.ToListAsync()
        ↓
Return 200 OK with products
```

---

# 11. Step-by-Step Implementation in VS Code with Copilot

## Step 1: Create ASP.NET Core Web API project

Open VS Code terminal:

```bash
dotnet new webapi --use-controllers -n ECommerceApi
cd ECommerceApi
code .
```

Trainer explanation:

> We are using controller-based Web API because it is easier to explain API generation, repository pattern, and layered architecture to cohorts.

---

## Step 2: Add EF Core packages

For SQL Server:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

Install EF CLI tool if not already installed:

```bash
dotnet tool install --global dotnet-ef
```

Or update it:

```bash
dotnet tool update --global dotnet-ef
```

---

## Step 3: Create project folders

Create these folders:

```text
Models
Data
DTOs
Repositories
Exceptions
Controllers
```

You can ask Copilot:

```text
@workspace

Create a clean folder structure for an ASP.NET Core Web API e-commerce project.

Folders required:
- Models
- Data
- DTOs
- Repositories
- Exceptions
- Controllers

Explain the purpose of each folder.
```

---

# 12. Add Copilot Repository Instructions

Create:

```text
.github/copilot-instructions.md
```

Prompt to Copilot:

```text
@workspace

Create repository-wide GitHub Copilot instructions for this ASP.NET Core Web API project.

Project:
Small E-Commerce API using ASP.NET Core, Entity Framework Core, SQL Server, Repository Pattern, and DTOs.

Rules:
- Use controller-based Web API.
- Use Repository Pattern.
- Controllers must be thin.
- Controllers should not directly use AppDbContext.
- Database logic must be inside repositories.
- Use async and await.
- Use DTOs for request and response.
- Use proper HTTP status codes.
- Use SQL Server with EF Core.
- Use PascalCase for C# classes and properties.
- Use interfaces for repositories.
- Register repositories in Program.cs.
- Mention file names clearly when generating code.
```

Expected `.github/copilot-instructions.md`:

```md
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
```

---

# 13. Create Entity Models using Copilot

## Prompt 1: Generate all models

Use this prompt in Copilot Chat Auto mode:

```text
@workspace

Generate entity models for a small e-commerce ASP.NET Core Web API.

Create these files:
- Models/Category.cs
- Models/Product.cs
- Models/Customer.cs
- Models/Order.cs
- Models/OrderItem.cs

Requirements:
- Category has CategoryId, CategoryName, Description, Products.
- Product has ProductId, ProductName, Description, Price, StockQuantity, CategoryId, Category.
- Customer has CustomerId, FullName, Email, MobileNumber, Address, Orders.
- Order has OrderId, CustomerId, Customer, OrderDate, OrderStatus, TotalAmount, OrderItems.
- OrderItem has OrderItemId, OrderId, Order, ProductId, Product, Quantity, UnitPrice, LineTotal.
- Use proper navigation properties.
- Use decimal for money.
- Use ICollection for child collections.
- Follow repository instructions.
```

## Expected Product model

```csharp
namespace ECommerceApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
```

## Expected Category model

```csharp
namespace ECommerceApi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
```

Trainer explanation:

> Models represent database tables. EF Core uses these classes to create or map database tables.

---

# 14. Create AppDbContext using Copilot

## Prompt 2: Generate DbContext

```text
@workspace

Create Data/AppDbContext.cs for this ASP.NET Core e-commerce API.

Use these models:
#file:Models/Product.cs
#file:Models/Category.cs
#file:Models/Customer.cs
#file:Models/Order.cs
#file:Models/OrderItem.cs

Requirements:
- Inherit from DbContext.
- Add DbSet for Products, Categories, Customers, Orders, and OrderItems.
- Configure Product to Category relationship.
- Configure Order to Customer relationship.
- Configure OrderItem to Order relationship.
- Configure OrderItem to Product relationship.
- Configure decimal precision for Price, UnitPrice, LineTotal, and TotalAmount.
- Use OnModelCreating.
```

## Expected AppDbContext

```csharp
using ECommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(product => product.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .Property(order => order.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(orderItem => orderItem.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(orderItem => orderItem.LineTotal)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Category>()
                .HasMany(category => category.Products)
                .WithOne(product => product.Category)
                .HasForeignKey(product => product.CategoryId);

            modelBuilder.Entity<Customer>()
                .HasMany(customer => customer.Orders)
                .WithOne(order => order.Customer)
                .HasForeignKey(order => order.CustomerId);

            modelBuilder.Entity<Order>()
                .HasMany(order => order.OrderItems)
                .WithOne(orderItem => orderItem.Order)
                .HasForeignKey(orderItem => orderItem.OrderId);

            modelBuilder.Entity<Product>()
                .HasMany<OrderItem>()
                .WithOne(orderItem => orderItem.Product)
                .HasForeignKey(orderItem => orderItem.ProductId);
        }
    }
}
```

Trainer explanation:

> AppDbContext is the bridge between C# classes and the SQL Server database.

---

# 15. Configure SQL Server Connection

Open:

```text
appsettings.json
```

Add:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=SmallECommerceDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

For your machine, if SQL Server instance is:

```text
LAPTOP-0TBPBTEL\SQLEXPRESS
```

Use:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=LAPTOP-0TBPBTEL\\SQLEXPRESS;Database=SmallECommerceDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Trainer explanation:

> In JSON, one backslash must be escaped as double backslash. That is why `SQLEXPRESS` is written as `\\SQLEXPRESS` in appsettings.json.

---

# 16. Configure Program.cs

## Prompt 3: Update Program.cs

```text
@workspace

Update #file:Program.cs for this ASP.NET Core Web API.

Requirements:
- Register AppDbContext using SQL Server.
- Read DefaultConnection from appsettings.json.
- Add controllers.
- Add Swagger/OpenAPI.
- Register repository interfaces and implementations.
- Use HTTPS redirection.
- Map controllers.
- Follow current ASP.NET Core style.
```

## Expected Program.cs

```csharp
using ECommerceApi.Data;
using ECommerceApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
```

Trainer explanation:

> Program.cs is the application startup file. It registers services, EF Core, repositories, controllers, Swagger, and middleware.

---

# 17. Create DTOs using Copilot

DTO means **Data Transfer Object**.

Why use DTOs?

```text
1. Avoid exposing database entity directly
2. Control request and response shape
3. Improve security
4. Add validation separately
5. Avoid circular references in API response
```

## Prompt 4: Generate Product DTOs

```text
@workspace

Create Product DTOs for the e-commerce API.

Create these files:
- DTOs/ProductCreateDto.cs
- DTOs/ProductUpdateDto.cs
- DTOs/ProductResponseDto.cs

Requirements:
- ProductCreateDto should contain ProductName, Description, Price, StockQuantity, CategoryId.
- ProductUpdateDto should contain ProductName, Description, Price, StockQuantity, CategoryId.
- ProductResponseDto should contain ProductId, ProductName, Description, Price, StockQuantity, CategoryId, CategoryName.
- Add validation attributes where required.
- ProductName is required.
- Price must be greater than zero.
- StockQuantity cannot be negative.
```

## Expected ProductCreateDto

```csharp
using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        public string ProductName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative.")]
        public int StockQuantity { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
```

## Expected ProductResponseDto

```csharp
namespace ECommerceApi.DTOs
{
    public class ProductResponseDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;
    }
}
```

---

# 18. Create Repository Interface

## Prompt 5: Generate IProductRepository

```text
@workspace

Create Repositories/IProductRepository.cs.

Requirements:
- Use Product model.
- Add async methods:
  - GetAllAsync
  - GetByIdAsync
  - CreateAsync
  - UpdateAsync
  - DeleteAsync
  - ExistsAsync
- Do not include business logic.
- Follow repository pattern.
```

## Expected IProductRepository

```csharp
using ECommerceApi.Models;

namespace ECommerceApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int productId);

        Task<Product> CreateAsync(Product product);

        Task<Product?> UpdateAsync(Product product);

        Task<bool> DeleteAsync(int productId);

        Task<bool> ExistsAsync(int productId);
    }
}
```

Trainer explanation:

> Interface defines what operations are available. It does not define how the database work is done.

---

# 19. Create Repository Implementation

## Prompt 6: Generate ProductRepository

```text
@workspace

Create Repositories/ProductRepository.cs.

Use:
#file:Data/AppDbContext.cs
#file:Models/Product.cs
#file:Repositories/IProductRepository.cs

Requirements:
- Implement IProductRepository.
- Use AppDbContext.
- Use async and await.
- Use Include to load Category when getting products.
- GetAllAsync should return products with category.
- GetByIdAsync should return product with category.
- CreateAsync should add and save.
- UpdateAsync should update existing product.
- DeleteAsync should delete product by id.
- ExistsAsync should check product existence.
- Do not use DTOs inside repository.
```

## Expected ProductRepository

```csharp
using ECommerceApi.Data;
using ECommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(product => product.Category)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await _context.Products
                .Include(product => product.Category)
                .FirstOrDefaultAsync(product => product.ProductId == productId);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product?> UpdateAsync(Product product)
        {
            var existingProduct = await _context.Products
                .FirstOrDefaultAsync(item => item.ProductId == product.ProductId);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.ProductName = product.ProductName;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;
            existingProduct.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();

            return existingProduct;
        }

        public async Task<bool> DeleteAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExistsAsync(int productId)
        {
            return await _context.Products.AnyAsync(product => product.ProductId == productId);
        }
    }
}
```

Trainer explanation:

> Repository uses AppDbContext. Controller should never write these database queries directly.

---

# 20. Create API Controller using Copilot

## Prompt 7: Generate ProductsController

```text
@workspace

Create Controllers/ProductsController.cs.

Use:
#file:Repositories/IProductRepository.cs
#file:DTOs/ProductCreateDto.cs
#file:DTOs/ProductUpdateDto.cs
#file:DTOs/ProductResponseDto.cs
#file:Models/Product.cs

Requirements:
- Use [ApiController].
- Route should be api/products.
- Inject IProductRepository.
- Add endpoints:
  - GET api/products
  - GET api/products/{id}
  - POST api/products
  - PUT api/products/{id}
  - DELETE api/products/{id}
- Use DTOs for request and response.
- Do not expose Product entity directly.
- Return proper HTTP status codes.
- Use CreatedAtAction for POST.
- Return NotFound when product does not exist.
- Return BadRequest when id mismatch in PUT.
- Keep controller thin.
```

## Expected ProductsController

```csharp
using ECommerceApi.DTOs;
using ECommerceApi.Models;
using ECommerceApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();

            var response = products.Select(product => new ProductResponseDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.CategoryName ?? string.Empty
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound($"Product with id {id} was not found.");
            }

            var response = new ProductResponseDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.CategoryName ?? string.Empty
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponseDto>> CreateProduct(ProductCreateDto productCreateDto)
        {
            var product = new Product
            {
                ProductName = productCreateDto.ProductName,
                Description = productCreateDto.Description,
                Price = productCreateDto.Price,
                StockQuantity = productCreateDto.StockQuantity,
                CategoryId = productCreateDto.CategoryId
            };

            var createdProduct = await _productRepository.CreateAsync(product);

            var response = new ProductResponseDto
            {
                ProductId = createdProduct.ProductId,
                ProductName = createdProduct.ProductName,
                Description = createdProduct.Description,
                Price = createdProduct.Price,
                StockQuantity = createdProduct.StockQuantity,
                CategoryId = createdProduct.CategoryId,
                CategoryName = createdProduct.Category?.CategoryName ?? string.Empty
            };

            return CreatedAtAction(
                nameof(GetProductById),
                new { id = createdProduct.ProductId },
                response
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            if (!await _productRepository.ExistsAsync(id))
            {
                return NotFound($"Product with id {id} was not found.");
            }

            var product = new Product
            {
                ProductId = id,
                ProductName = productUpdateDto.ProductName,
                Description = productUpdateDto.Description,
                Price = productUpdateDto.Price,
                StockQuantity = productUpdateDto.StockQuantity,
                CategoryId = productUpdateDto.CategoryId
            };

            await _productRepository.UpdateAsync(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var isDeleted = await _productRepository.DeleteAsync(id);

            if (!isDeleted)
            {
                return NotFound($"Product with id {id} was not found.");
            }

            return NoContent();
        }
    }
}
```

Trainer explanation:

> Controller receives HTTP requests and returns HTTP responses. It should not contain database query logic.

---

# 21. Create Category Repository and Controller

## Prompt 8: Generate Category API

```text
@workspace

Generate Category API for this e-commerce project.

Create or update:
- DTOs/CategoryCreateDto.cs
- DTOs/CategoryResponseDto.cs
- Repositories/ICategoryRepository.cs
- Repositories/CategoryRepository.cs
- Controllers/CategoriesController.cs

Requirements:
- Follow the same pattern used by ProductsController and ProductRepository.
- Add GET all, GET by id, POST, PUT, DELETE.
- Use DTOs.
- Use async and await.
- Keep controller thin.
- Do not expose Category entity directly.
```

Trainer note:

> After generating Product API, ask Copilot to follow the same pattern for Category API. This shows how Copilot can reuse existing workspace pattern.

---

# 22. Create and Apply EF Core Migration

Run:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

If terminal error occurs, use Copilot:

```text
@workspace /fix

Use #terminalLastCommand.

I got an error while running EF Core migration.
Check:
#file:Program.cs
#file:Data/AppDbContext.cs
#file:appsettings.json

Explain the root cause and give the fix.
```

---

# 23. Run the API

Run:

```bash
dotnet run
```

Open Swagger URL shown in terminal, usually:

```text
https://localhost:<port>/swagger
```

Test endpoints:

```text
GET    /api/products
POST   /api/products
GET    /api/products/{id}
PUT    /api/products/{id}
DELETE /api/products/{id}
```

---

# 24. Sample POST Request

In Swagger, use this JSON:

```json
{
  "productName": "Wireless Mouse",
  "description": "Ergonomic wireless mouse",
  "price": 799.00,
  "stockQuantity": 50,
  "categoryId": 1
}
```

---

# 25. Context Variables to Use in GitHub Copilot

Use these context variables:

| Context Variable | Use |
|---|---|
| `@workspace` | Use complete project context |
| `#file` | Point Copilot to a specific file |
| `#selection` | Explain or fix selected code |
| `#terminalLastCommand` | Use latest terminal command or error |
| `#problems` | Use VS Code Problems panel |
| `#changes` | Review current Git changes |
| `#codebase` | Use broader codebase context if available |

---

# 26. Best Copilot Prompts for This Project

## Prompt A: Full project planning prompt

```text
@workspace /plan

Plan an ASP.NET Core Web API for a small e-commerce application.

Requirements:
- Use controller-based Web API.
- Use Entity Framework Core with SQL Server.
- Use Repository Pattern.
- Use DTOs.
- Keep controllers thin.
- Add Product and Category APIs first.
- Add models for Product, Category, Customer, Order, and OrderItem.
- Add AppDbContext.
- Register DbContext and repositories in Program.cs.
- Use async and await.
- Use proper HTTP status codes.
- Explain the file structure.
- Do not write code yet.
```

---

## Prompt B: Full implementation prompt

Use after planning:

```text
@workspace

Implement the planned ASP.NET Core Web API for the small e-commerce application.

Create or update:
- Models/Category.cs
- Models/Product.cs
- Models/Customer.cs
- Models/Order.cs
- Models/OrderItem.cs
- Data/AppDbContext.cs
- DTOs/ProductCreateDto.cs
- DTOs/ProductUpdateDto.cs
- DTOs/ProductResponseDto.cs
- DTOs/CategoryCreateDto.cs
- DTOs/CategoryResponseDto.cs
- Repositories/IProductRepository.cs
- Repositories/ProductRepository.cs
- Repositories/ICategoryRepository.cs
- Repositories/CategoryRepository.cs
- Controllers/ProductsController.cs
- Controllers/CategoriesController.cs
- Program.cs
- appsettings.json

Rules:
- Use ASP.NET Core controller-based Web API.
- Use EF Core with SQL Server.
- Use Repository Pattern.
- Controllers must not directly use AppDbContext.
- Repositories should use AppDbContext.
- Use DTOs for request and response.
- Use async and await.
- Use proper HTTP status codes.
- Use CreatedAtAction after POST.
- Do not expose entity objects directly from controllers.
- Do not modify unrelated files.
```

---

## Prompt C: Generate only Product API

```text
@workspace

Generate Product API only for this ASP.NET Core e-commerce project.

Use:
#file:Models/Product.cs
#file:Models/Category.cs
#file:Data/AppDbContext.cs

Create:
- DTOs/ProductCreateDto.cs
- DTOs/ProductUpdateDto.cs
- DTOs/ProductResponseDto.cs
- Repositories/IProductRepository.cs
- Repositories/ProductRepository.cs
- Controllers/ProductsController.cs

Rules:
- Use Repository Pattern.
- Use EF Core.
- Use DTOs.
- Use async and await.
- Keep controller thin.
- Return proper HTTP status codes.
```

---

## Prompt D: Generate EF Core migration help

```text
@workspace

Explain how to create EF Core migration for this project.

Use:
#file:Program.cs
#file:Data/AppDbContext.cs
#file:appsettings.json

Give exact terminal commands to:
1. Add migration
2. Apply migration
3. Verify database in SQL Server
```

---

## Prompt E: Fix migration error

```text
@workspace /fix

Use #terminalLastCommand.

I got an EF Core migration error.

Check:
#file:Program.cs
#file:Data/AppDbContext.cs
#file:appsettings.json
#file:ECommerceApi.csproj

Find the root cause and give corrected code or command.
```

---

## Prompt F: Generate tests

```text
@workspace /tests

Create unit test scenarios for ProductsController and ProductRepository.

Use:
#file:Controllers/ProductsController.cs
#file:Repositories/IProductRepository.cs
#file:Repositories/ProductRepository.cs
#file:DTOs/ProductCreateDto.cs
#file:DTOs/ProductUpdateDto.cs

Cover:
1. Get all products returns 200 OK.
2. Get product by valid id returns product.
3. Get product by invalid id returns 404.
4. Create product returns 201 Created.
5. Create product with invalid price returns validation error.
6. Delete product returns 204 when product exists.
7. Delete product returns 404 when product does not exist.
```

---

# 27. Common Copilot Mistakes and Trainer Corrections

## Mistake 1: Copilot puts DbContext inside Controller

Bad:

```csharp
private readonly AppDbContext _context;
```

inside controller.

Correction prompt:

```text
@workspace /fix

Refactor #file:Controllers/ProductsController.cs.

Problem:
Controller is directly using AppDbContext.

Requirement:
Controller must use IProductRepository.
Database logic must be moved to ProductRepository.
Keep controller thin.
```

---

## Mistake 2: Copilot returns entity directly

Bad:

```csharp
return Ok(product);
```

Correction prompt:

```text
@workspace /fix

Fix #file:Controllers/ProductsController.cs.

Do not expose Product entity directly.
Map Product entity to ProductResponseDto before returning response.
```

---

## Mistake 3: Copilot forgets repository registration

Error:

```text
Unable to resolve service for type IProductRepository
```

Correction prompt:

```text
@workspace /fix

Use #terminalLastCommand.

Fix dependency injection error.
Check:
#file:Program.cs
#file:Repositories/IProductRepository.cs
#file:Repositories/ProductRepository.cs

Register repository correctly in Program.cs.
```

---

## Mistake 4: EF migration fails due to connection string

Correction prompt:

```text
@workspace /fix

EF Core migration failed due to SQL Server connection issue.

Check:
#file:appsettings.json
#file:Program.cs

Give correct SQL Server connection string format for SQLEXPRESS using Windows Authentication.
```

---

# 28. How to Explain This to Cohorts

Use this teaching flow:

```text
Step 1: Explain ASP.NET Core request flow.
Step 2: Explain EF Core and DbContext.
Step 3: Explain Repository Pattern.
Step 4: Create models using Copilot.
Step 5: Create DbContext using Copilot.
Step 6: Create DTOs using Copilot.
Step 7: Create repository interface and implementation using Copilot.
Step 8: Create controller using Copilot.
Step 9: Register services in Program.cs.
Step 10: Run migration.
Step 11: Test API in Swagger.
Step 12: Use Copilot to fix errors.
```

---

# 29. Final Trainer Summary

```text
ASP.NET Core Web API
Receives HTTP requests and returns HTTP responses.

Entity Framework Core
Maps C# classes to database tables and performs database operations.

DbContext
Main EF Core class that connects models to the database.

Repository Pattern
Separates database logic from controllers.

DTO
Controls request and response shape.

GitHub Copilot
Helps generate code faster when prompts are clear and context is correct.
```

Final classroom line:

> Copilot should not replace architecture knowledge. The developer must know ASP.NET Core fundamentals, Repository Pattern, and EF Core. Copilot helps generate code faster, but the developer must review whether the generated code follows the correct architecture.
