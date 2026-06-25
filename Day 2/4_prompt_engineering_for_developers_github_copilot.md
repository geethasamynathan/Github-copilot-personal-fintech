# Prompt Engineering for Developers

**Prompt engineering for developers** means writing clear instructions to AI coding tools like **GitHub Copilot** so that they understand:

**what you want**,  
**where to apply it**,  
**which technology to use**,  
**what rules to follow**,  
**what output format you expect**,  
and **what should not be done**.

In simple words:

> Prompt engineering is the skill of asking GitHub Copilot the right question in the right way to get useful code, explanation, test cases, debugging help, documentation, or refactoring suggestions.

GitHub Copilot can provide inline code suggestions, answer coding questions in Copilot Chat, explain code, generate tests, suggest fixes, and work with your IDE context. GitHub also recommends using effective prompting techniques for Copilot Chat and keeping chat history relevant for better answers.

Reference: https://docs.github.com/copilot/concepts/prompt-engineering-for-copilot-chat

---

# Why Prompt Engineering is Important for Developers

A developer may ask:

> “Create login.”

This is too broad. Copilot may not know:

- Which technology?
- React, Angular, Java, Spring Boot, ASP.NET, Node.js?
- Login with database or hardcoded values?
- JWT or session?
- Validation needed or not?
- UI needed or only API?
- Which file should be modified?
- Should existing project structure be followed?

So Copilot may produce generic, incomplete, or mismatched code.

A better prompt is:

> “In this MERN stack project, create a login API using Express.js, MongoDB, bcrypt for password comparison, and JWT token generation. Follow the existing folder structure: routes, controllers, models, and middleware. Add proper validation and return meaningful error messages.”

Now Copilot understands the **role**, **technology**, **task**, **files**, **libraries**, **expected behavior**, and **quality requirements**.

---

# Prompt Engineering Formula for Developers

Use this simple formula:

```text
Role + Context + Task + Constraints + Output Format + Example/Reference
```

Example:

```text
You are a Java Spring Boot developer.
In my existing Employee Management project, create a REST API to add an employee.
Use Controller, Service, Repository, DTO, and Entity layers.
Validate employee name, email, department, and salary.
Return proper HTTP status codes.
Show me the files that need to be created or modified.
```

---

# Types of Prompts Used in GitHub Copilot

## 1. Inline Code Completion Prompt

This happens when you write comments or partial code in the editor, and Copilot suggests the remaining code.

Example:

```javascript
// Create a function to calculate total cart amount including tax
```

Copilot may generate:

```javascript
function calculateTotal(cartItems, taxRate) {
  const subtotal = cartItems.reduce((sum, item) => sum + item.price * item.quantity, 0);
  return subtotal + subtotal * taxRate;
}
```

**Where it is useful:**

- Creating small functions
- Writing repetitive code
- Generating boilerplate
- Completing conditions
- Creating DTOs, models, interfaces, test methods

---

## 2. Copilot Chat Prompt

This is used in the Copilot Chat window.

Example:

```text
Explain this controller method step by step.
```

Copilot Chat can explain code, generate unit tests, suggest code fixes, and answer coding-related questions inside the IDE.

Reference: https://docs.github.com/copilot/using-github-copilot/asking-github-copilot-questions-in-your-ide

**Where it is useful:**

- Understanding existing code
- Debugging errors
- Asking architecture questions
- Asking “why is this not working?”
- Asking Copilot to refactor selected code

---

## 3. Slash Command Prompt

Slash commands are short commands used for common tasks. For example, GitHub documents `/tests` for generating tests for the active file or selected code. Available slash commands may vary depending on the environment.

Reference: https://docs.github.com/en/copilot/tutorials/write-tests

Example:

```text
/tests using Jest framework
```

**Where it is useful:**

- Generate tests
- Explain selected code
- Fix code
- Create documentation
- Start common workflows quickly

---

## 4. Context-Based Prompt

This prompt uses the currently opened file, selected code, or workspace context.

Example:

```text
Using the selected ProductController code, add proper exception handling without changing the existing route names.
```

