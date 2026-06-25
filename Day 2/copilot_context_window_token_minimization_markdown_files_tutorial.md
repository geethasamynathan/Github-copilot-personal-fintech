 Copilot Context Window Limitations, Token Minimization, and Markdown Files in Plan vs Agent Execution

This tutorial is based on the **current GitHub Copilot / VS Code Copilot customization model**. I am intentionally avoiding older Copilot options and older terminology such as old “chat mode” naming. In the latest VS Code documentation, these are now referred to as **custom agents**; existing `.chatmode.md` files are expected to be renamed to `.agent.md` for the current agent format.

---

# 1. What is Copilot Context?

When you ask GitHub Copilot something, it does not magically know the whole project equally.

It prepares a **context package** and sends that to the selected AI model.

That context may include:

```text
Your current prompt
Currently opened file
Selected code
Nearby code around the cursor
Workspace information
Relevant files
Custom instructions
Prompt files
Agent instructions
Tool results
Previous conversation history
Terminal output
Errors and diagnostics
```

GitHub explains that Copilot uses information such as the active editor content, selected code, open files, repository URLs or file paths, frameworks, languages, and dependencies to build a contextual prompt.

---

# 2. What is a Context Window?

A **context window** is the maximum amount of information the model can consider in one request.

It is measured in **tokens**.

A token is not exactly a word. A token can be:

```text
A full short word
Part of a long word
A symbol
A punctuation mark
A piece of code
A newline
```

GitHub’s Copilot CLI documentation says the context window has a fixed size, measured in tokens, and that size varies by model.

---

# 3. Why Context Window Size Matters

Copilot cannot keep infinite code, documents, logs, and conversation history in memory for every answer.

When the context becomes too large, Copilot must choose what to include and what to ignore.

That means Copilot may miss:

```text
Some files
Some previous instructions
Some old conversation messages
Some project rules
Some terminal output
Some edge-case requirements
Some business logic from another folder
```

So, a larger context window helps, but it does not remove the need for good prompting and good project organization.

---

# 4. Current Context Size Reality in Copilot

The exact available context depends on:

```text
Selected model
Copilot product surface
IDE support
Plan type
Organization policy
Whether extended context is enabled
Tool execution needs
Output reservation
```

GitHub now documents that some supported Copilot models can offer a **1 million token context window**, and when a supported model is selected, users may choose between default context size and extended context.

For Copilot CLI, GitHub also states that the latest models support a **1 million token context window** for larger codebases, long documents, and complex multi-file projects.

However, do not teach students that “Copilot always has 1 million tokens.” The safer teaching point is:

> Copilot context size is model-dependent. Some latest models support extended context, but the effective context available in a particular Copilot experience can vary.

---

# 5. Important Limitation: Large Context Does Not Mean Perfect Understanding

Even if a model supports a very large context window, it does not mean Copilot will always understand everything perfectly.

Common limitations:

```text
It may focus on the wrong files.
It may miss hidden business rules.
It may summarize earlier conversation.
It may ignore less relevant content.
It may misunderstand outdated comments.
It may include too much irrelevant context.
It may produce slower responses with huge context.
```

In VS Code, when the context window fills up, Copilot can automatically compact earlier conversation history by summarizing previous messages. This allows the conversation to continue, but summaries are never as detailed as the original messages.

---

# 6. Context Window Example

Assume you have an ASP.NET Core Web API project:

```text
Controllers
Services
Repositories
Models
DTOs
Program.cs
appsettings.json
README.md
.github/copilot-instructions.md
```

You ask:

```text
Add exception handling for all service methods.
```

This is a weak prompt.

Copilot has to guess:

```text
Which service methods?
What exception format?
Should it use middleware?
Should it use try-catch?
Should it log errors?
Should it change controllers also?
Should it create custom exceptions?
```

A better prompt:

```text
In this ASP.NET Core 8 Web API project, update only the Services folder.
Follow the existing ApiResponse<T> pattern.
Use custom NotFoundException and BadRequestException where needed.
Do not change database models.
After changes, show the modified files and explain why each change was made.
```

This prompt reduces confusion and saves context because Copilot does not need to infer everything.

---

# 7. What Consumes Tokens in Copilot?

Tokens are consumed by both your input and Copilot’s output.

## Input tokens

```text
Your prompt
Selected code
Opened file content
Referenced files
Custom instructions
Prompt files
Agent files
Terminal logs
Error messages
Conversation history
Tool results
```

