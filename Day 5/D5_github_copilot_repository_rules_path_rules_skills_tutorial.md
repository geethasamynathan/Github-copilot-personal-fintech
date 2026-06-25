# GitHub Copilot Current-Version Tutorial: Repository Rules, Path Rules, Standards, Skills, Tools, and Instruction Priority


# 1. What are these topics in GitHub Copilot?

These topics are part of **Copilot customization**.

Instead of repeatedly telling Copilot your project rules in every prompt, you store reusable rules inside Markdown instruction files.


> Copilot customization means we are not only asking Copilot to generate code. We are teaching Copilot how our project works, how our team writes code, and what rules it must follow.

---

# 2. Real-World Use Case for This Tutorial

We will use a simple **React Student Course Registration App** in VS Code.

The app will have:

```text
student-registration-copilot-demo
│
├── .github
│   ├── copilot-instructions.md
│   ├── instructions
│   │   ├── react-components.instructions.md
│   │   ├── services.instructions.md
│   │   └── tests.instructions.md
│   └── agents
│       └── code-reviewer.agent.md
│
├── src
│   ├── components
│   │   ├── RegistrationForm.jsx
│   │   └── RegistrationTable.jsx
│   ├── services
│   │   └── registrationService.js
│   ├── tests
│   │   └── registrationService.test.js
│   ├── App.jsx
│   └── App.css
│
└── package.json
```

Business requirement:

```text
1. Add student name, email, and course.
2. Validate input.
3. Store registration in localStorage.
4. Show registered students in a table.
5. Delete a registration.
6. Follow team coding rules.
7. Use different rules for components, services, and tests.
```

---

# 3. Prerequisites in VS Code

Use the current VS Code Copilot workflow:

```text
1. Install Visual Studio Code.
2. Install GitHub Copilot extension.
3. Install GitHub Copilot Chat extension if required by your VS Code setup.
4. Sign in with GitHub account.
5. Open the project root folder in VS Code.
6. Open Copilot Chat using Ctrl + Alt + I.
7. In the model selector, choose Auto mode.
```

Trainer note:

> In this tutorial, we use Auto mode. Auto lets Copilot decide the best available model for the task. We still control quality using instructions, path rules, and focused prompts.

---

# 4. Create the React App from Scratch

Open VS Code terminal:

```bash
npm create vite@latest student-registration-copilot-demo
```

Choose:

```text
Framework: React
Variant: JavaScript
```

Go inside the folder:

```bash
cd student-registration-copilot-demo
```

Install dependencies:

```bash
npm install
```

Run the app:

```bash
npm run dev
```

Open the folder in VS Code:

```bash
code .
```

---

# 5. Repository-Wide Rules

## 5.1 What are Repository-Wide Rules?

Repository-wide rules are instructions that apply to the whole project.

The main repository-wide instruction file is:

```text
.github/copilot-instructions.md
```

Use repository-wide rules for project-level standards such as:

```text
Technology stack
Architecture pattern
Naming rules
Validation rules
Testing expectations
Folder structure
Error handling style
Security rules
```

Trainer explanation:

> Repository-wide rules are like the project constitution. Every Copilot answer inside this repository should respect these rules.

---

## 5.2 How to Create Repository-Wide Rules in VS Code Auto Mode

### Option A: Generate using `/init`

Open Copilot Chat and type:

```text
/init
```

Copilot can generate a `.github/copilot-instructions.md` file based on your project.

After Copilot creates the file, review and edit it.

Trainer explanation:

> `/init` is useful, but do not accept the generated file blindly. Always review the rules and customize them for your project.

---

### Option B: Create Manually

Create folder:

```text
.github
```

Create file:

```text
.github/copilot-instructions.md
```

Add this content:

```md
# Copilot Instructions for Student Registration App

## Project Overview
This is a React JavaScript application for student course registration.

## Technology Stack
- Use React with JavaScript.
- Use Vite project structure.
- Use plain CSS.
- Do not use TypeScript.
- Do not use Redux.
- Do not use external UI libraries unless explicitly requested.

## Architecture Rules
- Keep reusable UI code inside `src/components`.
- Keep business and storage logic inside `src/services`.
- Keep tests inside `src/tests`.
- Keep components small and focused.
- Do not place localStorage logic directly inside components unless there is a strong reason.

## Coding Standards
- Use functional React components.
- Use React hooks such as `useState` and `useEffect`.
- Use `const` and `let`; do not use `var`.
- Use meaningful function names.
- Use early returns for validation.
- Keep code beginner-friendly and readable.

## Naming Conventions
- React component files must use PascalCase.
  Example: `RegistrationForm.jsx`
- Service files must use camelCase.
  Example: `registrationService.js`
- Function names must use camelCase.
  Example: `saveRegistration`
- CSS class names must use kebab-case.
  Example: `registration-card`

## Validation Rules
- Student name is required.
- Email is required.
- Course is required.
- Show user-friendly error messages.

## Output Rules
- When generating code, mention which file should be changed.
- Do not modify unrelated files.
- Explain important changes briefly.
```

