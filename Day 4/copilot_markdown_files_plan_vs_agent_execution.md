# Role of Markdown Files with GitHub Copilot Plan vs Agent Execution

## Trainer Notes for Experienced Cohorts

This document explains the role of Markdown files with respect to **GitHub Copilot Plan** and **Agent execution**.

It includes:

```text
1. What Markdown files mean in Copilot workflow
2. Difference between Copilot Plan and Agent execution
3. Role of instruction files, requirement files, plan files, and test checklist files
4. Real-time use case from scratch
5. Step-by-step implementation using basic HTML, CSS, and JavaScript
6. Whether to use /create-instruction
7. Complete project code
8. Trainer explanation and summary
```

---

# 1. What are Markdown files in Copilot context?

In GitHub Copilot / VS Code, Markdown files are not only documentation files.

They can also act as:

```text
Instruction files
Prompt files
Planning files
Execution guide files
Requirement files
Test checklist files
Project rules files
```

Common examples:

```text
.github/copilot-instructions.md
docs/feature-plan.md
docs/implementation-steps.md
docs/requirements.md
docs/test-checklist.md
.prompts/create-feature.prompt.md
README.md
```

Trainer explanation:

> Markdown files act as written context for Copilot. They tell Copilot what the project is, what rules to follow, what needs to be built, how to implement it, and how to test it.

---

# 2. Copilot Plan vs Agent Execution

## 2.1 Copilot Plan

**Plan** means Copilot first thinks through the task before changing files.

You use Plan when the work needs:

```text
Design
Analysis
Multiple steps
File-level planning
Impact analysis
Implementation order
Testing checklist
```

Example prompt:

```text
@workspace /plan

Create a small student registration website using HTML, CSS, and JavaScript.
Do not create code yet.
Give only the implementation plan.
```

Copilot may produce a plan like:

```text
1. Create index.html
2. Create styles.css
3. Create script.js
4. Add form fields
5. Add validation
6. Store student records in localStorage
7. Display records in table
8. Test browser behavior
```

Trainer explanation:

> Plan mode is like asking a senior developer to prepare the implementation approach before writing code.

---

## 2.2 Agent Execution

**Agent execution** means Copilot can carry out the task by:

```text
Creating files
Editing files
Updating existing code
Following instruction files
Following plan files
Running commands depending on approval/settings
Applying implementation steps
```

Example prompt:

```text
@workspace

Create the files and implement the student registration website based on docs/student-registration-plan.md
```

Trainer explanation:

> Agent execution is like asking Copilot to act as a developer and implement the agreed plan.

---

# 3. Where Markdown Files Fit

Markdown files act like **memory and rules** for Copilot.

| Markdown File | Purpose | Used During Plan? | Used During Agent Execution? |
|---|---|---|---|
| `.github/copilot-instructions.md` | Permanent project rules | Yes | Yes |
| `docs/project-requirements.md` | Business requirements | Yes | Yes |
| `docs/feature-plan.md` | Step-by-step implementation plan | Yes | Yes |
| `docs/test-cases.md` | Test checklist | Yes | Yes |
| `*.prompt.md` | Reusable prompts | Yes | Yes |
| `README.md` | Project overview | Yes | Yes |

Trainer explanation:

> Prompt is temporary. Markdown files are reusable context. They stay in the repository and guide Copilot repeatedly.

---

# 4. Do You Need `/create-instruction`?

Yes, for teaching this topic, you can show it.

But explain this clearly:

```text
/create-instruction is useful when you want Copilot to generate a project instruction file.
```

You can also manually create the file yourself.

Recommended for your basic HTML, CSS, JavaScript project:

```text
.github/copilot-instructions.md
```

Use it when you want Copilot to always follow project rules.

Example rules:

```md
# Copilot Instructions

This project uses plain HTML, CSS, and JavaScript.

Rules:
- Do not use React, Angular, Vue, Bootstrap, or external libraries.
- Use semantic HTML.
- Keep CSS in styles.css.
- Keep JavaScript in script.js.
- Use localStorage for storing records.
- Use clear function names.
- Use beginner-friendly JavaScript.
- Add comments for important logic.
- Validate form input before saving.
```

