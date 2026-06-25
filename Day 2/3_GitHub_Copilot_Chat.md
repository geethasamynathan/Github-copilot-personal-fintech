# GitHub Copilot Chat — Trainer Notes for Cohorts

## 1. What is Copilot Chat?

**GitHub Copilot Chat** is an AI chat assistant for developers. It allows you to ask coding-related questions and get help inside tools like:

- Visual Studio Code
- Visual Studio
- JetBrains IDEs
- GitHub.com
- GitHub Mobile
- Windows Terminal

In simple words:

> GitHub Copilot Chat is like a coding mentor inside your editor. You can ask it to explain code, generate code, fix errors, write tests, review code, summarize pull requests, and help you understand a project.

---

## 2. Difference Between Copilot Inline Completion and Copilot Chat

| Feature | Inline Code Completion | Copilot Chat |
|---|---|---|
| How it appears | Gray ghost text while typing | Chat window or inline chat |
| Main use | Fast code suggestion | Ask questions and perform coding tasks |
| Example | Suggests next line of code | “Explain this function” |
| Interaction style | Automatic suggestion | Developer asks a prompt |
| Best for | Quick coding | Explanation, debugging, refactoring, tests, architecture help |

### Inline Completion Example

You type:

```javascript
function add(a, b) {
```

Copilot suggests:

```javascript
    return a + b;
}
```

### Copilot Chat Example

You ask:

```text
Explain how this function works.
```

Copilot responds with an explanation.

---

## 3. Where Can You Use Copilot Chat?

### 3.1 In Visual Studio Code

You can open Copilot Chat in VS Code and ask coding questions.

#### Practical Steps

1. Open VS Code.
2. Install GitHub Copilot and GitHub Copilot Chat extensions if needed.
3. Sign in with your GitHub account.
4. Open a project folder.
5. Open Copilot Chat:
   - Windows/Linux: `Ctrl + Alt + I`
   - Inline Chat: `Ctrl + I`
6. Type your question.

#### Example Prompt

```text
Explain this JavaScript function in simple words.
```

#### How Copilot May Respond

```text
This function takes two numbers as input and returns their sum.
For example, if a is 10 and b is 20, the function returns 30.
```

---

### 3.2 In GitHub.com

You can use Copilot Chat on GitHub.com to ask questions about repositories, pull requests, issues, and code.

#### Practical Steps

1. Open GitHub.com.
2. Go to a repository.
3. Open a file, issue, or pull request.
4. Click the Copilot icon.
5. Ask a question.

#### Example Prompt

```text
Summarize this pull request.
```

#### How Copilot May Respond

```text
This pull request adds login validation, updates the authentication controller,
and adds unit tests for invalid username and password cases.
```

---

### 3.3 In Windows Terminal

Copilot Chat can also help with command-line tasks in Windows Terminal, depending on plan and setup.

#### Example Prompt

```text
How do I list all files in the current directory?
```

#### How Copilot May Respond

```powershell
dir
```

or

```bash
ls
```

---

## 4. Main Functionalities of Current GitHub Copilot Chat

GitHub Copilot Chat can help with many coding-related tasks, including:

- Syntax help
- Programming concepts
- Test cases
- Debugging
- Code review
- Documentation
- Pull request summaries
- Terminal commands
- Project understanding

---

## 5. Functionality 1: Ask Coding Questions

### What It Does

You can ask Copilot Chat any programming-related question.

### Example Questions

```text
What is dependency injection in ASP.NET Core?
```

```text
What is the difference between interface and abstract class in C#?
```

```text
Explain async and await in JavaScript.
```

### Real-World Use Case

A fresher is working on an ASP.NET Core Web API and sees this code:

```csharp
builder.Services.AddScoped<IProductService, ProductService>();
```

The student does not understand it.

### Prompt

```text
Explain this line in simple words:
builder.Services.AddScoped<IProductService, ProductService>();
```

