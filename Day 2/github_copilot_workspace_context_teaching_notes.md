# Workspace Context Awareness in GitHub Copilot Using VS Code ASP.NET Core Project

## Project Used for This Teaching Demo

Based on the VS Code screenshot, the project workspace is:

```text
EMPLOYEECONTEXTDEMO
│
├── bin
├── Controllers
│   ├── EmployeesController.cs
│   └── WeatherForecastController.cs
├── Models
│   └── Employee.cs
├── obj
├── Properties
├── Services
│   ├── EmployeeService.cs
│   └── IEmployeeService.cs
├── appsettings.Development.json
├── appsettings.json
├── EmployeeContextDemo.csproj
├── EmployeeContextDemo.http
├── Program.cs
└── WeatherForecast.cs
```

This is a good project to teach **Workspace Context Awareness in GitHub Copilot**.

---

# 1. What is Workspace in VS Code?

In VS Code, a **workspace** means the folder you opened in VS Code.

In this example, the workspace is:

```text
EMPLOYEECONTEXTDEMO
```

GitHub Copilot can use files inside this workspace as context.

So when you ask Copilot:

```text
Create POST method for employee
```

Copilot may check files like:

```text
Employee.cs
IEmployeeService.cs
EmployeeService.cs
EmployeesController.cs
Program.cs
```

and then suggest code based on your actual project.

---

# 2. Different Workspace Context Areas in Your Project

For teaching, explain that Copilot can take context from different areas.

---

## 2.1 Current File Context

This means Copilot understands the file currently opened in the editor.

Example:

You open:

```text
EmployeesController.cs
```

Then ask Copilot:

```text
Create a POST method in this controller.
```

Copilot can understand the controller class, existing methods, injected services, namespace, and coding style from the current file.

Trainer explanation:

> Current file context means Copilot looks at the file where we are currently working.

---

## 2.2 Open Tabs Context

If you keep multiple related files open, Copilot can use them as useful context.

For this demo, open these files together:

```text
Employee.cs
IEmployeeService.cs
EmployeeService.cs
EmployeesController.cs
Program.cs
```

Then ask:

```text
Create a POST API method for Employee using the existing service pattern.
```

This gives Copilot better clues because related files are already open.

Trainer explanation:

> Open related files before asking Copilot. This improves the chance of getting project-specific code.

---

## 2.3 Selection Context

This means you select some code and ask Copilot about only that selected part.

Example:

Open:

```text
EmployeesController.cs
```

Select this method:

```csharp
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
```

Then ask Copilot:

```text
Using this selected method style, create a POST method to add employee.
```

Copilot will follow the selected code pattern.

Trainer explanation:

> Selection context is useful when you want Copilot to follow a specific code style.

---

## 2.4 File Context

You can explicitly attach or mention a file as context.

Example prompt:

```text
Use EmployeesController.cs, Employee.cs, and IEmployeeService.cs as context.
Create a POST endpoint to add employee.
```

Trainer explanation:

> File context means we clearly tell Copilot which file to consider.

---

## 2.5 Folder Context

You can ask Copilot to understand a complete folder.

Example:

```text
Use the Controllers and Services folders as context.
Explain how the Employee API flow works.
```

In your project:

```text
Controllers
Services
Models
```

These folders explain the architecture.

Trainer explanation:

> Folder context is useful when we want Copilot to understand a module, not just one file.

---

## 2.6 Workspace or Codebase Context

This is the most important part.

You can ask Copilot to use the complete workspace.

Prompt:

```text
@workspace Explain the flow of this Employee API project.
```

or:

```text
@workspace Create a POST endpoint in EmployeesController using the existing Employee model and IEmployeeService.
```

Trainer explanation:

> Workspace context means Copilot can search the complete project folder and understand how files are connected.

---

## 2.7 Terminal Context

Copilot can also help with terminal errors.

Example:

Your terminal shows an error while running:

```bash
dotnet run
```

You can ask:

```text
@terminal Explain this error and tell me how to fix it.
```

Trainer explanation:

> Terminal context is useful when the project is not building or running.

---

## 2.8 VS Code Context

You can ask questions about VS Code itself.

Example:

```text
@vscode How do I open Swagger URL from terminal output?
```

Trainer explanation:

> VS Code context is useful for editor-related help, not project business logic.

---

# 3. Explain Your Project Workspace to Students

Use your VS Code screenshot and explain each item.

---

## 3.1 Controllers Folder

```text
Controllers
├── EmployeesController.cs
└── WeatherForecastController.cs
```

This folder contains API endpoints.

Example:

```text
/api/Employees
```

Trainer explanation:

> Controllers receive HTTP requests from browser, Swagger, Postman, or frontend applications.

---

## 3.2 Models Folder

```text
Models
└── Employee.cs
```

This contains the data structure.

Example:

```csharp
public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
}
```

Trainer explanation:

> Model represents the data shape used by the application.

---

## 3.3 Services Folder

```text
Services
├── EmployeeService.cs
└── IEmployeeService.cs
```

This contains business logic.

Trainer explanation:

> Controller should not directly handle all logic. It should call service methods.

---

## 3.4 Program.cs

```text
Program.cs
```

This is the application startup file.

It usually contains:

```csharp
builder.Services.AddControllers();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
app.MapControllers();
```

Trainer explanation:

> Program.cs configures services, dependency injection, middleware, Swagger, and controllers.

---

## 3.5 EmployeeContextDemo.csproj

```text
EmployeeContextDemo.csproj
```

This is the project file.

It contains framework and package details.

Trainer explanation:

> `.csproj` tells .NET which framework and packages the project uses.

---

## 3.6 EmployeeContextDemo.http

```text
EmployeeContextDemo.http
```

This file can be used to test APIs directly from VS Code.

Example:

```http
GET https://localhost:7123/api/Employees
```

Trainer explanation:

> `.http` file is like a simple Postman inside VS Code.

---

## 3.7 bin and obj Folders

```text
bin
obj
```

These are generated folders.

Trainer explanation:

> These folders are created by .NET during build and run. We usually do not manually edit them.

---

# 4. How to Implement This Demo Using GitHub Copilot

---

## Step 1: Open the Correct Workspace Folder

In VS Code, open the root folder:

```text
EMPLOYEECONTEXTDEMO
```

Do not open only:

```text
Controllers
```

or only:

```text
Services
```

Because if you open only a subfolder, Copilot will have less workspace context.

Trainer explanation:

> Always open the full project folder so Copilot can understand the complete application.

---

## Step 2: Open Important Files

Open these files in tabs:

```text
Employee.cs
IEmployeeService.cs
EmployeeService.cs
EmployeesController.cs
Program.cs
```

This helps Copilot see related code patterns.

---

## Step 3: Ask Copilot Without Workspace Context

In Copilot Chat, ask:

```text
Create POST method to add employee
```

Possible output:

```csharp
[HttpPost]
public IActionResult AddEmployee(Employee employee)
{
    employees.Add(employee);
    return Ok(employee);
}
```

Explain the problem:

```text
employees variable does not exist.
It does not use IEmployeeService.
It does not follow async pattern.
It does not return CreatedAtAction.
```

Impact:

```text
Code may not compile.
Architecture is not followed.
Service layer is ignored.
Freshers may blindly accept wrong code.
```

---

## Step 4: Ask Copilot With Workspace Context

Now ask:

```text
@workspace Using the existing Employee model, IEmployeeService, EmployeeService, and EmployeesController,
create a POST method to add an employee.
Follow the same async service pattern used in this project.
Return CreatedAtAction after successful creation.
```

Expected better output:

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

Trainer explanation:

> Here Copilot understands that this project already has `IEmployeeService`, so it uses `_employeeService.AddEmployeeAsync(employee)` instead of creating a new list inside the controller.

---

# 5. Teaching Example: Workspace Context Flow

Explain this flow:

```text
User Request
   ↓
EmployeesController.cs receives request
   ↓
Controller calls IEmployeeService
   ↓
EmployeeService handles employee logic
   ↓
Employee model represents data
   ↓
Response goes back to Swagger/browser
```

Now connect this to Copilot:

```text
Copilot reads workspace files
   ↓
Finds Employee model
   ↓
Finds IEmployeeService methods
   ↓
Finds EmployeeService implementation
   ↓
Finds existing controller pattern
   ↓
Generates matching code
```

---

# 6. Copilot Prompts for Your Project

---

## Prompt 1: Explain Project

```text
@workspace Explain this ASP.NET Core Web API project structure for freshers.
Explain the role of Controllers, Models, Services, Program.cs, and .csproj.
```

Use this to teach the project structure.

---

## Prompt 2: Explain API Flow

```text
@workspace Explain the request flow for GET /api/Employees in this project.
Mention which file is called first and how service is used.
```

Use this to explain execution flow.

---

## Prompt 3: Generate POST Method

```text
@workspace Add a POST method in EmployeesController to create an employee.
Use the existing IEmployeeService.AddEmployeeAsync method.
Follow async and await pattern.
Return CreatedAtAction.
```

Use this to show code generation with workspace context.

---

## Prompt 4: Add Validation

```text
@workspace Add validation in AddEmployee method.
Name and Department should not be empty.
Salary should be greater than zero.
Use BadRequest for invalid input.
```

Expected code idea:

```csharp
if (string.IsNullOrWhiteSpace(employee.Name))
{
    return BadRequest("Employee name is required.");
}

if (string.IsNullOrWhiteSpace(employee.Department))
{
    return BadRequest("Department is required.");
}

if (employee.Salary <= 0)
{
    return BadRequest("Salary must be greater than zero.");
}
```

---

## Prompt 5: Explain Dependency Injection

```text
@workspace Explain how dependency injection is used in this project.
Explain Program.cs registration and constructor injection in EmployeesController.
```

Use this to explain:

```csharp
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
```

and:

```csharp
private readonly IEmployeeService _employeeService;

public EmployeesController(IEmployeeService employeeService)
{
    _employeeService = employeeService;
}
```

---