So the answer is:

```text
Yes, you can use /create-instruction.
But for teaching, first manually create .github/copilot-instructions.md so students understand the purpose.
Then show /create-instruction as an automation shortcut.
```

Trainer explanation:

> If students directly use `/create-instruction`, they may think the command is magic. First show the manual file, then show how Copilot can generate it.

---

# 5. Real-Time Use Case from Scratch

## Use Case: Student Course Registration Website

We will create a basic frontend project using:

```text
HTML
CSS
JavaScript
Markdown instruction file
Markdown requirements file
Markdown implementation plan
Markdown test checklist
Copilot Plan
Copilot Agent execution
```

The application will allow users to:

```text
1. Enter student name
2. Enter email
3. Select course
4. Register student
5. Show registered students in a table
6. Validate required fields
7. Store data in browser localStorage
8. Delete a registration
```

This is simple enough for freshers but still useful for experienced cohorts to understand Copilot workflow.

---

# 6. Folder Structure

Create a folder:

```text
StudentRegistrationCopilotDemo
```

Inside it:

```text
StudentRegistrationCopilotDemo
│
├── .github
│   └── copilot-instructions.md
│
├── docs
│   ├── requirements.md
│   ├── implementation-plan.md
│   └── test-checklist.md
│
├── index.html
├── styles.css
├── script.js
└── README.md
```

---

# 7. Step-by-Step Implementation

## Step 1: Open Project in VS Code

Create folder:

```text
StudentRegistrationCopilotDemo
```

Open it in VS Code:

```text
File → Open Folder → StudentRegistrationCopilotDemo
```

Trainer explanation:

> Always open the root folder. Copilot uses the workspace folder as project context.

---

## Step 2: Create Copilot Instruction File

Create folder:

```text
.github
```

Create file:

```text
.github/copilot-instructions.md
```

Add:

```md
# Copilot Instructions for Student Registration Demo

## Project Type
This is a beginner-friendly frontend project using plain HTML, CSS, and JavaScript.

## Technology Rules
- Use only HTML, CSS, and JavaScript.
- Do not use React, Angular, Vue, Bootstrap, Tailwind, jQuery, or external libraries.
- Keep all HTML in `index.html`.
- Keep all CSS in `styles.css`.
- Keep all JavaScript in `script.js`.

## Coding Rules
- Use semantic HTML elements.
- Use clear and beginner-friendly JavaScript.
- Use meaningful function names.
- Add comments for important logic.
- Avoid complex patterns.
- Use `const` and `let`.
- Do not use `var`.

## Functional Rules
- Validate student name, email, and course before saving.
- Store registrations in browser `localStorage`.
- Display registrations in a table.
- Allow deleting a registration.
- Show user-friendly success and error messages.

## Output Rules
- Give complete code when asked.
- Explain changes step by step.
- Mention which file should be edited.
```

Trainer explanation:

> This file gives permanent rules to Copilot. It helps Plan and Agent execution follow the same project standards.

---

## Step 3: Create Requirements Markdown File

Create folder:

```text
docs
```

Create:

```text
docs/requirements.md
```

Add:

```md
# Student Course Registration Requirements

## Goal
Create a simple student course registration website using plain HTML, CSS, and JavaScript.

## User Story
As an admin, I want to register students for a course so that I can track course registrations.

## Fields
- Student Name
- Email
- Course

## Courses
- HTML Basics
- CSS Fundamentals
- JavaScript Essentials
- GitHub Copilot for Developers

## Features
1. User can enter student name.
2. User can enter email.
3. User can select a course.
4. User can click Register.
5. App validates all fields.
6. App stores registration in localStorage.
7. App displays saved registrations in a table.
8. User can delete a registration.
9. App shows success and error messages.

## Constraints
- Use only HTML, CSS, and JavaScript.
- No frameworks.
- No external libraries.
```

Trainer explanation:

> Requirements Markdown is useful during Plan because Copilot can convert business needs into technical steps.

---

## Step 4: Ask Copilot to Create a Plan

In Copilot Chat, ask:

```text
@workspace /plan

Read #file:docs/requirements.md and #file:.github/copilot-instructions.md.

Create a step-by-step implementation plan for this basic HTML, CSS, and JavaScript project.

Do not create code yet.
Only produce the implementation plan with file names and responsibilities.
```

Expected Copilot plan:

```text
1. Create index.html with form and table.
2. Link styles.css and script.js.
3. Create CSS layout and form/table styling.
4. In script.js, create array and localStorage helper functions.
5. Add form submit event.
6. Validate name, email, and course.
7. Save registration to localStorage.
8. Render registrations in table.
9. Add delete button.
10. Add test checklist.
```

Trainer explanation:

> Here Copilot is not executing. It is planning. Markdown files guide the planning quality.

---

## Step 5: Save the Plan as Markdown

Create:

```text
docs/implementation-plan.md
```

Paste the final plan:

```md
# Student Registration Implementation Plan

## Files to Create

1. `index.html`
   - Create form for student name, email, and course.
   - Create table to display registered students.
   - Link `styles.css` and `script.js`.

2. `styles.css`
   - Style page layout.
   - Style form, buttons, messages, and table.
   - Make layout responsive.

3. `script.js`
   - Read form data.
   - Validate inputs.
   - Save registrations in localStorage.
   - Display registrations in table.
   - Delete registrations.

4. `docs/test-checklist.md`
   - Manual test cases for validation, save, display, delete, and reload behavior.

## Implementation Rules
- Use plain JavaScript.
- Do not use frameworks.
- Use localStorage.
- Use beginner-friendly code.
```

Trainer explanation:

> Saving the plan in Markdown is important. It becomes a stable reference for Agent execution.

---

## Step 6: Ask Agent to Implement Based on Plan

Use this prompt:

```text
@workspace

Implement the project based on:
#file:docs/implementation-plan.md
#file:docs/requirements.md
#file:.github/copilot-instructions.md

Create or update:
- index.html
- styles.css
- script.js
- docs/test-checklist.md

Follow all project rules.
Use only plain HTML, CSS, and JavaScript.
```

Trainer explanation:

> Now Copilot moves from planning to execution. It uses the Markdown files as the source of truth.

---

# 8. Final Code for the Project

## 8.1 index.html

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Student Course Registration</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <main class="container">
        <section class="card">
            <h1>Student Course Registration</h1>
            <p class="subtitle">Register students for available training courses.</p>

            <form id="registrationForm">
                <div class="form-group">
                    <label for="studentName">Student Name</label>
                    <input type="text" id="studentName" placeholder="Enter student name">
                </div>

                <div class="form-group">
                    <label for="studentEmail">Email</label>
                    <input type="email" id="studentEmail" placeholder="Enter email address">
                </div>

                <div class="form-group">
                    <label for="course">Course</label>
                    <select id="course">
                        <option value="">-- Select Course --</option>
                        <option value="HTML Basics">HTML Basics</option>
                        <option value="CSS Fundamentals">CSS Fundamentals</option>
                        <option value="JavaScript Essentials">JavaScript Essentials</option>
                        <option value="GitHub Copilot for Developers">GitHub Copilot for Developers</option>
                    </select>
                </div>

                <button type="submit">Register Student</button>
            </form>

            <p id="message" class="message"></p>
        </section>

        <section class="card">
            <h2>Registered Students</h2>

            <table>
                <thead>
                    <tr>
                        <th>Student Name</th>
                        <th>Email</th>
                        <th>Course</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody id="registrationTableBody">
                </tbody>
            </table>
        </section>
    </main>

    <script src="script.js"></script>
</body>
</html>
```

---

## 8.2 styles.css

```css
* {
    box-sizing: border-box;
}

body {
    margin: 0;
    font-family: Arial, sans-serif;
    background-color: #f4f6f8;
    color: #222;
}

.container {
    width: 90%;
    max-width: 1000px;
    margin: 30px auto;
}

.card {
    background-color: #ffffff;
    padding: 24px;
    margin-bottom: 24px;
    border-radius: 10px;
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.08);
}

h1,
h2 {
    margin-top: 0;
}

.subtitle {
    color: #555;
}

.form-group {
    margin-bottom: 16px;
}