### How Copilot May Respond

```text
This line registers ProductService as the implementation of IProductService
in the dependency injection container. Whenever the application needs
IProductService, ASP.NET Core will create and provide an object of ProductService.
The AddScoped lifetime means one object is created per HTTP request.
```

---

## 6. Functionality 2: Explain Existing Code

### What It Does

Copilot Chat can explain selected code in simple words.

### Practical Steps in VS Code

1. Open a code file.
2. Select the code.
3. Open Copilot Chat.
4. Ask:

```text
Explain this code line by line.
```

### Real-World Use Case

A student receives old project code and needs to understand it quickly.

### Code

```csharp
public IActionResult GetProduct(int id)
{
    var product = _productService.GetProductById(id);

    if (product == null)
    {
        return NotFound();
    }

    return Ok(product);
}
```

### Prompt

```text
Explain this code line by line.
```

### How Copilot May Respond

```text
This method handles an HTTP request to get a product by ID.

1. It receives the product ID as a parameter.
2. It calls _productService.GetProductById(id) to fetch the product.
3. If no product is found, it returns 404 Not Found.
4. If the product exists, it returns 200 OK with the product data.
```

---

## 7. Functionality 3: Generate New Code

### What It Does

You can ask Copilot Chat to write code based on your requirement.

### Practical Steps

1. Open your project.
2. Open Copilot Chat.
3. Describe what you want clearly.
4. Review the generated code.
5. Copy or apply it.
6. Test it.

### Real-World Use Case

You are creating a product discount function for an e-commerce application.

### Prompt

```text
Write a JavaScript function to calculate discount.
If price is above 10000, discount is 20%.
If price is above 5000, discount is 10%.
Otherwise discount is 5%.
Return the discount amount.
```

### How Copilot May Respond

```javascript
function calculateDiscount(price) {
    if (price > 10000) {
        return price * 0.20;
    } else if (price > 5000) {
        return price * 0.10;
    } else {
        return price * 0.05;
    }
}

console.log(calculateDiscount(12000)); // 2400
console.log(calculateDiscount(7000));  // 700
console.log(calculateDiscount(3000));  // 150
```

---

## 8. Functionality 4: Fix Errors

### What It Does

Copilot Chat can help identify and fix errors in code.

### Practical Steps

1. Copy the error message.
2. Open Copilot Chat.
3. Paste the error and relevant code.
4. Ask Copilot to explain and fix it.

### Real-World Use Case

A student gets this SQL Server error:

```text
The select list for the INSERT statement contains more items than the insert list.
```

### Prompt

```text
I am getting this SQL Server error:
The select list for the INSERT statement contains more items than the insert list.
Explain why and fix this trigger code.
```

### How Copilot May Respond

```text
This error happens because the INSERT column list has fewer columns than the SELECT list.

Example problem:

INSERT INTO Employees(Name, Gender, City)
SELECT EmployeeId, Name, Gender, City FROM inserted;

Here INSERT has 3 columns but SELECT returns 4 values.

Fix:
Make sure both sides have the same number of columns.
```

### Corrected Example

```sql
INSERT INTO Employees
(Name, Gender, City, Salary, Email, MobileNo, DepartmentId)
SELECT Name, Gender, City, Salary, Email, MobileNo, DepartmentId
FROM inserted;
```

---

## 9. Functionality 5: Debug Code

### What It Does

Copilot Chat can help find logical mistakes, runtime errors, and missing conditions.

### Real-World Use Case

A JavaScript function gives wrong output.

### Code

```javascript
function calculateTotal(price, quantity) {
    return price + quantity;
}

console.log(calculateTotal(100, 5));
```

Expected output is `500`, but actual output is `105`.

### Prompt

```text
Debug this function. It should calculate total price.
```

### How Copilot May Respond

```text
The problem is that the function is adding price and quantity.
To calculate total price, you should multiply price by quantity.
```