## Output tokens

```text
Copilot explanation
Generated code
Patch suggestions
Test output explanation
Plan steps
Command suggestions
Markdown tables
Repeated summaries
```

So, token minimization is not only about writing a short prompt. It is about giving **focused, relevant, high-value context**.

---

# 8. Why Too Much Context Can Reduce Quality

Many learners think:

> “I will give Copilot everything, then it will answer better.”

Not always.

Too much context can cause:

```text
More irrelevant information
Higher chance of contradiction
Slower response
More expensive model usage in some surfaces
Less focus on the actual task
Wrong file selection
Long unnecessary explanations
```

Good Copilot usage is not “maximum context.”

Good Copilot usage is:

> Right context, right file, right instruction, right scope.

---

# 9. Token Minimization Techniques

## Technique 1: Ask for one task at a time

Bad prompt:

```text
Explain this project, fix bugs, add validation, create tests, update README, and optimize database queries.
```

Good prompt:

```text
First analyze the login validation flow only.
Do not modify files yet.
List the files involved and explain the current behavior.
```

Then:

```text
Now update only the validation logic.
Keep the existing UI structure unchanged.
```

---

## Technique 2: Select only relevant code

Instead of asking Copilot to inspect the whole project, select the exact method or class.

Bad:

```text
Fix this project.
```

Good:

```text
Review the selected LoginService.ValidateUser method.
Find validation issues only.
Do not rewrite unrelated code.
```

---

## Technique 3: Keep prompts structured

Use this format:

```text
Goal:
Scope:
Rules:
Files:
Output:
```

Example:

```text
Goal:
Add empty username and password validation.

Scope:
Modify only LoginForm.js and validation.js.

Rules:
Do not change CSS class names.
Do not change API call logic.
Show error messages below each field.

Output:
Provide the final modified code and a short explanation.
```

This reduces unnecessary back-and-forth.

---

## Technique 4: Avoid repeated long explanations

Bad:

```text
Explain everything in detail every time you make a change.
```

Better:

```text
Give a short explanation only for changed files.
```

---

## Technique 5: Do not paste huge logs

Bad:

```text
Paste 500 lines of build output.
```

Better:

```text
Paste only the first error, stack trace, and the command used.
```

Example:

```text
Command:
dotnet build

Error:
CS1061: 'UserService' does not contain a definition for 'GetUserByEmail'

Relevant file:
UserService.cs
```

---

## Technique 6: Use repository instructions for stable rules

Do not repeat the same project rules in every prompt.

Instead, store them in:

```text
.github/copilot-instructions.md
```

VS Code and GitHub documentation both describe `.github/copilot-instructions.md` as the repository-level custom instruction file used to guide Copilot responses for a project.

---

# 10. What are Markdown Files in Copilot?

Markdown files are used to give Copilot reusable instructions.

Current Copilot customization commonly uses these file types:

```text
.github/copilot-instructions.md
.github/instructions/*.instructions.md
*.prompt.md
*.agent.md
AGENTS.md
```

Different files have different roles.

---

# 11. Repository Custom Instructions

## File

```text
.github/copilot-instructions.md
```

## Purpose

This file gives Copilot common project rules.

Example:

```markdown
# Copilot Instructions

This is an ASP.NET Core 8 Web API project.

## Architecture Rules
- Controllers should only handle HTTP request and response.
- Business logic must be placed in Services.
- Database logic must be placed in Repositories.
- Use DTOs for request and response models.
- Do not expose EF Core entities directly from controllers.

## Coding Rules
- Use async/await for database operations.
- Use dependency injection.
- Use ApiResponse<T> for all API responses.
- Use custom exceptions for validation and not-found cases.

## Testing Rules
- Add unit tests for service logic.
- Do not test EF Core directly in controller tests.
```

## When it applies

This file is automatically used as project-level guidance in supported Copilot experiences.

VS Code documentation says custom instructions let you define common rules that automatically influence code generation and other development tasks.

---

# 12. Path-Specific Instruction Files

## File pattern

```text
.github/instructions/*.instructions.md
```

Example:

```text
.github/instructions/api.instructions.md
.github/instructions/database.instructions.md
.github/instructions/frontend.instructions.md
```

## Purpose

Use these when different folders need different rules.

Example:

```markdown
---
applyTo: "Controllers/**/*.cs"
---

# Controller Instructions

- Controllers must not contain business logic.
- Use IActionResult or ActionResult<T>.
- Validate request DTOs before calling services.
- Return ApiResponse<T>.
```