VS Code documentation explains that Copilot can understand codebases using tools like semantic search, text search, grep, file search, and language intelligence. This helps Copilot answer questions grounded in the actual workspace.

Reference: https://code.visualstudio.com/docs/copilot/reference/workspace-context

**Where it is useful:**

- Working with an existing project
- Modifying specific files
- Understanding where a feature is implemented
- Asking questions like “where is authentication handled?”

---

## 5. Step-by-Step Prompt

This asks Copilot to guide you gradually.

Example:

```text
Explain step by step how to create a CRUD API in ASP.NET Core Web API using Entity Framework Core and SQL Server.
```

**Where it is useful:**

- Learning new technology
- Teaching cohorts
- Creating tutorials
- Debugging complex issues
- Explaining project setup

---

## 6. Refactoring Prompt

This asks Copilot to improve existing code without changing behavior.

Example:

```text
Refactor this service class to follow clean code principles. Do not change the method names or API response structure.
```

**Where it is useful:**

- Improving readability
- Removing duplicate code
- Applying SOLID principles
- Moving logic from controller to service
- Improving maintainability

---

## 7. Debugging Prompt

This asks Copilot to identify and fix errors.

Example:

```text
I am getting NullReferenceException in this method. Analyze the code and explain the root cause. Then suggest the safest fix.
```

**Where it is useful:**

- Runtime errors
- Build errors
- API errors
- Database connection issues
- Test failures

---

## 8. Test Generation Prompt

This asks Copilot to create unit tests, integration tests, or test scenarios.

Example:

```text
Create unit tests for this EmployeeService using xUnit and Moq. Cover success, validation failure, and repository exception scenarios.
```

GitHub recommends reviewing generated tests because Copilot-generated tests may not cover all scenarios.

Reference: https://docs.github.com/en/copilot/tutorials/write-tests

---

## 9. Documentation Prompt

This asks Copilot to create comments, README files, API documentation, or cheat sheets.

Example:

```text
Create a developer-friendly README for this ASP.NET Core Web API project. Include setup steps, database migration steps, API endpoints, and testing instructions.
```

---

## 10. Custom Instruction / Prompt File Prompt

GitHub Copilot supports customization through instructions and prompt files. Prompt files can be Markdown files stored in the workspace and used to share reusable prompt instructions with additional context.

Reference: https://docs.github.com/enterprise-cloud%40latest/copilot/concepts/about-customizing-github-copilot-chat-responses

Example use case:

```text
Always follow clean architecture.
Use meaningful variable names.
Use repository and service layers.
Add comments only where needed.
Generate beginner-friendly explanations.
```

**Where it is useful:**

- Team coding standards
- Trainer-created project instructions
- Reusable prompts
- Consistent Copilot responses

---

# Good Prompt Structure for GitHub Copilot

A good developer prompt should include:

```text
1. Technology
2. Existing project context
3. Exact task
4. Expected files/layers
5. Validation rules
6. Error handling rules
7. Output format
8. What not to change
```

Example:

```text
I am working on an ASP.NET Core Web API project using Entity Framework Core and SQL Server.

Create an Employee CRUD module.

Use:
- Employee entity
- EmployeeDto
- IEmployeeRepository
- EmployeeRepository
- IEmployeeService
- EmployeeService
- EmployeesController

Requirements:
- Validate employee name, email, salary, and department
- Use async/await
- Return proper status codes
- Add try-catch in service layer
- Do not write business logic directly inside controller
- Show the complete code file by file
```

---

# Role-Based Scenarios: Bad Prompt vs Good Prompt

---

# 1. MERN Stack Developer

## Scenario

You are building an **e-commerce product management module** using:

- MongoDB
- Express.js
- React
- Node.js

You want to create a product API and connect it to React UI.

---

## Bad Prompt

```text
Create product page.
```

## What Copilot May Produce

Copilot may generate only a simple React component like this:

```javascript
function ProductPage() {
  return (
    <div>
      <h1>Product Page</h1>
      <p>List of products</p>
    </div>
  );
}

export default ProductPage;
```

## Problem with the Bad Prompt