### Corrected Code

```javascript
function calculateTotal(price, quantity) {
    return price * quantity;
}

console.log(calculateTotal(100, 5)); // 500
```

---

## 10. Functionality 6: Refactor Code

### What It Does

Refactoring means improving code structure without changing the output.

Copilot Chat can help:

- Remove duplicate code
- Improve readability
- Split large functions
- Rename variables
- Apply better coding standards
- Convert old syntax to modern syntax

### Real-World Use Case

#### Before Refactoring

```javascript
function getResult(marks) {
    if (marks >= 90) {
        return "A";
    } else if (marks >= 75) {
        return "B";
    } else if (marks >= 60) {
        return "C";
    } else {
        return "Fail";
    }
}
```

### Prompt

```text
Refactor this code to make it cleaner and easier to maintain.
```

### How Copilot May Respond

```javascript
function getGrade(marks) {
    if (marks >= 90) return "A";
    if (marks >= 75) return "B";
    if (marks >= 60) return "C";
    return "Fail";
}
```

### Explanation

```text
The refactored version removes unnecessary else blocks because each if condition returns immediately.
This makes the code shorter and easier to read.
```

---

## 11. Functionality 7: Generate Unit Tests

### What It Does

Copilot Chat can generate test cases for existing code.

### Real-World Use Case

You have a C# service method:

```csharp
public decimal CalculateDiscount(decimal price)
{
    if (price > 10000)
        return price * 0.20m;

    if (price > 5000)
        return price * 0.10m;

    return price * 0.05m;
}
```

### Prompt

```text
Generate xUnit test cases for this CalculateDiscount method.
```

### How Copilot May Respond

```csharp
using Xunit;

public class DiscountServiceTests
{
    [Fact]
    public void CalculateDiscount_WhenPriceAbove10000_Returns20Percent()
    {
        var service = new DiscountService();

        var result = service.CalculateDiscount(12000);

        Assert.Equal(2400, result);
    }

    [Fact]
    public void CalculateDiscount_WhenPriceAbove5000_Returns10Percent()
    {
        var service = new DiscountService();

        var result = service.CalculateDiscount(7000);

        Assert.Equal(700, result);
    }

    [Fact]
    public void CalculateDiscount_WhenPriceBelowOrEqual5000_Returns5Percent()
    {
        var service = new DiscountService();

        var result = service.CalculateDiscount(3000);

        Assert.Equal(150, result);
    }
}
```

---

## 12. Functionality 8: Generate Documentation

### What It Does

Copilot Chat can create documentation for classes, functions, APIs, and projects.

### Real-World Use Case

You created a Web API endpoint and need documentation for trainees.

### Code

```csharp
[HttpGet("{id}")]
public IActionResult GetCustomer(int id)
{
    var customer = _customerService.GetCustomerById(id);

    if (customer == null)
        return NotFound();

    return Ok(customer);
}
```

### Prompt

```text
Create documentation for this API endpoint.
Include purpose, URL, method, input, success response, and error response.
```

### How Copilot May Respond

```markdown
## Get Customer By ID

### Purpose
Returns customer details based on customer ID.

### HTTP Method
GET

### URL
/api/customers/{id}

### Input
| Parameter | Type | Description |
|---|---|---|
| id | int | Customer ID |

### Success Response
Status Code: 200 OK

### Error Response
Status Code: 404 Not Found if customer does not exist.
```

---

## 13. Functionality 9: Generate Comments

### What It Does

Copilot Chat can add meaningful comments to code.

### Real-World Use Case

A fresher wrote working code but did not add comments.

### Prompt

```text
Add clear comments to this code for beginner understanding.
```

### How Copilot May Respond

```javascript
// Function to calculate the final price after applying discount
function calculateFinalPrice(price, discountPercentage) {
    // Convert discount percentage into discount amount
    const discountAmount = price * (discountPercentage / 100);

    // Subtract discount amount from original price
    return price - discountAmount;
}
```