label {
    display: block;
    font-weight: bold;
    margin-bottom: 6px;
}

input,
select {
    width: 100%;
    padding: 10px;
    border: 1px solid #bbb;
    border-radius: 6px;
    font-size: 15px;
}

button {
    padding: 10px 16px;
    border: none;
    border-radius: 6px;
    background-color: #2563eb;
    color: white;
    cursor: pointer;
    font-size: 15px;
}

button:hover {
    background-color: #1d4ed8;
}

.delete-btn {
    background-color: #dc2626;
}

.delete-btn:hover {
    background-color: #b91c1c;
}

.message {
    margin-top: 14px;
    font-weight: bold;
}

.message.success {
    color: #15803d;
}

.message.error {
    color: #dc2626;
}

table {
    width: 100%;
    border-collapse: collapse;
    margin-top: 12px;
}

th,
td {
    border: 1px solid #ddd;
    padding: 10px;
    text-align: left;
}

th {
    background-color: #f1f5f9;
}

@media (max-width: 700px) {
    table,
    thead,
    tbody,
    th,
    td,
    tr {
        display: block;
    }

    thead {
        display: none;
    }

    td {
        border: none;
        border-bottom: 1px solid #ddd;
    }

    td::before {
        font-weight: bold;
    }
}
```

---

## 8.3 script.js

```javascript
const form = document.getElementById("registrationForm");
const studentNameInput = document.getElementById("studentName");
const studentEmailInput = document.getElementById("studentEmail");
const courseSelect = document.getElementById("course");
const message = document.getElementById("message");
const tableBody = document.getElementById("registrationTableBody");

const STORAGE_KEY = "studentRegistrations";

function getRegistrations() {
    const savedData = localStorage.getItem(STORAGE_KEY);

    if (!savedData) {
        return [];
    }

    return JSON.parse(savedData);
}

function saveRegistrations(registrations) {
    localStorage.setItem(STORAGE_KEY, JSON.stringify(registrations));
}

function showMessage(text, type) {
    message.textContent = text;
    message.className = `message ${type}`;
}

function clearForm() {
    studentNameInput.value = "";
    studentEmailInput.value = "";
    courseSelect.value = "";
}

function validateForm(studentName, studentEmail, course) {
    if (!studentName) {
        showMessage("Student name is required.", "error");
        return false;
    }

    if (!studentEmail) {
        showMessage("Email is required.", "error");
        return false;
    }

    if (!course) {
        showMessage("Please select a course.", "error");
        return false;
    }

    return true;
}

function renderRegistrations() {
    const registrations = getRegistrations();

    tableBody.innerHTML = "";

    if (registrations.length === 0) {
        const row = document.createElement("tr");
        row.innerHTML = `<td colspan="4">No registrations found.</td>`;
        tableBody.appendChild(row);
        return;
    }

    registrations.forEach((registration, index) => {
        const row = document.createElement("tr");

        row.innerHTML = `
            <td>${registration.studentName}</td>
            <td>${registration.studentEmail}</td>
            <td>${registration.course}</td>
            <td>
                <button class="delete-btn" onclick="deleteRegistration(${index})">
                    Delete
                </button>
            </td>
        `;

        tableBody.appendChild(row);
    });
}

function deleteRegistration(index) {
    const registrations = getRegistrations();

    registrations.splice(index, 1);

    saveRegistrations(registrations);
    renderRegistrations();

    showMessage("Registration deleted successfully.", "success");
}

form.addEventListener("submit", function (event) {
    event.preventDefault();

    const studentName = studentNameInput.value.trim();
    const studentEmail = studentEmailInput.value.trim();
    const course = courseSelect.value;

    if (!validateForm(studentName, studentEmail, course)) {
        return;
    }

    const registrations = getRegistrations();

    const newRegistration = {
        studentName,
        studentEmail,
        course
    };

    registrations.push(newRegistration);

    saveRegistrations(registrations);
    renderRegistrations();
    clearForm();

    showMessage("Student registered successfully.", "success");
});

renderRegistrations();
```

---

# 9. Create Test Checklist Markdown

Create:

```text
docs/test-checklist.md
```

Add:

```md
# Student Registration Test Checklist