This prompt is unclear because it does not say:

- Is it frontend or backend?
- Should it connect to MongoDB?
- Should products be added, edited, deleted?
- Which fields are required?
- Should there be API integration?
- Should stock status be shown?
- Should validation be added?
- Should existing folder structure be followed?

So Copilot may produce a very basic UI only.

---

## Good Prompt

```text
I am working on a MERN stack e-commerce project.

Create a Product Management module with backend and frontend code.

Backend requirements:
- Use Node.js, Express.js, and MongoDB with Mongoose.
- Create Product model with fields:
  productName, price, category, stock, imageUrl, sellerId.
- Create REST APIs:
  GET /api/products
  GET /api/products/:id
  POST /api/products
  PUT /api/products/:id
  DELETE /api/products/:id
- Add validation:
  productName is required
  price must be greater than 0
  stock must not be negative
- Use controller and route files separately.

Frontend requirements:
- Create React ProductList component.
- Fetch product data from GET /api/products using axios.
- Display product name, price, category, stock, and image.
- If stock is less than 5, show “Low Stock”.
- Add loading and error states.

Show the code file by file.
```

## What Copilot Will Produce Better

Copilot is more likely to create:

```text
backend/
  models/Product.js
  controllers/productController.js
  routes/productRoutes.js

frontend/
  components/ProductList.jsx
```

It may generate:

- Mongoose schema
- Express routes
- Controller methods
- React component
- Axios API call
- Conditional rendering for low stock
- Error and loading handling

## Why This Good Prompt Works

Because it gives:

- Technology stack
- Business scenario
- Backend requirements
- Frontend requirements
- API routes
- Validation rules
- UI behavior
- Expected output format

---

# 2. Java Full Stack Developer

## Scenario

You are building an **Employee Management System** using:

- Java
- Spring Boot
- Spring Data JPA
- MySQL
- React or Angular frontend

You want to create an employee REST API.

---

## Bad Prompt

```text
Create employee API in Java.
```

## What Copilot May Produce

Copilot may generate a single controller:

```java
@RestController
public class EmployeeController {

    @GetMapping("/employees")
    public List<String> getEmployees() {
        return List.of("John", "Priya", "Arun");
    }
}
```

## Problem with the Bad Prompt

This prompt does not mention:

- Spring Boot or plain Java?
- Database or hardcoded data?
- Entity required?
- Repository required?
- Service layer required?
- DTO required?
- Validation required?
- MySQL connection needed?
- Exception handling needed?

So Copilot may generate incomplete demo code.

---

## Good Prompt

```text
I am working on a Java Spring Boot Employee Management System using Spring Data JPA and MySQL.

Create a complete Employee CRUD REST API.

Use this layered structure:
- Employee entity
- EmployeeDto
- EmployeeRepository
- EmployeeService interface
- EmployeeServiceImpl
- EmployeeController
- GlobalExceptionHandler

Employee fields:
- employeeId
- employeeName
- email
- department
- salary
- joiningDate

Requirements:
- Use @Entity and @Table for Employee.
- Use JpaRepository for database operations.
- Use DTO for request and response.
- Add validation using jakarta.validation annotations.
- salary must be greater than 10000.
- email must be valid.
- Return ResponseEntity with proper HTTP status codes.
- Add exception handling for employee not found.
- Show code file by file.
```

## What Copilot Will Produce Better

Copilot may generate:

```text
Employee.java
EmployeeDto.java
EmployeeRepository.java
EmployeeService.java
EmployeeServiceImpl.java
EmployeeController.java
GlobalExceptionHandler.java
```

It may include:

```java
@NotBlank
@Email
@Min(10000)
```

It may also create:

```java
@GetMapping
@PostMapping
@PutMapping
@DeleteMapping
```

with `ResponseEntity`.

## Why This Good Prompt Works

Because it clearly explains:

- Framework
- Database
- Layered architecture
- Entity fields
- Validation
- Exception handling
- Expected code organization

This helps Copilot generate real project-level code instead of simple demo code.

---

# 3. .NET Full Stack Developer

## Scenario