Another example:

```markdown
---
applyTo: "Repositories/**/*.cs"
---

# Repository Instructions

- Use EF Core async methods.
- Do not return IQueryable from repository methods.
- Keep repository methods focused on database access only.
```

## Why this saves tokens

Instead of one huge instruction file, path-specific instructions apply only when relevant.

That helps Copilot focus on the correct rules for the file being edited.

---

# 13. Prompt Files

## File pattern

```text
*.prompt.md
```

Example:

```text
create-service.prompt.md
review-api.prompt.md
generate-tests.prompt.md
```

## Purpose

A prompt file is a reusable prompt for a repeated task.

GitHub describes prompt files as reusable prompt examples for common development tasks, and notes that prompt files are available in VS Code, Visual Studio, and JetBrains IDEs.

## Example

```markdown
# Generate Service Layer

Create a service class and interface for the selected entity.

Rules:
- Follow existing project naming conventions.
- Use async/await.
- Use repository interface.
- Throw NotFoundException when record is missing.
- Return DTOs, not EF Core entities.

Output:
- Interface
- Service implementation
- DI registration line
```

## When to use

Use prompt files for repeatable work such as:

```text
Generate service layer
Create unit tests
Review API controller
Create DTOs
Generate repository
Explain selected file
Create migration checklist
```

---

# 14. Agent Files

## File pattern

```text
*.agent.md
```

Example:

```text
api-reviewer.agent.md
test-writer.agent.md
bug-fixer.agent.md
migration-planner.agent.md
```

## Purpose

A custom agent defines a specialized Copilot behavior for a specific workflow.

VS Code documentation says custom agents let you tailor AI chat behavior for specific workflows and development scenarios. It also says custom agents were previously known by an older name, but the current terminology is **custom agents**.

## Example

```markdown
---
description: Reviews ASP.NET Core Web API code for architecture, validation, and maintainability.
tools: ["codebase", "editFiles", "runCommands"]
---

# API Reviewer Agent

You are an ASP.NET Core Web API reviewer.

Responsibilities:
- Review controllers, services, repositories, and DTOs.
- Identify SOLID violations.
- Check if business logic is inside controllers.
- Check if async/await is used properly.
- Check whether ApiResponse<T> is used consistently.

Rules:
- Do not rewrite files unless explicitly asked.
- First provide findings.
- Then suggest safe changes.
- Prefer small changes over large rewrites.
```

---

# 15. AGENTS.md

## File

```text
AGENTS.md
```

## Purpose

`AGENTS.md` is used to provide agent-oriented instructions. GitHub’s custom instruction support table lists agent instructions such as `AGENTS.md`, `CLAUDE.md`, or `GEMINI.md` for Copilot cloud agent support.

A practical `AGENTS.md` file may contain:

```markdown
# Agent Instructions

## Project Overview
This project is an ASP.NET Core 8 Web API for Digital Gold Wallet.

## Build
Run:
dotnet build

## Test
Run:
dotnet test

## Rules
- Do not change database table names.
- Do not expose EF Core entities from controllers.
- Keep controller logic minimal.
- Use services for business logic.
- Use repositories for database access.

## Validation
Before completing a task:
1. Run dotnet build.
2. Check for compile errors.
3. Summarize modified files.
```

---

# 16. Plan vs Agent Execution

This is one of the most important teaching areas.

## Plan

A **Plan** is used before execution.

The goal is to understand the task, inspect the codebase, and prepare implementation steps.

Plan should answer:

```text
What needs to be changed?
Which files are involved?
What risks exist?
What order should changes be made?
What should be tested?
```

## Agent Execution

An **Agent** performs the implementation.

The agent can:

```text
Read files
Edit files
Run commands
Inspect errors
Apply fixes
Run tests
Iterate on failures
Summarize changes
```

VS Code’s agent documentation explains that models themselves only produce text; the coding harness bridges the model and the editor by applying edits, executing commands, and feeding results back to the model.

---

# 17. Simple Difference Between Plan and Agent

| Area | Plan | Agent Execution |
|---|---|---|
| Main purpose | Think and design | Implement and verify |
| File changes | Usually no | Yes |
| Best for | Architecture, task breakdown, risk analysis | Coding, fixing, testing |
| Output | Steps, affected files, approach | Modified code and results |
| Tool usage | Limited or analysis-focused | File editing, terminal, tests |
| Risk | Low | Higher because files can change |