## Page Load
- [ ] Page opens without error.
- [ ] Registration form is visible.
- [ ] Registered Students table is visible.

## Validation
- [ ] Empty student name shows error.
- [ ] Empty email shows error.
- [ ] Empty course shows error.

## Registration
- [ ] Valid student registration is saved.
- [ ] Success message is displayed.
- [ ] Form clears after successful registration.
- [ ] Student appears in the table.

## localStorage
- [ ] Refreshing the page keeps saved registrations.
- [ ] Multiple registrations are stored correctly.

## Delete
- [ ] Delete button removes selected registration.
- [ ] Success message appears after deletion.
- [ ] Deleted registration does not appear after refresh.
```

---

# 10. Teaching Plan vs Agent Execution

## 10.1 Plan Prompt

```text
@workspace /plan

Read #file:docs/requirements.md and #file:.github/copilot-instructions.md.

Create a step-by-step implementation plan.
Do not write code yet.
```

Use this when:

```text
You want Copilot to think and design first.
```

---

## 10.2 Agent Execution Prompt

```text
@workspace

Implement the project based on:
#file:docs/implementation-plan.md
#file:docs/requirements.md
#file:.github/copilot-instructions.md

Create index.html, styles.css, script.js, and docs/test-checklist.md.
```

Use this when:

```text
You want Copilot to create or modify files.
```

---

# 11. Should You Use `/create-instruction`?

Yes, you can use it in the second round.

## Manual First

First create this manually:

```text
.github/copilot-instructions.md
```

This helps students understand what instruction files do.

## Then Show Automation

After that, show:

```text
/create-instruction Create project instructions for a plain HTML, CSS, and JavaScript project.
```

or:

```text
@workspace /create-instruction

Create project instructions for this Student Registration project.
Rules:
- plain HTML, CSS, and JavaScript only
- no external frameworks
- semantic HTML
- beginner-friendly JavaScript
- use localStorage
- maintain file separation
```

Trainer explanation:

> `/create-instruction` is useful, but students should first understand the file manually. Otherwise, they may think the command is magic.

---

# 12. Rules for Same Project

Use these rules in your instruction file:

```md
# Project Rules

- Use only HTML, CSS, and JavaScript.
- Do not use frameworks or libraries.
- Use `index.html` for markup.
- Use `styles.css` for styling.
- Use `script.js` for logic.
- Use semantic HTML tags.
- Use beginner-friendly JavaScript.
- Use `localStorage` for browser storage.
- Validate input before saving.
- Show success and error messages.
- Do not mix CSS or JavaScript inside HTML.
- Keep function names meaningful.
- Add comments for important logic.
```

---

# 13. Practical Classroom Flow

Use this sequence:

```text
1. Create empty folder.
2. Open folder in VS Code.
3. Create .github/copilot-instructions.md.
4. Create docs/requirements.md.
5. Ask Copilot /plan.
6. Save plan in docs/implementation-plan.md.
7. Ask Copilot Agent to implement using the Markdown files.
8. Review generated files.
9. Run index.html in browser.
10. Test registration, validation, localStorage, and delete.
11. Discuss how Markdown files controlled Copilot behavior.
```

---

# 14. Final Trainer Summary

Explain to experienced cohorts like this:

> Markdown files act as governance and memory for Copilot. A prompt is temporary, but Markdown files such as `copilot-instructions.md`, `requirements.md`, and `implementation-plan.md` keep the rules, requirements, and decisions inside the repository.

Then explain:

> Plan mode uses Markdown files to understand requirements and prepare steps. Agent execution uses Markdown files to implement files according to those rules.

Final comparison:

```text
Prompt only:
Fast, but easy to miss rules.

Markdown + Plan:
Better design and clear steps.

Markdown + Agent:
Better execution because Copilot has reusable project context.

Instruction file:
Permanent project rules.

Requirement file:
Business need.

Implementation plan:
Execution roadmap.

Test checklist:
Validation reference.
```

Final classroom sentence:

> For small projects, prompts are enough. For professional projects, Markdown files are important because they make Copilot follow agreed rules during planning and execution.
