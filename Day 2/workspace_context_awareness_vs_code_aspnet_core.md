# Workspace Context Awareness in GitHub Copilot Using ASP.NET Core Web API in VS Code

## Objective

This document explains how to create an ASP.NET Core Web API project in Visual Studio Code and demonstrate **GitHub Copilot Workspace Context Awareness**.

You will learn:

1. How to create an ASP.NET Core Web API project using VS Code.
2. How to create model, service, and controller files.
3. How to run and test the API using Swagger.
4. How Copilot behaves without workspace context.
5. How Copilot behaves with workspace context.
6. How to manually provide context when `@workspace` is not used.

---

# 1. Prerequisites

Install these first:

1. **.NET SDK**
2. **Visual Studio Code**
3. VS Code extensions:
   - C# Dev Kit
   - C#
   - GitHub Copilot
   - GitHub Copilot Chat

---

# 2. Create ASP.NET Core Web API Project in VS Code

## Step 1: Open VS Code

Open VS Code.

Create one empty folder anywhere, for example:

```text
D:\DotNetProjects\EmployeeContextDemo
```

Open that folder in VS Code:

```text
File → Open Folder → EmployeeContextDemo
```

---

## Step 2: Open Terminal in VS Code

Go to:

```text
Terminal → New Terminal
```

Check whether .NET SDK is installed:

```bash
dotnet --version
```

You should see a version number.

Example:

```text
8.0.xxx
```

or:

```text
9.0.xxx
```

---

## Step 3: Create Web API Project

Run this command:

```bash
dotnet new webapi --use-controllers -n EmployeeContextDemo
```

This creates a controller-based ASP.NET Core Web API project.

Now go inside the project folder:

```bash
cd EmployeeContextDemo
```

Open the project in VS Code:

```bash
code .
```

---

# 3. Check Project Structure

You will see files similar to this:

```text
EmployeeContextDemo
│
├── Controllers
│   └── WeatherForecastController.cs
│
├── Program.cs
├── EmployeeContextDemo.csproj
├── appsettings.json
└── appsettings.Development.json
```

For this demo, you can delete:

```text
WeatherForecastController.cs
```

We will create our own Employee API.

---

# 4. Create Required Folders

In VS Code Explorer, create these folders:

```text
Models
Services
```

Final structure should look like:

```text
EmployeeContextDemo
│
├── Controllers
├── Models
├── Services
├── Program.cs
└── EmployeeContextDemo.csproj
```


---

# 5. Add Employee Model

Create this file:

```text
Models/Employee.cs
```

Add this code:

```csharp
namespace EmployeeContextDemo.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public decimal Salary { get; set; }
    }
}
```

---

# 6. Add Service Interface

Create this file:

```text
Services/IEmployeeService.cs
```

Add this code:

```csharp
using EmployeeContextDemo.Models;

namespace EmployeeContextDemo.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();

        Task<Employee?> GetEmployeeByIdAsync(int id);

        Task<Employee> AddEmployeeAsync(Employee employee);
    }
}
```

---

# 7. Add Service Implementation

Create this file:

```text
Services/EmployeeService.cs
```

Add this code:

```csharp
using EmployeeContextDemo.Models;

namespace EmployeeContextDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                EmployeeId = 1,
                Name = "Arun",
                Department = "IT",
                Salary = 45000
            },
            new Employee
            {
                EmployeeId = 2,
                Name = "Priya",
                Department = "HR",
                Salary = 40000
            }
        };

        public Task<List<Employee>> GetAllEmployeesAsync()
        {
            return Task.FromResult(_employees);
        }

        public Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.EmployeeId == id);

            return Task.FromResult(employee);
        }

        public Task<Employee> AddEmployeeAsync(Employee employee)
        {
            employee.EmployeeId = _employees.Max(e => e.EmployeeId) + 1;

            _employees.Add(employee);

            return Task.FromResult(employee);
        }
    }
}
```


---

# 8. Register Service in Program.cs

Open:

```text
Program.cs
```

Replace the code with this:

```csharp
using EmployeeContextDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register custom service
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

---

# 9. Create Employees Controller

Create this file:

```text
Controllers/EmployeesController.cs
```

Add this code:

```csharp
using EmployeeContextDemo.Models;
using EmployeeContextDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeContextDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            return Ok(employee);
        }
    }
}
```


---

# 10. Run the Project

In VS Code terminal, run:

```bash
dotnet run
```

You may see output like:

```text
Now listening on: https://localhost:7123
Now listening on: http://localhost:5123
```

Open Swagger in browser:

```text
https://localhost:7123/swagger
```

Your port number may be different.

Test:

```text
GET /api/Employees
```

Expected output:

```json
[
  {
    "employeeId": 1,
    "name": "Arun",
    "department": "IT",
    "salary": 45000
  },
  {
    "employeeId": 2,
    "name": "Priya",
    "department": "HR",
    "salary": 40000
  }
]
```

---

# 11. Demo: Copilot Without Workspace Context

Now explain this to students:

> First, we will ask Copilot a very general question without giving project context.

Open GitHub Copilot Chat in VS Code.

Use this prompt:

```text
Create POST method to add employee
```

Copilot may give generic code like:

```csharp
[HttpPost]
public IActionResult AddEmployee(Employee employee)
{
    employees.Add(employee);
    return Ok(employee);
}
```

---

## Why This Is Wrong

This code may fail because:

```csharp
employees
```

does not exist inside our controller.

Also, this code does not use:

```csharp
IEmployeeService
```

It does not follow our existing async pattern.

It does not use:

```csharp
AddEmployeeAsync()
```

It does not return proper HTTP create response.

---

## Impact Without Workspace Context

Explain to freshers:

```text
Without workspace context, Copilot may give a general answer.
The answer may be correct for a simple demo, but wrong for our actual project.
```

Impact:

```text
1. Code may not compile.
2. Existing service layer may be ignored.
3. Controller may contain duplicate logic.
4. Architecture becomes inconsistent.
5. Debugging time increases.
6. Freshers may blindly accept wrong code.
```


---

# 12. Demo: Correct Way Using Workspace Context in VS Code

Now ask Copilot with workspace context.

Use this prompt:

```text
@workspace Using the existing Employee model and IEmployeeService in this project,
create a POST method in EmployeesController to add a new employee.
Follow the same async service pattern already used in this controller.
```

When Copilot uses workspace context, it can look at your project files and understand:

```text
1. Employee model
2. IEmployeeService interface
3. EmployeeService implementation
4. Existing EmployeesController pattern
5. Existing async method style
```

---

# 13. Correct Code to Add

Add this method inside `EmployeesController`:

```csharp
[HttpPost]
public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
{
    if (employee == null)
    {
        return BadRequest("Employee data is required.");
    }

    var createdEmployee = await _employeeService.AddEmployeeAsync(employee);

    return CreatedAtAction(
        nameof(GetEmployeeById),
        new { id = createdEmployee.EmployeeId },
        createdEmployee
    );
}
```

---

# 14. Full EmployeesController.cs After POST Method

```csharp
using EmployeeContextDemo.Models;
using EmployeeContextDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeContextDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is required.");
            }

            var createdEmployee = await _employeeService.AddEmployeeAsync(employee);

            return CreatedAtAction(
                nameof(GetEmployeeById),
                new { id = createdEmployee.EmployeeId },
                createdEmployee
            );
        }
    }
}
```


---

# 15. Test POST API in Swagger

Stop and rerun the project:

```bash
dotnet run
```

Open Swagger:

```text
https://localhost:your-port/swagger
```

Click:

```text
POST /api/Employees
```

Click:

```text
Try it out
```

Enter:

```json
{
  "name": "Karthik",
  "department": "Finance",
  "salary": 50000
}
```

Click:

```text
Execute
```

Expected response:

```json
{
  "employeeId": 3,
  "name": "Karthik",
  "department": "Finance",
  "salary": 50000
}
```

Now test:

```text
GET /api/Employees
```

You should see:

```text
Arun
Priya
Karthik
```

---

# 16. How to Use Context Without `@workspace`

Sometimes you may not use `@workspace`. In that case, manually give the project details in the prompt.

## Manual Context Prompt

```text
I have an ASP.NET Core Web API project.