## Prompt 6: Use Manual Context Without @workspace

```text
I have an ASP.NET Core Web API project.

Employee model has EmployeeId, Name, Department, Salary.

IEmployeeService has:
GetAllEmployeesAsync()
GetEmployeeByIdAsync(int id)
AddEmployeeAsync(Employee employee)

EmployeesController already injects IEmployeeService.

Create a POST method to add employee.
Use AddEmployeeAsync.
Use async and await.
Return CreatedAtAction.
Do not create a new List inside controller.
```

Use this when you want to teach **manual context**.

---

# 7. Workspace Context Area Demo Plan for Class

You can teach in this order.

---

## Demo 1: Current File Context

Open:

```text
EmployeesController.cs
```

Ask:

```text
Explain this file.
```

Then ask:

```text
Create POST method following the same style.
```

Explain:

> Copilot mainly uses the current file.

---

## Demo 2: Selection Context

Select the `GetEmployeeById` method.

Ask:

```text
Using this selected method style, create a POST method.
```

Explain:

> Copilot follows the selected code style.

---

## Demo 3: Open Tabs Context

Open these tabs:

```text
Employee.cs
IEmployeeService.cs
EmployeeService.cs
EmployeesController.cs
```

Ask:

```text
Create AddEmployee API using the existing service.
```

Explain:

> Open tabs give Copilot additional useful context.

---

## Demo 4: Workspace Context

Ask:

```text
@workspace Explain how Employee API is implemented in this project.
```

Explain:

> Copilot searches the complete workspace.

---

## Demo 5: Terminal Context

Run:

```bash
dotnet run
```

If error comes, ask:

```text
@terminal Explain the error and give the fix.
```

Explain:

> Copilot uses terminal output as context.

---

# 8. Important Point About WeatherForecast Files

Your project still has:

```text
WeatherForecastController.cs
WeatherForecast.cs
```

These are default template files.

For teaching Employee API clearly, you can either keep them or delete them.

---

## Option 1: Keep Them

Tell students:

> These files came from the default ASP.NET Core Web API template. They are not part of our Employee module.

---

## Option 2: Delete Them

Delete:

```text
Controllers/WeatherForecastController.cs
WeatherForecast.cs
```

Then your project becomes cleaner:

```text
Controllers
└── EmployeesController.cs

Models
└── Employee.cs

Services
├── EmployeeService.cs
└── IEmployeeService.cs
```

For teaching freshers, deleting the WeatherForecast files after explaining that they came from the default template makes the project clearer.

---

# 9. Best Copilot Prompt Formula

Teach this formula:

```text
@workspace + existing files/classes + exact task + rules + expected output
```

Example:

```text
@workspace In this ASP.NET Core Web API project,
use Employee.cs, IEmployeeService.cs, EmployeeService.cs, and EmployeesController.cs.
Add a POST endpoint to create an employee.
Use async and await.
Use _employeeService.AddEmployeeAsync.
Return CreatedAtAction.
Do not create a new list in the controller.
```

This prompt is much better than:

```text
Create add employee API
```

---

# 10. Trainer Summary

You can explain like this:

> In this project, the workspace is the complete `EMPLOYEECONTEXTDEMO` folder. It contains controllers, models, services, configuration files, and project files. GitHub Copilot can use this workspace to understand how our application is designed.

Then continue:

> Without workspace context, Copilot may generate generic code. With workspace context, Copilot can understand that our controller should call `IEmployeeService`, our employee structure is in `Employee.cs`, and our service method is `AddEmployeeAsync`.

Final classroom sentence:

> Copilot is not just a code generator. It becomes more powerful when it understands the workspace. So always open the correct project folder, keep related files open, and give clear prompts using `@workspace` or manual context.

---

# 11. Complete Teaching Flow for Cohorts

Use the following teaching sequence:

```text
1. Show the VS Code Explorer and explain the workspace folder.
2. Explain Controllers, Models, Services, Program.cs, .csproj, .http, bin, and obj.
3. Open EmployeesController.cs and explain current file context.
4. Open Employee.cs, IEmployeeService.cs, and EmployeeService.cs and explain open tabs context.
5. Select GetEmployeeById method and explain selection context.
6. Ask Copilot a generic prompt without workspace context.
7. Show the wrong or generic output.
8. Explain the impact.
9. Ask Copilot using @workspace.
10. Show the improved output.
11. Add the POST method.
12. Run dotnet run.
13. Test in Swagger or .http file.
14. Summarize the difference between generic prompt and context-based prompt.
```

---

# 12. Final Key Points for Students

```text
Workspace means the complete project folder opened in VS Code.
Copilot gives better suggestions when it understands the workspace.
Current file context helps with the currently opened file.
Open tabs context helps Copilot understand related files.
Selection context helps Copilot follow a specific code pattern.
Terminal context helps with build and runtime errors.
@workspace tells Copilot to use the whole project as context.
Manual context is useful when @workspace is not available.
```

Final rule:

```text
Do not ask Copilot only what to create.
Tell Copilot where it should fit, which existing files to use, and what coding pattern to follow.
```