You are building a **Customer Order Management System** using:

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Angular or React frontend

You want to create an Orders module.

---

## Bad Prompt

```text
Create order controller.
```

## What Copilot May Produce

Copilot may generate a simple controller:

```csharp
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetOrders()
    {
        return Ok(new[] { "Order1", "Order2" });
    }
}
```

## Problem with the Bad Prompt

This prompt does not tell Copilot:

- Should it use EF Core?
- What is the database table?
- What are the order fields?
- Is repository pattern needed?
- Is service layer needed?
- Should it include OrderItems?
- Should it calculate total amount?
- Should it validate stock?
- Should it use async methods?

So Copilot may generate a very basic controller.

---

## Good Prompt

```text
I am working on an ASP.NET Core Web API project using Entity Framework Core and SQL Server.

Create an Order Management module for an e-commerce application.

Use this structure:
- Order entity
- OrderItem entity
- OrderDto
- OrderItemDto
- IOrderRepository
- OrderRepository
- IOrderService
- OrderService
- OrdersController

Business requirements:
- One order can have multiple order items.
- Each order item should have productId, quantity, unitPrice, and lineTotal.
- Order should have customerId, orderDate, totalAmount, and orderStatus.
- Calculate totalAmount from order items.
- Validate that quantity must be greater than 0.
- Use async/await.
- Use dependency injection.
- Controller should call only service methods.
- Repository should handle database operations.
- Service should handle business logic.
- Return proper HTTP status codes.
- Add exception handling for order not found.

Show complete code file by file.
```

## What Copilot Will Produce Better

Copilot may generate:

```text
Entities/
  Order.cs
  OrderItem.cs

DTOs/
  OrderDto.cs
  OrderItemDto.cs

Repositories/
  IOrderRepository.cs
  OrderRepository.cs

Services/
  IOrderService.cs
  OrderService.cs

Controllers/
  OrdersController.cs
```

It may include:

```csharp
public decimal TotalAmount { get; set; }
```

and logic like:

```csharp
order.TotalAmount = order.OrderItems.Sum(i => i.Quantity * i.UnitPrice);
```

## Why This Good Prompt Works

Because it provides:

- Technology stack
- Architecture pattern
- Business rules
- Entity relationship
- Validation rules
- Layer responsibility
- Output format

This helps Copilot create practical full-stack backend code instead of a simple controller.

---

# 4. Tester / QA Analyst

## Scenario

A QA analyst wants to test a **login feature** in a web application.

The login feature has:

- Email
- Password
- Remember Me
- Forgot Password
- Login button
- Validation messages

---

## Bad Prompt

```text
Write test cases for login.
```

## What Copilot May Produce

Copilot may produce generic test cases like:

```text
1. Verify user can login with valid credentials.
2. Verify user cannot login with invalid credentials.
3. Verify error message is shown.
```

## Problem with the Bad Prompt

This prompt does not mention:

- Manual test cases or automation script?
- Positive and negative scenarios?
- Browser compatibility?
- Security test cases?
- Validation rules?
- Expected result format?
- Test data?
- Priority?
- Severity?
- Excel-style format?
- Selenium, Cypress, Playwright, or Postman?

So Copilot may generate very basic test cases.

---

## Good Prompt

```text
You are a QA analyst.

Create detailed manual test cases for a login page of an e-commerce web application.

Login page fields:
- Email
- Password
- Remember Me checkbox
- Forgot Password link
- Login button

Validation rules:
- Email is required.
- Email must be in valid format.
- Password is required.
- Password must be at least 8 characters.
- Show error message for invalid credentials.
- Lock account after 5 failed login attempts.

Prepare test cases in table format with these columns:
- Test Case ID
- Test Scenario
- Precondition
- Test Steps
- Test Data
- Expected Result
- Actual Result
- Status
- Priority

Include:
- Positive test cases
- Negative test cases
- Boundary test cases
- Security test cases
- UI test cases
```

## What Copilot Will Produce Better

Copilot may produce a detailed QA table like:

| Test Case ID | Test Scenario | Test Data | Expected Result |
|---|---|---|---|
| TC_LOGIN_001 | Login with valid credentials | valid email, valid password | User should login successfully |
| TC_LOGIN_002 | Login with empty email | empty email | Email required message should display |
| TC_LOGIN_003 | Login with invalid email format | abc.com | Invalid email message should display |
| TC_LOGIN_004 | Login with wrong password | valid email, wrong password | Invalid credentials message should display |
| TC_LOGIN_005 | Account lock after 5 failed attempts | wrong password 5 times | Account should be locked |

## Why This Good Prompt Works

Because it tells Copilot:

- Role
- Application type
- Feature under test
- Field details
- Validation rules
- Output format
- Test case categories
- Required table columns

This produces professional QA output.

---

# More Role-Based Bad vs Good Prompt Examples

---

# MERN Stack Developer Example: Authentication

## Bad Prompt

```text
Add authentication.
```

## What It May Produce

Copilot may create a simple login form only.

## Good Prompt

```text
In my MERN stack application, implement JWT-based authentication.

Backend:
- Create User model with name, email, password, and role.
- Hash password using bcrypt.
- Create register and login APIs.
- Generate JWT token on successful login.
- Create auth middleware to protect routes.

Frontend:
- Create Login and Register components.
- Store token in localStorage.
- Redirect user to dashboard after login.
- Show validation errors.

Do not use hardcoded users.
Show code file by file.
```

---

# Java Full Stack Developer Example: Bug Fix

## Bad Prompt

```text
Fix this error.
```

## What It May Produce

Copilot may guess the issue and suggest a random fix.

## Good Prompt

```text
I am getting this error in my Spring Boot application:

"could not execute statement; SQL constraint violation"

Analyze the Employee entity, EmployeeRepository, and EmployeeService code.

Find the possible root cause.
Explain why the error occurs.
Suggest the correct fix.
Do not change the database column names unless required.
```

---

# .NET Full Stack Developer Example: Repository Pattern

## Bad Prompt

```text
Use repository pattern.
```

## What It May Produce

Copilot may create only one interface or incomplete repository.

## Good Prompt

```text
Refactor this ASP.NET Core Web API controller to use repository and service layers.

Current issue:
- Controller directly uses DbContext.
- Business logic is inside controller.

Required structure:
- ICustomerRepository
- CustomerRepository
- ICustomerService
- CustomerService
- CustomersController

Rules:
- Repository should contain only database logic.
- Service should contain business validation.
- Controller should only handle HTTP request and response.
- Use async/await.
- Do not change existing API route names.
```

---

# QA Analyst Example: Automation Testing

## Bad Prompt

```text
Write automation for login.
```

## What It May Produce

Copilot may generate random Selenium or Cypress code without knowing your framework.

## Good Prompt

```text
Create Cypress automation test cases for the login page.

Application URL:
http://localhost:3000/login

Fields:
- email input has data-testid="email"
- password input has data-testid="password"
- login button has data-testid="login-button"

Test scenarios:
1. Login with valid credentials.
2. Show error for empty email.
3. Show error for invalid email format.
4. Show error for empty password.
5. Show error for invalid credentials.

Use Cypress best practices.
Use describe and it blocks.
Add assertions for URL redirection and error messages.
```

---

# Practical Prompt Types for GitHub Copilot by Developer Role

| Developer Role | Prompt Type | Example Use |
|---|---|---|
| MERN Stack Developer | Code generation prompt | Create Express API, React component, MongoDB model |
| MERN Stack Developer | Debugging prompt | Fix CORS, API call, state update issue |
| MERN Stack Developer | Refactoring prompt | Move API logic into service file |
| Java Full Stack Developer | Layered architecture prompt | Generate Controller, Service, Repository |
| Java Full Stack Developer | Validation prompt | Add DTO validation using annotations |
| Java Full Stack Developer | Exception handling prompt | Add global exception handler |
| .NET Full Stack Developer | Repository/service prompt | Refactor controller to service pattern |
| .NET Full Stack Developer | EF Core prompt | Create entity relationships and migrations |
| .NET Full Stack Developer | API prompt | Create CRUD API with ResponseEntity-like IActionResult |
| QA Analyst | Manual test case prompt | Generate Excel-style test cases |
| QA Analyst | Automation prompt | Generate Selenium, Cypress, Playwright scripts |
| QA Analyst | Bug report prompt | Create defect report with severity and priority |