Employee model has:
EmployeeId, Name, Department, Salary.

I have IEmployeeService with these methods:
GetAllEmployeesAsync()
GetEmployeeByIdAsync(int id)
AddEmployeeAsync(Employee employee)

EmployeesController already uses dependency injection for IEmployeeService.

Now create a POST method to add employee using the service layer.
Use async and await.
Return CreatedAtAction after successful creation.
Do not create a new List inside the controller.
```

This is manual context.

---

# 17. Better Prompt Using Existing Code Pattern

You can also paste the existing method and ask Copilot to follow it:

```text
Follow this existing controller pattern:

[HttpGet("{id}")]
public async Task<IActionResult> GetEmployeeById(int id)
{
    var employee = await _employeeService.GetEmployeeByIdAsync(id);

    if (employee == null)
    {
        return NotFound("Employee not found.");
    }

    return Ok(employee);
}

Now create a POST method using AddEmployeeAsync().
Return CreatedAtAction after creating the employee.
```


---

# 18. Classroom Explanation

Tell students:

```text
Do not ask Copilot only what you want.
Tell Copilot how the code should fit inside the current project.
```

Bad prompt:

```text
Create POST method to add employee
```

Better prompt:

```text
@workspace Use the existing Employee model and IEmployeeService.
Follow the same async pattern in EmployeesController.
Create POST method to add employee.
Return CreatedAtAction after successful creation.
```

---

# 19. Difference Between Without Workspace Context and With Workspace Context

| Point | Without Workspace Context | With Workspace Context |
|---|---|---|
| Prompt | Create POST method to add employee | @workspace Use existing Employee model and IEmployeeService |
| Output | Generic code | Project-specific code |
| Service layer | May be ignored | Uses existing service layer |
| Compilation | May fail | More likely to compile |
| Architecture | May become inconsistent | Follows existing architecture |
| Freshers' learning | Can confuse them | Helps them understand project structure |

---

# 20. Trainer Script

You can explain to cohorts like this:

> In real projects, we do not write code in isolation. We already have models, services, repositories, database context, controllers, and coding standards. If we ask Copilot a general question, it may give a general answer. But if we give workspace context, Copilot can understand the existing project and generate code that fits the project.

Continue:

> In this example, without context, Copilot may create a method using `employees.Add(employee)`. But our controller does not have an `employees` list. Our project uses `IEmployeeService`. So the correct code should call `_employeeService.AddEmployeeAsync(employee)`.

Final trainer point:

> Copilot is useful, but developers must guide it. The quality of Copilot output depends on the quality of context we provide.

---

# 21. Final Summary

In VS Code, the best way to teach this is:

```text
1. Create ASP.NET Core Web API using dotnet CLI.
2. Add Employee model, service interface, service implementation, and controller.
3. Ask Copilot a generic prompt without context.
4. Show that the generated code may not match the project.
5. Ask Copilot again with @workspace or manual context.
6. Show that the generated code follows the actual project structure.
```

Main learning point:

```text
Poor prompt + no context = generic code

Good prompt + workspace context = project-specific code
```

For freshers, remember this rule:

```text
Do not ask Copilot only what you want.
Also tell Copilot where and how it should fit in the project.
```

Best prompt pattern:

```text
Use the existing [model/service/controller] in this project.
Follow the same pattern used in [file name].
Do not create duplicate logic.
Generate code for [exact requirement].
```

For this example:

```text
Use the existing Employee model and IEmployeeService.
Follow the same async pattern in EmployeesController.
Create POST method to add employee.
Return CreatedAtAction after successful creation.
```