---

## 14. Functionality 10: Generate Regular Expressions

### What It Does

Copilot Chat can help create regular expressions for validation.

### Real-World Use Case

You need email validation in JavaScript.

### Prompt

```text
Create a JavaScript regular expression to validate a basic email address.
Explain how it works.
```

### How Copilot May Respond

```javascript
const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

function isValidEmail(email) {
    return emailRegex.test(email);
}
```

### Explanation

```text
This pattern checks that:
1. The email has characters before @.
2. It contains @.
3. It has characters after @.
4. It contains a dot after @.
5. It has characters after the dot.
```

Trainer note: For production systems, use tested validation libraries or framework validation because email rules can be complex.

---

## 15. Functionality 11: Convert Code from One Language to Another

### What It Does

Copilot Chat can translate logic from one programming language to another.

### Real-World Use Case

Convert JavaScript logic to C#.

### JavaScript Code

```javascript
function calculateTax(amount) {
    return amount * 0.18;
}
```

### Prompt

```text
Convert this JavaScript function to C#.
```

### How Copilot May Respond

```csharp
public decimal CalculateTax(decimal amount)
{
    return amount * 0.18m;
}
```

---

## 16. Functionality 12: Create SQL Queries

### What It Does

Copilot Chat can help write SQL queries, joins, grouping, filtering, stored procedures, and triggers.

### Real-World Use Case

Tables:

```text
Customers(CustomerId, CustomerName, City)
Orders(OrderId, CustomerId, OrderAmount, OrderDate)
```

### Prompt

```text
Write a SQL query to show customer name, city, and total order amount for each customer.
```

### How Copilot May Respond

```sql
SELECT 
    c.CustomerName,
    c.City,
    SUM(o.OrderAmount) AS TotalOrderAmount
FROM Customers c
INNER JOIN Orders o
    ON c.CustomerId = o.CustomerId
GROUP BY 
    c.CustomerName,
    c.City;
```

---

## 17. Functionality 13: Explain SQL Errors

### Real-World Use Case

#### Error

```text
Column is invalid in the select list because it is not contained in either an aggregate function or the GROUP BY clause.
```

### Prompt

```text
Explain this SQL Server error with example and fix.
```

### How Copilot May Respond

```text
This error happens when you use GROUP BY but select a column that is not grouped or aggregated.

Wrong:
SELECT City, CustomerName, COUNT(*)
FROM Customers
GROUP BY City;

CustomerName is not inside GROUP BY and not used inside an aggregate function.

Correct:
SELECT City, COUNT(*)
FROM Customers
GROUP BY City;
```

---

## 18. Functionality 14: Create API Code

### What It Does

Copilot Chat can help create controllers, services, repositories, DTOs, and API endpoints.

### Real-World Use Case

You are creating Product CRUD in ASP.NET Core Web API.

### Prompt

```text
Create an ASP.NET Core Web API ProductController with CRUD operations.
Use service layer. Include GetAll, GetById, Create, Update, and Delete.
```

### How Copilot May Respond

Copilot may generate:

```csharp
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_productService.GetAllProducts());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _productService.GetProductById(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create(ProductDto productDto)
    {
        var product = _productService.CreateProduct(productDto);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, ProductDto productDto)
    {
        var updatedProduct = _productService.UpdateProduct(id, productDto);

        if (updatedProduct == null)
            return NotFound();

        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _productService.DeleteProduct(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}
```

Trainer note: Students must verify whether models, DTOs, service interfaces, and dependency injection are already created.

---

## 19. Functionality 15: Understand Project Structure

### What It Does

Copilot Chat can explain files and folders in a project.

### Real-World Use Case

A fresher opens an ASP.NET Core project and sees:

```text
Controllers
Models
DTOs
Services
Repositories
Data
Program.cs
appsettings.json
```

### Prompt