---

## 5.3 Test Repository-Wide Rules

Ask Copilot Chat in Auto mode:

```text
@workspace

Create a React component for adding student registration.
Follow the repository instructions.
Mention which file to create.
```

Expected behavior:

```text
Copilot should suggest a component inside src/components.
It should use React functional component.
It should use PascalCase file naming.
It should avoid external libraries.
It should keep storage logic out of the component.
```

---

# 6. Path-Specific Rules

## 6.1 What are Path-Specific Rules?

Path-specific rules apply only to selected folders or file patterns.

For example:

```text
Rules for src/components only
Rules for src/services only
Rules for src/tests only
```

Path-specific instruction files use this pattern:

```text
.github/instructions/**/*.instructions.md
```

Trainer explanation:

> Repository-wide rules are common rules for the whole project. Path-specific rules are special rules for a folder or file type.

---

## 6.2 Create Path-Specific Rules Folder

Create folder:

```text
.github/instructions
```

---

## 6.3 Path-Specific Rules for React Components

Create file:

```text
.github/instructions/react-components.instructions.md
```

Add:

```md
---
applyTo: "src/components/**/*.jsx"
---

# React Component Instructions

These instructions apply only to React component files inside `src/components`.

## Component Rules
- Use functional components only.
- Use PascalCase for component names.
- Keep one component per file.
- Accept data and callbacks through props.
- Do not directly use localStorage in components.
- Do not call backend APIs directly from components.
- Keep component logic simple and readable.

## JSX Rules
- Use semantic HTML where possible.
- Use clear labels for form fields.
- Use controlled inputs for forms.
- Use conditional rendering for empty states.

## CSS Rules
- Use class names from `App.css`.
- Use kebab-case for CSS class names.
```

---

## 6.4 Path-Specific Rules for Services

Create file:

```text
.github/instructions/services.instructions.md
```

Add:

```md
---
applyTo: "src/services/**/*.js"
---

# Service Layer Instructions

These instructions apply only to files inside `src/services`.

## Service Rules
- Put business logic and browser storage logic here.
- Keep React-specific code out of service files.
- Do not import React in service files.
- Use named exports.
- Return plain JavaScript objects or arrays.
- Validate data before saving when appropriate.

## localStorage Rules
- Use a constant for the storage key.
- Return an empty array when no data exists.
- Handle invalid or missing data safely.
```

---

## 6.5 Path-Specific Rules for Tests

Create file:

```text
.github/instructions/tests.instructions.md
```

Add:

```md
---
applyTo: "src/tests/**/*.test.js"
---

# Test Instructions

These instructions apply only to test files.

## Testing Rules
- Use clear test names.
- Follow Arrange, Act, Assert pattern.
- Test success and failure scenarios.
- Mock browser APIs when needed.
- Do not test implementation details unnecessarily.
- Keep tests readable for beginners.
```

---

## 6.6 Test Path-Specific Rules

Ask Copilot:

```text
@workspace

Create a service file for saving and reading student registrations from localStorage.
Follow the path-specific rules.
```

Expected result:

```text
Copilot should create or suggest code for src/services/registrationService.js.
It should not import React.
It should use named exports.
It should use a storage key constant.
```

Ask another prompt:

```text
@workspace

Create a RegistrationTable component for displaying registrations.
Follow the path-specific component rules.
```

Expected result:

```text
Copilot should create src/components/RegistrationTable.jsx.
It should accept registrations as props.
It should not directly access localStorage.
```

---

# 7. Coding Standards & Naming Conventions

## 7.1 What are Coding Standards?

Coding standards are rules that keep the codebase consistent.

Examples:

```text
Use functional components
Use PascalCase for components
Use camelCase for functions
Use kebab-case for CSS classes
Use service layer for business logic
Use named exports in services
Avoid duplicate code
Write readable code
```

Trainer explanation:

> Copilot can generate code in many ways. Coding standards tell Copilot which style our team expects.