---

# Common Mistakes in Developer Prompts

## Mistake 1: Too Short

Bad:

```text
Create API.
```

Better:

```text
Create an ASP.NET Core Web API for Customer CRUD using EF Core and SQL Server with repository and service layers.
```

---

## Mistake 2: No Technology Mentioned

Bad:

```text
Create login page.
```

Better:

```text
Create a React login page using functional components, useState, form validation, and axios API call to /api/auth/login.
```

---

## Mistake 3: No Existing Project Context

Bad:

```text
Add product feature.
```

Better:

```text
In my existing MERN e-commerce project, add product CRUD using the existing folders: models, routes, controllers, and components.
```

---

## Mistake 4: No Output Format

Bad:

```text
Explain this.
```

Better:

```text
Explain this code step by step in beginner-friendly language. Also add a small real-world example.
```

---

## Mistake 5: No Constraints

Bad:

```text
Refactor this code.
```

Better:

```text
Refactor this code for readability. Do not change method names, route names, API response format, or database table names.
```

---

# Best Prompt Template for Developers

You can give this template to your cohorts:

```text
I am working on a [technology/project type] project.

Current requirement:
[Explain the feature or issue]

Existing context:
[Mention files, folders, selected code, database tables, APIs, or framework]

Please do:
[List exact tasks]

Rules:
[Mention architecture, validation, naming convention, security, performance, etc.]

Do not:
[Mention what Copilot should not change]

Output format:
[File-by-file code / step-by-step explanation / table / test cases / checklist]
```

---

# Example Final Prompt for Any Developer

```text
I am working on an ASP.NET Core Web API project using Entity Framework Core and SQL Server.

I need to create a Customer CRUD module.

Existing architecture:
- Controllers folder
- Services folder
- Repositories folder
- Models folder
- DTOs folder

Please create:
- Customer model
- CustomerDto
- ICustomerRepository
- CustomerRepository
- ICustomerService
- CustomerService
- CustomersController

Requirements:
- Use async/await.
- Validate customer name, email, phone, and city.
- Email should be valid.
- Phone number should be 10 digits.
- Return proper HTTP status codes.
- Add exception handling.
- Do not write business logic inside controller.
- Show the complete code file by file.
```

---

# Trainer Explanation: How Copilot Understands a Good Prompt

When you give a good prompt, Copilot uses:

1. **Natural language understanding**  
   It understands your instruction.

2. **Code context**  
   It checks the currently opened file, selected code, or workspace.

3. **Pattern matching**  
   It identifies existing project patterns, naming conventions, and folder structure.

4. **Technology prediction**  
   It understands whether you are using React, Node.js, Spring Boot, ASP.NET Core, SQL Server, MySQL, etc.

5. **Code generation**  
   It suggests code based on your requirement and context.

6. **Iteration**  
   You can refine the prompt if the first output is incomplete.

Example:

```text
First prompt:
Create Employee CRUD API.

Second prompt:
Now add validation and exception handling.

Third prompt:
Now refactor this using repository and service layers.

Fourth prompt:
Now generate unit tests for EmployeeService.
```

This is called **iterative prompting**.

---

# Final Summary

Prompt engineering for developers is not just “asking AI to write code.” It is the skill of giving **clear, contextual, role-based, and constraint-based instructions**.

A poor prompt gives generic output.

A good prompt gives project-ready output.

For GitHub Copilot, good prompts should include:

```text
Technology + Context + Task + Rules + Output Format
```

Best practice:

```text
Do not ask:
"Create API"

Ask:
"Create an ASP.NET Core Web API Customer CRUD module using EF Core, SQL Server, repository pattern, service layer, validation, exception handling, and show code file by file."
```

That is the real difference between beginner-level Copilot usage and professional developer-level Copilot usage.