```text
Explain this ASP.NET Core Web API project structure for a beginner.
```

### How Copilot May Respond

```text
Controllers handle HTTP requests.
Models represent database entities.
DTOs transfer data between client and server.
Services contain business logic.
Repositories handle database operations.
Data contains DbContext and database configuration.
Program.cs configures services and middleware.
appsettings.json stores configuration such as connection strings.
```

---

## 20. Functionality 16: Use Workspace or Project Context

### What It Does

Copilot Chat can use the current file and project context to answer better.

### Practical Steps

1. Open the project folder in VS Code.
2. Open the relevant file.
3. Select code if needed.
4. Ask Copilot a question about the file or project.

### Prompt

```text
Based on this project, where should I add validation logic for product creation?
```

### How Copilot May Respond

```text
In this project, validation should be added in the service layer or using DTO validation attributes.
For basic required field validation, you can add attributes in ProductDto.
For business rules like price must be greater than zero, add validation in ProductService.
```

---

## 21. Functionality 17: Inline Chat

### What It Does

Inline Chat lets you ask Copilot questions directly inside the editor, without opening the full chat panel.

### Practical Steps

1. Open a code file in VS Code.
2. Select a block of code.
3. Press `Ctrl + I`.
4. Type an instruction.

### Example Prompt

```text
Add validation for null and empty values.
```

### How Copilot May Respond

Copilot may modify:

```javascript
function greet(name) {
    return "Hello " + name;
}
```

Into:

```javascript
function greet(name) {
    if (!name || name.trim() === "") {
        return "Name is required";
    }

    return "Hello " + name;
}
```

---

## 22. Functionality 18: Agent Mode / Local Agent in VS Code

### What It Does

Agent mode is used for larger coding tasks. Instead of only answering, Copilot can plan steps, inspect files, suggest changes, and modify multiple files.

### Real-World Use Case

You want to add a new feature to an existing app.

### Prompt

```text
Add a Product Category feature to this ASP.NET Core Web API.
Create model, DTO, repository, service, controller, and register dependencies.
```

### How Copilot May Respond

Copilot may:

1. Inspect existing project structure.
2. Create `Category.cs`.
3. Create `CategoryDto.cs`.
4. Create `ICategoryRepository.cs`.
5. Create `CategoryRepository.cs`.
6. Create `ICategoryService.cs`.
7. Create `CategoryService.cs`.
8. Create `CategoriesController.cs`.
9. Update `Program.cs`.
10. Show file changes for review.

### Trainer Explanation

> Normal chat gives answers. Agent mode can perform a task across multiple files, but the developer must review every change before accepting.

---

## 23. Functionality 19: Copilot Code Review

### What It Does

Copilot can review code and pull requests, find issues, and suggest improvements.

### Real-World Use Case

A developer creates a pull request for login functionality.

### Practical Steps on GitHub

1. Push your branch to GitHub.
2. Create a pull request.
3. Open the pull request.
4. Use Copilot code review if available.
5. Review Copilot suggestions.
6. Apply only valid suggestions.

### Example Copilot Feedback

```text
The password validation logic is duplicated in two methods.
Consider moving it into a separate private method or validation service.
```

or

```text
This API endpoint returns internal exception details to the client.
Consider logging the exception and returning a generic error message.
```

---

## 24. Functionality 20: Pull Request Summary

### What It Does

Copilot can summarize pull requests and explain what changed.

### Real-World Use Case

A trainer or team lead wants to quickly understand a student’s pull request.

### Prompt

```text
Summarize this pull request for a reviewer.
```

### How Copilot May Respond

```text
This pull request adds CRUD operations for Products.
It introduces ProductDto, ProductService, ProductRepository, and ProductsController.
It also updates Program.cs to register service and repository dependencies.
```

---

## 25. Functionality 21: Generate Commit Messages

### What It Does

Copilot can help write meaningful commit messages.