---

## 7.2 Where to Define Coding Standards?

Define common standards in:

```text
.github/copilot-instructions.md
```

Define folder-specific standards in:

```text
.github/instructions/*.instructions.md
```

For our project:

```text
Repository-wide:
- Use React JavaScript.
- Use functional components.
- Use meaningful names.

Component path:
- Use props.
- Do not use localStorage directly.

Service path:
- Use named exports.
- Keep React out.

Test path:
- Use Arrange, Act, Assert.
```

---

## 7.3 Example Code Copilot Should Generate

### File: `src/services/registrationService.js`

```javascript
const STORAGE_KEY = "studentRegistrations";

export function getRegistrations() {
    const savedData = localStorage.getItem(STORAGE_KEY);

    if (!savedData) {
        return [];
    }

    try {
        return JSON.parse(savedData);
    } catch {
        return [];
    }
}

export function saveRegistrations(registrations) {
    localStorage.setItem(STORAGE_KEY, JSON.stringify(registrations));
}

export function addRegistration(registration) {
    const registrations = getRegistrations();
    const updatedRegistrations = [...registrations, registration];

    saveRegistrations(updatedRegistrations);

    return updatedRegistrations;
}

export function deleteRegistration(registrationId) {
    const registrations = getRegistrations();

    const updatedRegistrations = registrations.filter(
        (registration) => registration.id !== registrationId
    );

    saveRegistrations(updatedRegistrations);

    return updatedRegistrations;
}
```

Why this follows standards:

```text
File is inside src/services.
Uses named exports.
Uses localStorage inside service, not component.
Uses camelCase functions.
Uses constant for storage key.
Returns plain JavaScript arrays.
```

---

### File: `src/components/RegistrationForm.jsx`

```jsx
import { useState } from "react";

function RegistrationForm({ onAddRegistration }) {
    const [studentName, setStudentName] = useState("");
    const [email, setEmail] = useState("");
    const [course, setCourse] = useState("");
    const [errorMessage, setErrorMessage] = useState("");

    function handleSubmit(event) {
        event.preventDefault();

        if (!studentName.trim()) {
            setErrorMessage("Student name is required.");
            return;
        }

        if (!email.trim()) {
            setErrorMessage("Email is required.");
            return;
        }

        if (!course) {
            setErrorMessage("Course is required.");
            return;
        }

        const registration = {
            id: Date.now(),
            studentName,
            email,
            course
        };

        onAddRegistration(registration);

        setStudentName("");
        setEmail("");
        setCourse("");
        setErrorMessage("");
    }

    return (
        <section className="registration-card">
            <h2>Register Student</h2>

            <form onSubmit={handleSubmit}>
                <label htmlFor="studentName">Student Name</label>
                <input
                    id="studentName"
                    type="text"
                    value={studentName}
                    onChange={(event) => setStudentName(event.target.value)}
                />

                <label htmlFor="email">Email</label>
                <input
                    id="email"
                    type="email"
                    value={email}
                    onChange={(event) => setEmail(event.target.value)}
                />

                <label htmlFor="course">Course</label>
                <select
                    id="course"
                    value={course}
                    onChange={(event) => setCourse(event.target.value)}
                >
                    <option value="">Select Course</option>
                    <option value="React">React</option>
                    <option value="ASP.NET Core">ASP.NET Core</option>
                    <option value="GitHub Copilot">GitHub Copilot</option>
                </select>

                {errorMessage && (
                    <p className="error-message">{errorMessage}</p>
                )}

                <button type="submit">Register</button>
            </form>
        </section>
    );
}

export default RegistrationForm;
```

Why this follows standards:

```text
Component file uses PascalCase.
Component accepts callback through props.
Uses controlled inputs.
Uses semantic labels.
Does not use localStorage directly.
Uses kebab-case CSS class names.
```

---

# 8. Skills & Custom Tools

## 8.1 What are Skills?

Skills are reusable, task-specific capabilities for agents. They are useful when instructions are too detailed or only needed for a specific workflow.

Trainer explanation:

> Use custom instructions for common rules. Use skills for specialized tasks.

Example:

```text
Common rule:
Use PascalCase for components.
Put this in copilot-instructions.md.

Special task:
Generate a full accessibility review checklist.
Put this in a skill or custom agent workflow.
```

---

## 8.2 What are Custom Tools?

Custom tools are capabilities that agents can use during a task, such as:

```text
Reading files
Editing files
Running commands
Using MCP servers
Invoking extension-provided tools
Using configured agent tools
```