---

# 18. Example: Plan First, Then Agent

## User task

```text
Add refresh token support to this ASP.NET Core Web API.
```

## Plan prompt

```text
Create an implementation plan for adding refresh token support.
Do not modify files yet.

Analyze:
- Existing authentication flow
- Required model changes
- Required DTO changes
- Required service changes
- Required controller endpoints
- Security risks
- Testing checklist

Output:
- Files likely to change
- Step-by-step plan
- Questions or assumptions
```

## Expected Plan output

```text
1. Inspect current authentication flow.
2. Check User model and AuthService.
3. Add RefreshToken and RefreshTokenExpiry fields.
4. Create RefreshTokenRequestDto.
5. Add GenerateRefreshToken method.
6. Add /api/auth/refresh endpoint.
7. Update login response.
8. Add tests.
9. Run dotnet build and dotnet test.
```

## Agent execution prompt

```text
Implement the approved refresh token plan.

Rules:
- Modify only AuthController, AuthService, DTOs, and User model.
- Use secure random token generation.
- Keep existing JWT behavior unchanged.
- Run dotnet build after changes.
- Summarize modified files and test result.
```

---

# 19. Role of Markdown Files in Plan

During planning, markdown files help Copilot understand:

```text
Project architecture
Coding standards
Folder responsibilities
Testing strategy
Business rules
What not to change
```

Useful files for planning:

```text
README.md
ARCHITECTURE.md
.github/copilot-instructions.md
.github/instructions/*.instructions.md
*.prompt.md
AGENTS.md
```

## Example planning instruction

```markdown
# Planning Rules

Before implementation:
- Identify all affected files.
- Check existing architecture.
- Do not suggest large rewrites unless necessary.
- Prefer minimal safe changes.
- Mention risks before coding.
```

This helps Copilot create better plans.

---

# 20. Role of Markdown Files in Agent Execution

During agent execution, markdown files help Copilot follow rules while editing.

They can tell the agent:

```text
How to build the project
How to run tests
Which folders are allowed
Which commands are safe
Which files must not be changed
What coding style to follow
How to validate success
```

Example:

```markdown
# Execution Rules

When implementing changes:
- Make small commits logically.
- Do not rename public APIs unless requested.
- Run dotnet build after code changes.
- If build fails, fix only errors caused by your changes.
- Do not modify appsettings.Production.json.
```

This is very useful for enterprise projects.

---

# 21. Markdown File Strategy for a .NET Project

For a C#/.NET training project, use this structure:

```text
.github/
    copilot-instructions.md
    instructions/
        controllers.instructions.md
        services.instructions.md
        repositories.instructions.md
        tests.instructions.md

prompts/
    explain-code.prompt.md
    create-service.prompt.md
    generate-tests.prompt.md
    review-controller.prompt.md

agents/
    api-reviewer.agent.md
    service-builder.agent.md
    test-writer.agent.md

AGENTS.md
README.md
ARCHITECTURE.md
```

---

# 22. Recommended `.github/copilot-instructions.md`

```markdown
# Copilot Instructions for ASP.NET Core Web API

## Project Type
This is an ASP.NET Core 8 Web API project using Entity Framework Core and SQL Server.

## Architecture
- Controllers handle HTTP requests and responses only.
- Services contain business logic.
- Repositories contain database access logic.
- DTOs are used for API input and output.
- EF Core entities must not be exposed directly from controllers.

## Coding Standards
- Use async/await for database operations.
- Use dependency injection.
- Use meaningful exception types.
- Avoid duplicate code.
- Keep methods small and readable.

## API Response
- Use ApiResponse<T> for successful and failed responses.
- Do not return raw exception messages to the client.

## Validation
- Validate request DTOs before business logic.
- Throw BadRequestException for invalid input.
- Throw NotFoundException for missing records.

## Testing
- Add unit tests for service logic.
- Mock repositories in service tests.
- Run dotnet build after code changes.
```

---

# 23. Recommended `services.instructions.md`

```markdown
---
applyTo: "Services/**/*.cs"
---

# Service Layer Instructions

- Services must contain business logic.
- Services must not directly use DbContext.
- Use repository interfaces for data access.
- Use async/await.
- Validate input before calling repository methods.
- Throw NotFoundException when an entity is missing.
- Do not return EF Core entities directly.
```

---

# 24. Recommended `controllers.instructions.md`