### Real-World Use Case

You modified product CRUD and added validation.

### Prompt

```text
Generate a clear Git commit message for these changes.
```

### How Copilot May Respond

```text
Add product CRUD operations with validation
```

Or:

```text
feat: add product controller, service, repository, and validation
```

---

## 26. Functionality 22: Help with Terminal Commands

### What It Does

Copilot Chat can explain or generate terminal commands.

### Real-World Use Case

A student wants to create a new ASP.NET Core Web API project.

### Prompt

```text
Give me the command to create a new ASP.NET Core Web API project named ProductApi.
```

### How Copilot May Respond

```bash
dotnet new webapi -n ProductApi
cd ProductApi
dotnet run
```

### Trainer Note

Ask students to understand the command before running it, especially commands that delete files, modify system settings, or install packages.

---

## 27. Functionality 23: Generate Regex, JSON, YAML, Dockerfile, and Config Files

### Real-World Use Case: Dockerfile

### Prompt

```text
Create a Dockerfile for an ASP.NET Core Web API using .NET 8.
```

### How Copilot May Respond

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "YourApi.dll"]
```

---

## 28. Functionality 24: Create README Files

### What It Does

Copilot can generate project README files.

### Real-World Use Case

You completed a Web API project and need documentation.

### Prompt

```text
Create a README.md file for this ASP.NET Core Web API project.
Include project overview, features, setup steps, API endpoints, and technologies used.
```

### How Copilot May Respond

```markdown
# Product API

## Overview
Product API is an ASP.NET Core Web API project for managing products.

## Features
- Create product
- View products
- Update product
- Delete product

## Technologies
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server

## Setup
1. Clone the repository.
2. Update connection string.
3. Run migrations.
4. Start the application.
```

---

## 29. Functionality 25: Model Selection

### What It Does

GitHub Copilot supports different AI models, and model choice can affect response quality, speed, and task suitability.

### Real-World Use Case

| Task | Suggested Approach |
|---|---|
| Quick code explanation | Use faster model |
| Complex architecture design | Use stronger reasoning model |
| Large refactoring | Use advanced model or agent mode |
| Simple syntax question | Any available model is usually enough |

### Practical Steps

1. Open Copilot Chat.
2. Look for the model selector if available.
3. Choose a model based on task.
4. Ask your prompt.

### Example Prompt

```text
Compare repository pattern and service pattern in ASP.NET Core with real project example.
```

---

## 30. Functionality 26: Prompt Files

### What It Does

Prompt files are reusable prompts saved in your project. They are useful for repeated tasks such as:

- Generate unit tests
- Review code
- Create README
- Document API
- Create onboarding plan

### Real-World Use Case

A trainer wants every student to follow the same code review checklist.

### Example Prompt File Purpose

```text
Review this code for naming conventions, exception handling, validation, security, and performance.
```

### Practical Steps

1. Create a prompt file in the project.
2. Add reusable instructions.
3. Run it when reviewing code.

---

## 31. Functionality 27: Custom Instructions

### What It Does

Custom instructions tell Copilot how to behave for a repository or workspace.

Example instructions:

```text
Use C# coding standards.
Use async methods for database calls.
Use repository and service pattern.
Use DTOs for API input and output.
Do not return entity models directly from controllers.
```

### Real-World Use Case

In a training batch, all students must follow the same architecture.

### Prompt

```text
Generate Product CRUD following this project’s custom instructions.
```

### How Copilot May Respond

It should generate code that follows your documented standards, such as service layer, repository layer, DTOs, and dependency injection.

---

## 32. Functionality 28: Chat Participants, Commands, and Context

Depending on IDE and version, Copilot Chat supports commands or special context references.

Common examples include asking Copilot to:

- Explain selected code
- Fix selected code
- Generate tests
- Use workspace context
- Use current file context
- Use terminal context

### Real-World Use Case

### Prompt

```text
Explain the selected code and tell me whether it follows best practices.
```

### How Copilot May Respond

```text
The selected code works, but it mixes business logic inside the controller.
For better maintainability, move the business logic to a service class.
```

---

## 33. Functionality 29: Security Guidance

### What It Does

Copilot can suggest security improvements, but developers must verify them.

### Real-World Use Case

### Prompt

```text
Review this login code for security issues.
```

### Possible Copilot Response

```text
Security concerns:
1. Passwords should not be stored in plain text.
2. Use password hashing such as BCrypt or ASP.NET Core Identity.
3. Avoid returning detailed login failure reasons.
4. Add rate limiting to prevent brute force attacks.
5. Use HTTPS.
```

Trainer note: Security-sensitive code should always be reviewed by experienced developers.

---

## 34. Functionality 30: Performance Suggestions

### What It Does

Copilot can suggest performance improvements.

### Real-World Use Case

### SQL Query

```sql
SELECT *
FROM Orders
WHERE YEAR(OrderDate) = 2026;
```

### Prompt

```text
Improve this SQL query for performance.
```

### How Copilot May Respond

```sql
SELECT *
FROM Orders
WHERE OrderDate >= '2026-01-01'
  AND OrderDate < '2027-01-01';