Trainer explanation:

> Skills are like reusable knowledge. Tools are actions Copilot can perform.

---

## 8.3 Practical Current-Version Approach in VS Code

For most training batches, teach this order:

```text
1. Repository-wide instructions
2. Path-specific instructions
3. Prompt files for repeatable tasks
4. Custom agents for specialized roles
5. Tools/MCP only for advanced batches
```

Do not start with MCP or complex tools for freshers. Use them only for advanced cohorts.

---

## 8.4 Create a Custom Agent for Code Review

Custom agents are stored as `.agent.md` Markdown files.

Create folder:

```text
.github/agents
```

Create file:

```text
.github/agents/code-reviewer.agent.md
```

Add:

```md
---
name: Code Reviewer
description: Reviews React JavaScript code for quality, naming, readability, validation, and architecture.
---

# Code Reviewer Agent

You are a strict but helpful code reviewer for this React JavaScript project.

## Review Focus
- Check whether repository-wide instructions are followed.
- Check whether path-specific instructions are followed.
- Verify naming conventions.
- Verify components do not directly access localStorage.
- Verify service files do not import React.
- Verify validation logic is clear.
- Verify code is beginner-friendly and readable.

## Output Format
For each issue, provide:
1. File name
2. Problem
3. Why it matters
4. Suggested fix

## Rules
- Do not modify files unless explicitly asked.
- Review only the files requested.
- Prefer practical suggestions.
```

Use it in VS Code:

```text
1. Open Copilot Chat.
2. Open the agents dropdown.
3. Select Code Reviewer.
4. Ask: Review #file:src/components/RegistrationForm.jsx.
```

Trainer explanation:

> A custom agent is useful when the same role is repeated many times, such as reviewer, planner, tester, or security analyst.

---

# 9. Instruction Priority System

## 9.1 What is Instruction Priority?

Instruction priority means when multiple instructions apply, Copilot gives higher priority to some instruction sources.

Priority order:

```text
1. Personal instructions
2. Repository instructions
3. Organization instructions
```

---

## 9.2 How to Explain This to Cohorts

Simple example:

```text
Organization instruction:
Use secure coding practices.

Repository instruction:
Use React functional components.

Personal instruction:
Explain code in simple beginner-friendly language.
```

When the user asks Copilot to create a component, Copilot may combine all:

```text
Use secure coding.
Use React functional component.
Explain in beginner-friendly way.
```

If there is conflict:

```text
Personal instruction has highest priority.
Repository instruction comes next.
Organization instruction comes last.
```

Trainer explanation:

> Instructions are layered. Copilot receives all relevant instructions, but if they conflict, higher-priority instructions win.

---

## 9.3 Path-Specific Priority Explanation

Path-specific instructions are more targeted repository instructions.

For teaching, explain it like this:

```text
Repository-wide rule:
Use React functional components.

Path-specific rule for services:
Do not import React in src/services.

When editing src/services/registrationService.js:
The service rule becomes relevant because the file path matches.
```

Trainer explanation:

> Path-specific instructions help Copilot apply the right rule to the right folder.

---

# 10. Implement the Full Project in VS Code with Auto Mode

## Step 1: Create folders

Create:

```text
.github
.github/instructions
.github/agents
src/components
src/services
src/tests
```

---

## Step 2: Add repository-wide rules

Create:

```text
.github/copilot-instructions.md
```

Use the repository-wide content from section 5.

---

## Step 3: Add path-specific rules

Create:

```text
.github/instructions/react-components.instructions.md
.github/instructions/services.instructions.md
.github/instructions/tests.instructions.md
```

Use the contents from section 6.

---

## Step 4: Add custom agent

Create:

```text
.github/agents/code-reviewer.agent.md
```

Use the content from section 8.

---

## Step 5: Set Copilot Chat Model to Auto

In VS Code:

```text
1. Open Copilot Chat.
2. Find the model selector near the chat input.
3. Select Auto.
```

Trainer explanation:

> Auto mode chooses an appropriate available model. Our instructions control style, architecture, and output expectations.

---

## Step 6: Ask Copilot to create the service

Prompt:

```text
@workspace

Create #file:src/services/registrationService.js for student registration storage.

Requirements:
- Save registrations to localStorage.
- Read registrations from localStorage.
- Add a registration.
- Delete a registration.
- Follow repository-wide and path-specific service rules.
```

---

## Step 7: Ask Copilot to create the form component

Prompt:

```text
@workspace

Create #file:src/components/RegistrationForm.jsx.

Requirements:
- Student name field
- Email field
- Course dropdown
- Validation messages
- Submit button
- Use controlled inputs
- Do not use localStorage directly
- Follow component path-specific rules
```

---

## Step 8: Ask Copilot to create the table component

Prompt:

```text
@workspace

Create #file:src/components/RegistrationTable.jsx.

Requirements:
- Accept registrations through props.
- Display student name, email, and course.
- Show delete button.
- Show empty state when no records exist.
- Follow React component path-specific rules.
```

---

## Step 9: Ask Copilot to update App.jsx

Prompt:

```text
@workspace

Update #file:src/App.jsx to use:
#file:src/components/RegistrationForm.jsx
#file:src/components/RegistrationTable.jsx
#file:src/services/registrationService.js

Requirements:
- Load registrations when app starts.
- Add registration using service function.
- Delete registration using service function.
- Keep state in App.jsx.
- Follow repository instructions.
```

---

## Step 10: Ask Copilot to create tests

Prompt:

```text
@workspace /tests

Create tests for #file:src/services/registrationService.js.

Use:
#file:.github/instructions/tests.instructions.md

Cover:
1. getRegistrations returns empty array when storage is empty.
2. saveRegistrations stores data.
3. addRegistration adds one item.
4. deleteRegistration removes selected item.
```

---

## Step 11: Ask custom reviewer agent to review

Select the **Code Reviewer** custom agent in the chat dropdown.

Prompt:

```text
Review these files:
#file:src/components/RegistrationForm.jsx
#file:src/components/RegistrationTable.jsx
#file:src/services/registrationService.js

Check whether repository-wide rules and path-specific rules are followed.
```

---

# 11. Trainer Demo: What Happens if Rules are Missing?

## Without instructions

Prompt:

```text
Create a student registration form in React.
```

Possible output:

```text
May mix storage logic inside component.
May use different naming styles.
May create everything in App.jsx.
May use external libraries.
May skip validation.
```

## With repository and path-specific instructions

Prompt:

```text
@workspace Create a student registration form in React.
```

Expected output:

```text
Component goes to src/components.
Storage logic goes to src/services.
Uses functional component.
Uses controlled inputs.
Uses validation.
Follows naming conventions.
```

Trainer explanation:

> Instructions do not guarantee perfect output, but they strongly improve consistency.

---

# 12. Common Mistakes to Warn Cohorts About

## Mistake 1: Writing vague rules

Bad:

```md
Write good code.
```

Better:

```md
Use functional React components.
Use PascalCase for component file names.
Keep localStorage logic inside src/services.
```

---

## Mistake 2: Putting everything in repository-wide instructions

Bad:

```text
All component rules, test rules, service rules, CSS rules, API rules in one huge file.
```

Better:

```text
Repository-wide file for common rules.
Path-specific files for folder-specific rules.
```

---

## Mistake 3: Assuming inline autocomplete always follows instructions

Trainer explanation:

> Custom instructions are mainly for Copilot Chat and related AI tasks. Do not assume every ghost text inline suggestion will obey every instruction.

---

## Mistake 4: Not reviewing generated rules

When you use `/init`, VS Code generates instructions based on the project. You still need to review and customize the file.

---

# 13. Final Comparison Table

| Topic | File / Feature | Purpose |
|---|---|---|
| Repository-Wide Rules | `.github/copilot-instructions.md` | Common project rules |
| Path-Specific Rules | `.github/instructions/**/*.instructions.md` | Folder/file-specific rules |
| Coding Standards | Instruction files | Naming, style, architecture |
| Skills | Agent skills | Detailed task-specific knowledge |
| Custom Tools | Configure Tools / MCP / plugins | Give agents controlled capabilities |
| Custom Agents | `.github/agents/*.agent.md` | Specialized personas and workflows |
| Instruction Priority | Personal > Repository > Organization | Conflict resolution |

---

# 14. Final Classroom Summary

Explain to cohorts:

> Repository-wide rules teach Copilot the general project standards. Path-specific rules teach Copilot different behavior for components, services, and tests. Coding standards and naming conventions improve consistency. Skills and custom tools are used for specialized workflows. Instruction priority explains which rules win when multiple rules apply.

Final trainer line:

> In current GitHub Copilot usage, effective developers do not only write prompts. They create a project guidance system using repository instructions, path-specific rules, custom agents, and controlled tools. Then they use Copilot Auto mode to generate better, more consistent code.