```markdown
---
applyTo: "Controllers/**/*.cs"
---

# Controller Instructions

- Controllers must be thin.
- Do not write business logic inside controllers.
- Call service interfaces only.
- Use DTOs for request and response.
- Return IActionResult or ActionResult<T>.
- Use ApiResponse<T> consistently.
- Do not expose stack traces.
```

---

# 25. Recommended `repositories.instructions.md`

```markdown
---
applyTo: "Repositories/**/*.cs"
---

# Repository Instructions

- Repositories must contain only database access logic.
- Use EF Core async methods.
- Do not include business validation.
- Do not return IQueryable to services.
- Keep queries readable.
- Use AsNoTracking for read-only queries where appropriate.
```

---

# 26. Recommended `AGENTS.md`

```markdown
# Agent Instructions

## Project
ASP.NET Core 8 Web API using EF Core and SQL Server.

## Build Command
dotnet build

## Test Command
dotnet test

## Safe Execution Rules
- Do not modify database schema unless requested.
- Do not change connection strings.
- Do not update production configuration files.
- Do not remove existing public API endpoints.
- Do not rename classes without explaining why.

## Completion Checklist
Before finishing:
1. Summarize modified files.
2. Explain why each file changed.
3. Run build if code was modified.
4. Report build or test result.
```

---

# 27. Prompt File Example for Planning

File:

```text
feature-plan.prompt.md
```

Content:

```markdown
# Feature Planning Prompt

Create a detailed implementation plan for the requested feature.

Do not modify files.

Analyze:
- Current architecture
- Existing related files
- Required changes
- Risk areas
- Test cases
- Build impact

Output format:
1. Summary
2. Files to inspect
3. Files likely to change
4. Implementation steps
5. Risks
6. Testing checklist
```

Use it when you want Copilot to think before coding.

---

# 28. Prompt File Example for Execution

File:

```text
safe-implementation.prompt.md
```

Content:

```markdown
# Safe Implementation Prompt

Implement the requested change using the approved plan.

Rules:
- Make minimal changes.
- Follow repository instructions.
- Do not rewrite unrelated code.
- Preserve existing public API behavior unless requested.
- Run build after changes.
- Explain modified files.

Output:
- Summary of changes
- Modified files
- Build/test result
- Any remaining issues
```

---

# 29. Agent File Example for API Review

File:

```text
api-reviewer.agent.md
```

Content:

```markdown
---
description: Reviews ASP.NET Core Web API code for architecture and maintainability.
tools: ["codebase", "editFiles", "runCommands"]
---

# API Reviewer Agent

You are a senior ASP.NET Core Web API reviewer.

Review for:
- SOLID principle violations
- Controller business logic
- Service/repository separation
- DTO usage
- Exception handling
- Async/await usage
- Dependency injection correctness

Rules:
- First analyze.
- Do not edit unless asked.
- Give practical recommendations.
- Prefer minimal safe improvements.
```

---

# 30. Agent File Example for Test Writing

File:

```text
test-writer.agent.md
```

Content:

```markdown
---
description: Creates unit tests for .NET service layer logic.
tools: ["codebase", "editFiles", "runCommands"]
---

# Test Writer Agent

You are a .NET unit testing assistant.

Rules:
- Write tests for service layer logic.
- Mock repositories.
- Do not test EF Core internals.
- Use Arrange, Act, Assert.
- Cover success, validation failure, and not-found cases.
- Run dotnet test after creating tests.
```

---

# 31. Markdown Files and Token Minimization

Markdown files reduce token waste because you do not need to repeat the same rules in every prompt.

Instead of writing this every time:

```text
Use service layer, repository pattern, DTOs, async/await, ApiResponse<T>,
custom exceptions, do not expose entities, run dotnet build...
```

Put it once in:

```text
.github/copilot-instructions.md
```

Then your prompt can be shorter:

```text
Create a service for VendorBranch following project instructions.
```

This is cleaner and more consistent.

---

# 32. But Markdown Files Also Consume Context

Important point:

Markdown instructions are helpful, but they are not free.

They also consume context tokens.

So do not create very large instruction files.

Bad instruction file:

```text
500 lines of theory
Long examples for every possible case
Repeated rules
Old project history
Multiple unrelated technologies
```

Good instruction file:

```text
Short rules
Project-specific standards
Clear do/don’t points
Build/test commands
Architecture boundaries
```

---

# 33. Best Practice: Keep Instructions Short

Recommended size:

```text
copilot-instructions.md     → short project-wide rules
*.instructions.md           → folder-specific rules
*.prompt.md                 → reusable task prompts
*.agent.md                  → specialized workflow behavior
AGENTS.md                   → agent execution and validation rules
```

Avoid putting all rules into one huge file.

---

# 34. Copilot Plan vs Agent: Markdown File Usage Comparison

| Markdown file | Best for Plan | Best for Agent Execution |
|---|---:|---:|
| `README.md` | Yes | Sometimes |
| `ARCHITECTURE.md` | Yes | Yes |
| `.github/copilot-instructions.md` | Yes | Yes |
| `.github/instructions/*.instructions.md` | Yes | Yes |
| `*.prompt.md` | Yes | Yes |
| `*.agent.md` | Sometimes | Yes |
| `AGENTS.md` | Sometimes | Yes |

---

# 35. Teaching Example: Without Markdown Instructions

Prompt:

```text
Add product search API.
```

Possible Copilot issues:

```text
May put logic in controller
May expose EF entity directly
May skip DTO
May not use async
May ignore ApiResponse<T>
May not add validation
May not run build
```

---

# 36. Teaching Example: With Markdown Instructions

Prompt:

```text
Add product search API by product name and category.
Follow project instructions.
Create plan first.
Do not modify files until plan is approved.
```

Better Copilot behavior:

```text
Checks architecture
Identifies controller/service/repository changes
Uses DTOs
Follows ApiResponse<T>
Uses async repository method
Suggests validation
Provides testing checklist
```

---

# 37. Common Mistakes to Avoid

## Mistake 1: Very large prompts

Do not paste the entire project into chat.

Use file references, selection, or workspace context.

---

## Mistake 2: Too many goals in one prompt

Do not ask Copilot to design, implement, test, optimize, document, and refactor all at once.

Split the work.

---

## Mistake 3: Huge instruction files

Instruction files should guide Copilot, not become a textbook.

---

## Mistake 4: Contradictory instructions

Bad:

```text
Use repository pattern.
Do not create repositories.
Put database logic in service.
```

Copilot will get confused.

---

## Mistake 5: Not separating Plan and Execution

For large work, always ask for a plan first.

Then ask the agent to execute the approved plan.

---

# 38. Practical Prompt Templates

## Template 1: Planning

```text
Create a plan for this feature.
Do not edit files.

Feature:
[Describe feature]

Analyze:
- Existing files involved
- Architecture impact
- Required changes
- Risks
- Test checklist

Output:
Step-by-step implementation plan.
```

---

## Template 2: Safe Agent Execution

```text
Implement the approved plan.

Rules:
- Follow repository instructions.
- Make minimal changes.
- Do not modify unrelated files.
- Run build after changes.
- Summarize modified files and result.
```

---

## Template 3: Token-Minimized Debugging

```text
Fix this error.

Command:
[paste command]

Error:
[paste only relevant error]

Relevant files:
[file names]

Rules:
- Explain root cause.
- Modify only required files.
- Do not rewrite unrelated code.
```

---

## Template 4: Code Review

```text
Review the selected code only.

Check:
- SOLID principles
- Error handling
- Async/await
- Dependency injection
- Maintainability

Do not modify files.
Give findings and recommended fixes.
```

---

# 39. Trainer Demo Flow

Use this flow in class:

```text
Step 1: Show weak prompt
Step 2: Show wrong or incomplete Copilot response
Step 3: Add copilot-instructions.md
Step 4: Add folder-specific instructions
Step 5: Ask Copilot to create a plan
Step 6: Review the plan
Step 7: Ask Agent to implement
Step 8: Run build/test
Step 9: Compare quality before and after instructions
```

---

# 40. Final Summary

GitHub Copilot works best when we manage context carefully.

The key points are:

```text
Context window is limited and model-dependent.
More context is not always better.
Tokens are consumed by prompts, files, instructions, logs, tools, and output.
Markdown files help reduce repeated prompting.
Repository instructions define stable project rules.
Path-specific instructions guide folder-level behavior.
Prompt files standardize repeated tasks.
Agent files define specialized execution behavior.
Plan should be used before large changes.
Agent execution should be used for implementation, testing, and iteration.
```

The best professional workflow is:

```text
Write short project instructions.
Use path-specific rules.
Use prompt files for repeated tasks.
Use plan before implementation.
Use agent execution for controlled changes.
Run build and tests.
Keep prompts focused.
Keep context clean.
```