```

### Explanation

```text
Using YEAR(OrderDate) applies a function to the column, which may prevent index usage.
Using a date range is usually better for performance.
```

---

## 35. Functionality 31: Learning and Interview Preparation

### What It Does

Copilot Chat can help students learn topics and prepare for interviews.

### Real-World Use Case

### Prompt

```text
Explain stored procedures in SQL Server with beginner-friendly examples and interview questions.
```

### How Copilot May Respond

It may provide:

- Definition
- Syntax
- Example
- When to use
- Advantages
- Interview questions
- Common mistakes

---

## 36. Practical Classroom Demo Plan

### Demo 1: Explain Code

#### Steps

1. Open VS Code.
2. Create `app.js`.
3. Add this code:

```javascript
function calculateTotal(price, quantity) {
    return price * quantity;
}
```

4. Select the code.
5. Ask Copilot:

```text
Explain this code for a beginner.
```

Expected response:

```text
This function receives price and quantity and returns the total amount by multiplying them.
```

---

### Demo 2: Generate Code

### Prompt

```text
Create a JavaScript function to calculate GST amount at 18%.
```

Expected response:

```javascript
function calculateGST(amount) {
    return amount * 0.18;
}
```

---

### Demo 3: Fix Error

### Wrong Code

```javascript
function calculateTotal(price, quantity) {
    return price + quantity;
}
```

### Prompt

```text
This function should calculate total price. Find and fix the issue.
```

Expected response:

```javascript
function calculateTotal(price, quantity) {
    return price * quantity;
}
```

---

### Demo 4: Generate Unit Test

### Prompt

```text
Generate unit tests for this calculateTotal function.
```

Expected response:

```javascript
describe("calculateTotal", () => {
    test("should multiply price and quantity", () => {
        expect(calculateTotal(100, 5)).toBe(500);
    });
});
```

---

### Demo 5: Refactor Code

### Prompt

```text
Refactor this code to make it cleaner.
```

Expected response:

```text
Copilot suggests a shorter or more readable version of the same logic.
```

---

## 37. Best Prompt Format for Students

Teach students to write prompts in this structure:

```text
Task:
Technology:
Input:
Expected output:
Rules:
```

### Example

```text
Task: Create a Product API controller.
Technology: ASP.NET Core Web API with C#.
Input: ProductDto with Name, Price, Stock.
Expected output: CRUD endpoints.
Rules: Use service layer, return proper HTTP status codes, add validation.
```

This gives better results than:

```text
Create product code.
```

---

## 38. Good Prompts vs Poor Prompts

| Poor Prompt | Better Prompt |
|---|---|
| Fix this | Fix this C# method and explain the error |
| Create API | Create ASP.NET Core Web API CRUD for Product using service layer |
| Write SQL | Write SQL Server query to show monthly sales by customer |
| Explain | Explain this selected code line by line for beginners |
| Test this | Generate xUnit tests for this C# service method |

---

## 39. What Copilot Chat Can Do Well

Copilot Chat is useful for:

- Code explanation
- Code generation
- Debugging help
- Unit test generation
- SQL query creation
- Documentation
- Refactoring
- API creation
- Learning concepts
- Reviewing code
- Pull request summary
- Command-line help
- Error explanation

---

## 40. What Copilot Chat Cannot Guarantee

Copilot Chat cannot guarantee that every answer is correct.

Limitations:

- It may generate wrong code.
- It may misunderstand requirements.
- It may miss security issues.
- It may generate outdated syntax.
- It may ignore project-specific rules if context is missing.
- It may produce code that compiles but has wrong business logic.
- It may suggest packages or APIs that are not installed.

---

## 41. Trainer Advice for Cohorts

Tell students:

> Copilot Chat is not a replacement for developers.  
> It is an assistant.  
> The developer must understand, review, test, and improve the code.

Important rules for students:

1. Do not blindly accept code.
2. Always test the generated code.
3. Ask Copilot to explain before using code.
4. Give clear prompts.
5. Provide project context.
6. Check security and performance.
7. Use custom instructions for project standards.
8. Use Copilot for learning, not copying blindly.

---

## 42. Sample End-to-End Real-World Use Case

### Scenario

You are building an **E-Commerce Product Management API** using ASP.NET Core Web API.

You need:

- Product model
- Product DTO
- Product controller
- Product service
- Product repository
- SQL Server database
- CRUD operations
- Validation
- Unit tests
- README documentation

---

### Step 1: Ask Copilot to Plan

#### Prompt

```text
I want to build an ASP.NET Core Web API for Product Management.
Give me the project structure using controller, service, repository, DTO, and Entity Framework Core.
```

#### Expected Response

```text
Suggested structure:
Controllers/ProductsController.cs
Models/Product.cs
DTOs/ProductDto.cs
Services/IProductService.cs
Services/ProductService.cs
Repositories/IProductRepository.cs
Repositories/ProductRepository.cs
Data/AppDbContext.cs
```

---

### Step 2: Generate Model

#### Prompt

```text
Create a Product entity with Id, Name, Description, Price, StockQuantity, CreatedDate.
```

#### Expected Response

```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
```

---

### Step 3: Generate DTO

#### Prompt

```text
Create ProductDto with validation attributes.
```

#### Expected Response

```csharp
using System.ComponentModel.DataAnnotations;

public class ProductDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Range(1, 100000)]
    public decimal Price { get; set; }

    [Range(0, 10000)]
    public int StockQuantity { get; set; }
}
```

---

### Step 4: Generate Controller

#### Prompt

```text
Create ProductsController with CRUD operations using IProductService.
```

#### Expected Response

Copilot may generate controller code with:

- `GET /api/products`
- `GET /api/products/{id}`
- `POST /api/products`
- `PUT /api/products/{id}`
- `DELETE /api/products/{id}`

---

### Step 5: Generate Unit Tests

#### Prompt

```text
Generate xUnit tests for ProductService CreateProduct and GetProductById methods.
```

---

### Step 6: Generate README

#### Prompt

```text
Create README.md for this Product Management API with setup steps and endpoint details.
```

---

## 43. Final Summary

**GitHub Copilot Chat** is an AI-powered coding assistant that helps developers through conversation. It can explain code, generate code, fix errors, debug issues, write tests, create documentation, review pull requests, suggest terminal commands, and help understand project structure.

For cohorts, the most important message is:

> Use Copilot Chat as a learning assistant and productivity tool.  
> Always verify the answer, test the code, and apply project standards before using it in real applications.
