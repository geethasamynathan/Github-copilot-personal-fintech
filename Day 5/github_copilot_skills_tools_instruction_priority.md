# GitHub Copilot: Skills & Custom Tools and Instruction Priority System

# 1. What are Skills in GitHub Copilot?

**Skills** are reusable task-specific instructions, scripts, and resources that Copilot can load when they are relevant to a particular task.

## Simple Explanation for Cohorts

> A skill is like giving Copilot a reusable mini-training module for a specific task.

Example:

```text
Normal Copilot:
"Write tests for this service."

Copilot with skill:
"Write tests following our team's exact API testing pattern, naming style, mock rules, and coverage checklist."
```

Skills are useful when the same type of task is repeated many times and the team wants Copilot to follow a standard workflow.

---

# 2. When to Use Skills?

Use **Skills** when the task is repeated and specialized.

Good use cases:

```text
1. Generate API tests using company standard
2. Review security issues in controllers
3. Create database migration checklist
4. Generate accessibility checklist for React pages
5. Create production-readiness review
6. Generate API documentation from controller files
7. Review logging and exception handling
8. Validate folder structure before agent execution
```

Do **not** use skills for very small one-time tasks.

Example where skill is not needed:

```text
Create one JavaScript function to format a date.
```

Example where skill is useful:

```text
Review the complete claim approval feature for security, validation, naming, exception handling, and test coverage.
```

---

# 3. Who Will Use Skills?

Different roles can use skills differently.

| Role | How They Use Skills |
|---|---|
| Java Full Stack Developer | Spring Boot controller review, DTO validation, repository pattern check |
| .NET Full Stack Developer | Web API review, service/repository pattern check, SQL Server compatibility |
| Python Developer | FastAPI router/service/schema review |
| React Developer | Component accessibility, props structure, state handling review |
| Tester | API test generation, Playwright test checklist, defect report validation |
| Tech Lead | Code review checklist, architecture review, pull request validation |
| Trainer | Standardize repeated lab tasks for cohorts |

---

# 4. Why Use Skills?

Skills help because they:

```text
1. Avoid repeating long prompts
2. Standardize team workflow
3. Reduce inconsistent Copilot output
4. Improve code review quality
5. Help experienced developers automate repeated checks
6. Help freshers follow correct patterns
7. Keep role-specific rules reusable
```

Trainer explanation:

> If repository instructions are the project rules, skills are reusable task workflows.

---

# 5. What are Custom Tools in GitHub Copilot?

**Custom Tools** are actions or capabilities that Copilot agents can use while working on a task.

## Simple Explanation

> A skill tells Copilot how to think or perform a workflow. A tool lets Copilot do an action.

Examples of tools:

```text
Read files
Search codebase
Edit files
Run terminal commands
Run tests
Use MCP server
Call external API through MCP
Use extension-provided tools
```

---

# 6. Skills vs Custom Tools vs Instructions vs Custom Agents

This is very important for experienced cohorts.

| Feature | What It Means | Best Used For |
|---|---|---|
| Custom Instructions | Always-on project rules | Coding standards, naming, architecture |
| Path-Specific Instructions | Folder/file-specific rules | Controllers, services, tests, UI components |
| Skills | Reusable task-specific workflow | API test generation, security review, DB checklist |
| Custom Tools | Actions Copilot can perform | Run tests, search files, use MCP, call APIs |
| Custom Agents | Specialized Copilot persona/workflow | Code reviewer, security reviewer, test planner |
| Prompt Files | Reusable prompt templates | Repeated prompts like generate service tests |

---

# 7. What is the Instruction Priority System?

The **Instruction Priority System** decides which instructions win when multiple instructions apply.

## Priority Order

```text
1. Personal instructions
2. Repository instructions
3. Organization instructions
```

## Simple Example

Organization instruction:

```text
Use secure coding practices.
```

Repository instruction:

```text
Use React functional components.
```

Personal instruction:

```text
Explain code in simple trainer-friendly language.
```

When Copilot generates a React component, it should combine all:

```text
Use secure coding.
Use React functional component.
Explain in trainer-friendly language.
```

If there is a conflict, the higher priority instruction wins.

Trainer explanation:

> Instructions are layered. Copilot receives all relevant instructions, but if they conflict, higher-priority instructions win.

---

# 8. Path-Specific Instructions and Priority

Path-specific instructions are targeted repository instructions.

Example:

Repository-wide instruction:

```text
Use service layer for business logic.
```

Path-specific instruction for `src/components/**/*.jsx`:

```text
Do not call APIs directly inside reusable React components.
```

When Copilot works on:

```text
src/components/ClaimList.jsx
```

The component-specific instruction becomes relevant.

Trainer explanation:

> Repository-wide instruction tells Copilot the general rule. Path-specific instruction tells Copilot the rule for a specific folder or file type.

---

# 9. Practical Project Use Case

## Project: Insurance Claim Review Dashboard

We will implement a simple **React + API service structure** project in VS Code.

This project is useful for experienced cohorts because it demonstrates:

```text
Repository instructions
Path-specific instructions
Skills
Custom agent
Custom tools concept
Instruction priority
Context variables
Copilot Auto mode
```

## Business Scenario

An insurance company wants a dashboard where claim officers can:

```text
1. View insurance claims
2. Filter claims by status
3. Approve or reject a claim
4. Keep API calls inside service files
5. Keep UI components reusable
6. Follow team coding standards
7. Use Copilot skills for review and test planning
```

---

# 10. Project Folder Structure

Create this structure:

```text
insurance-claim-dashboard
│
├── .github
│   ├── copilot-instructions.md
│   ├── instructions
│   │   ├── react-components.instructions.md
│   │   ├── services.instructions.md
│   │   └── tests.instructions.md
│   ├── agents
│   │   └── claim-code-reviewer.agent.md
│   └── skills
│       ├── api-test-planner
│       │   └── SKILL.md
│       └── claim-review-checklist
│           └── SKILL.md
│
├── src
│   ├── components
│   │   ├── ClaimFilter.jsx
│   │   └── ClaimTable.jsx
│   ├── pages
│   │   └── ClaimsDashboard.jsx
│   ├── services
│   │   └── claimService.js
│   ├── tests
│   │   └── claimService.test.js
│   ├── App.jsx
│   └── App.css
│
└── package.json
```

---

# 11. Step-by-Step Implementation in VS Code

## Step 1: Create React Project

Open VS Code terminal:

```bash
npm create vite@latest insurance-claim-dashboard
```

Choose:

```text
Framework: React
Variant: JavaScript
```

Then run:

```bash
cd insurance-claim-dashboard
npm install
code .
```

Start app:

```bash
npm run dev
```

---

# 12. Step 2: Enable Copilot Auto Mode

In VS Code:

```text
1. Open Copilot Chat.
2. Look near the chat input for the model selector.
3. Select Auto.
4. Use Agent mode only when you want Copilot to create or edit multiple files.
```

Trainer explanation:

> Auto mode allows Copilot to select an appropriate available model. We still guide it using custom instructions, path-specific rules, context variables, and clear prompts.

---

# 13. Step 3: Create Repository-Wide Instructions

Create:

```text
.github/copilot-instructions.md
```

Add:

```md
# Copilot Instructions for Insurance Claim Dashboard

## Project Overview
This is a React JavaScript application for insurance claim review and approval.

## Technology Stack
- Use React with JavaScript.
- Use Vite structure.
- Use plain CSS.
- Do not use TypeScript.
- Do not use Redux.
- Do not use external UI libraries unless explicitly requested.

## Architecture Rules
- Keep reusable UI components inside `src/components`.
- Keep page-level screens inside `src/pages`.
- Keep API and mock data logic inside `src/services`.
- Keep tests inside `src/tests`.
- Do not call APIs directly inside reusable components.
- Do not place business rules inside CSS or markup.

## Coding Standards
- Use functional React components.
- Use React hooks such as `useState` and `useEffect`.
- Use `const` and `let`; do not use `var`.
- Use meaningful function names.
- Use early returns for validation.
- Keep code readable for corporate training cohorts.

## Naming Conventions
- Component files must use PascalCase.
  Example: `ClaimTable.jsx`
- Service files must use camelCase.
  Example: `claimService.js`
- Function names must use camelCase.
  Example: `approveClaim`
- CSS class names must use kebab-case.
  Example: `claim-status-badge`

## Business Rules
- Claim status can be Pending, Approved, or Rejected.
- Only Pending claims can be approved or rejected.
- Approved claim amount cannot be greater than requested amount.
- Rejected claims must have a rejection reason.

## Output Rules
- Mention which file should be created or changed.
- Do not modify unrelated files.
- Explain important decisions briefly.
```

---

# 14. Step 4: Create Path-Specific Instructions

Create folder:

```text
.github/instructions
```

## 14.1 React Component Instructions

Create:

```text
.github/instructions/react-components.instructions.md
```

Add:

```md
---
applyTo: "src/components/**/*.jsx"
---

# React Component Instructions

These instructions apply only to reusable React components.

## Component Rules
- Use functional components only.
- Use PascalCase for component names.
- Keep one component per file.
- Accept data and callbacks through props.
- Do not directly access localStorage.
- Do not call API methods directly from reusable components.
- Do not hard-code claim data inside components.

## JSX Rules
- Use semantic HTML where possible.
- Use clear table headers.
- Use buttons with meaningful text.
- Render empty states clearly.

## Styling Rules
- Use CSS classes from `App.css`.
- Use kebab-case CSS class names.
```

## 14.2 Service Instructions

Create:

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
- Keep API calls, mock data, and claim business logic here.
- Do not import React.
- Use named exports.
- Return plain JavaScript objects or arrays.
- Keep business rules testable.
- Do not manipulate DOM in service files.

## Claim Rules
- Only Pending claims can be approved.
- Only Pending claims can be rejected.
- Return updated claim lists after status changes.
```

## 14.3 Test Instructions

Create:

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
- Test positive and negative scenarios.
- Test business rules.
- Avoid testing implementation details.
- Mock browser or API behavior when needed.
```

---

# 15. Step 5: Create a Custom Skill

## 15.1 Skill 1: API Test Planner

Create folder:

```text
.github/skills/api-test-planner
```

Create file:

```text
.github/skills/api-test-planner/SKILL.md
```

Add:

```md
# API Test Planner Skill

Use this skill when the user asks to create API test scenarios, service test cases, or endpoint validation plans.

## Purpose
Create complete API and service-level test plans for the Insurance Claim Dashboard.

## When to Use
Use this skill for:
- API test planning
- Service test planning
- Business rule test coverage
- Positive, negative, and boundary scenarios

## Test Coverage Rules
Always include:
1. Positive scenario
2. Negative scenario
3. Boundary scenario
4. Invalid status scenario
5. Missing data scenario
6. Business rule violation scenario

## Output Format
Return test cases in this format:

| Test ID | Scenario | Input | Expected Result | Type |
|---|---|---|---|---|

## Business Rules to Validate
- Pending claims can be approved.
- Pending claims can be rejected.
- Approved claims cannot be approved again.
- Rejected claims cannot be approved.
- Rejection reason is required for rejected claims.
```

Trainer explanation:

> This skill helps Copilot repeatedly produce structured API test plans without rewriting the same long prompt.

## 15.2 Skill 2: Claim Review Checklist

Create folder:

```text
.github/skills/claim-review-checklist
```

Create file:

```text
.github/skills/claim-review-checklist/SKILL.md
```

Add:

```md
# Claim Review Checklist Skill

Use this skill when reviewing claim dashboard code.

## Purpose
Review React claim dashboard code for architecture, naming, business rules, and maintainability.

## Review Checklist
Check the following:

1. Components
   - Components are reusable.
   - Components receive data through props.
   - Components do not call services directly unless they are page-level components.

2. Services
   - Service files do not import React.
   - Business rules are inside services.
   - Service functions use named exports.

3. Naming
   - Components use PascalCase.
   - Functions use camelCase.
   - CSS classes use kebab-case.

4. Business Rules
   - Only Pending claims can be approved.
   - Only Pending claims can be rejected.
   - Rejected claims require a reason.

5. Tests
   - Positive tests are included.
   - Negative tests are included.
   - Business rule tests are included.

## Output Format
Provide:
1. File reviewed
2. Issue
3. Severity
4. Suggested fix
```

---

# 16. Step 6: Create a Custom Agent

Create folder:

```text
.github/agents
```

Create file:

```text
.github/agents/claim-code-reviewer.agent.md
```

Add:

```md
---
name: Claim Code Reviewer
description: Reviews React claim dashboard code for architecture, naming, business rules, and tests.
---

# Claim Code Reviewer Agent

You are a strict but helpful code reviewer for the Insurance Claim Dashboard.

## Review Responsibilities
- Check repository-wide instructions.
- Check path-specific instructions.
- Check React component structure.
- Check service-layer business rules.
- Check naming conventions.
- Check test coverage.
- Check if Copilot-generated code modified unrelated files.

## Tools and Context
Use available workspace context and file context.
Do not edit files unless explicitly asked.

## Output Format
For each issue, provide:
1. File name
2. Problem
3. Why it matters
4. Suggested fix
5. Severity: Low, Medium, or High

## Rules
- Do not rewrite the whole file unless asked.
- Give focused suggestions.
- Prefer maintainable and beginner-readable code.
```

---

# 17. Step 7: Create the Service File Using Copilot

In Copilot Chat Auto mode, use:

```text
@workspace

Create #file:src/services/claimService.js.

Requirements:
- Store mock claim data in this service file.
- Export named functions:
  - getClaims
  - approveClaim
  - rejectClaim
- Only Pending claims can be approved.
- Only Pending claims can be rejected.
- Rejected claims require a rejection reason.
- Follow repository-wide and service path-specific instructions.
```

## Expected Output: `src/services/claimService.js`

```javascript
const claims = [
    {
        id: 1,
        claimantName: "Arun Kumar",
        claimType: "Vehicle Damage",
        requestedAmount: 75000,
        approvedAmount: 0,
        status: "Pending",
        rejectionReason: ""
    },
    {
        id: 2,
        claimantName: "Meena Rao",
        claimType: "Property Damage",
        requestedAmount: 125000,
        approvedAmount: 0,
        status: "Pending",
        rejectionReason: ""
    }
];

export function getClaims() {
    return claims;
}

export function approveClaim(claimId, approvedAmount) {
    const claim = claims.find((item) => item.id === claimId);

    if (!claim) {
        throw new Error("Claim not found.");
    }

    if (claim.status !== "Pending") {
        throw new Error("Only pending claims can be approved.");
    }

    if (approvedAmount <= 0 || approvedAmount > claim.requestedAmount) {
        throw new Error("Approved amount must be greater than zero and less than or equal to requested amount.");
    }

    claim.status = "Approved";
    claim.approvedAmount = approvedAmount;

    return claims;
}

export function rejectClaim(claimId, rejectionReason) {
    const claim = claims.find((item) => item.id === claimId);

    if (!claim) {
        throw new Error("Claim not found.");
    }

    if (claim.status !== "Pending") {
        throw new Error("Only pending claims can be rejected.");
    }

    if (!rejectionReason || !rejectionReason.trim()) {
        throw new Error("Rejection reason is required.");
    }

    claim.status = "Rejected";
    claim.rejectionReason = rejectionReason;

    return claims;
}
```

---

# 18. Step 8: Create a Table Component Using Copilot

Prompt:

```text
@workspace

Create #file:src/components/ClaimTable.jsx.

Requirements:
- Accept claims through props.
- Accept onApprove and onReject callback props.
- Display claimant name, claim type, requested amount, approved amount, status, and action buttons.
- Show Approve and Reject buttons only for Pending claims.
- Do not call service functions directly.
- Follow component path-specific instructions.
```

## Expected Output: `src/components/ClaimTable.jsx`

```jsx
function ClaimTable({ claims, onApprove, onReject }) {
    if (claims.length === 0) {
        return <p>No claims found.</p>;
    }

    return (
        <table className="claim-table">
            <thead>
                <tr>
                    <th>Claimant</th>
                    <th>Type</th>
                    <th>Requested Amount</th>
                    <th>Approved Amount</th>
                    <th>Status</th>
                    <th>Action</th>
                </tr>
            </thead>

            <tbody>
                {claims.map((claim) => (
                    <tr key={claim.id}>
                        <td>{claim.claimantName}</td>
                        <td>{claim.claimType}</td>
                        <td>{claim.requestedAmount}</td>
                        <td>{claim.approvedAmount}</td>
                        <td>{claim.status}</td>
                        <td>
                            {claim.status === "Pending" ? (
                                <>
                                    <button onClick={() => onApprove(claim.id)}>
                                        Approve
                                    </button>
                                    <button onClick={() => onReject(claim.id)}>
                                        Reject
                                    </button>
                                </>
                            ) : (
                                <span>No action</span>
                            )}
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}

export default ClaimTable;
```

---

# 19. Step 9: Create Page-Level Dashboard Using Copilot

Prompt:

```text
@workspace

Create #file:src/pages/ClaimsDashboard.jsx.

Use:
#file:src/components/ClaimTable.jsx
#file:src/services/claimService.js

Requirements:
- Load claims from claimService.
- Keep claims in state.
- Implement approve and reject handlers.
- Ask for approved amount using prompt.
- Ask for rejection reason using prompt.
- Show error message if business rule fails.
- Page-level component may call service functions.
- Follow repository-wide instructions.
```

## Expected Output: `src/pages/ClaimsDashboard.jsx`

```jsx
import { useEffect, useState } from "react";
import ClaimTable from "../components/ClaimTable";
import { approveClaim, getClaims, rejectClaim } from "../services/claimService";

function ClaimsDashboard() {
    const [claims, setClaims] = useState([]);
    const [errorMessage, setErrorMessage] = useState("");

    useEffect(() => {
        setClaims([...getClaims()]);
    }, []);

    function handleApprove(claimId) {
        try {
            const amountInput = window.prompt("Enter approved amount:");
            const approvedAmount = Number(amountInput);

            const updatedClaims = approveClaim(claimId, approvedAmount);
            setClaims([...updatedClaims]);
            setErrorMessage("");
        } catch (error) {
            setErrorMessage(error.message);
        }
    }

    function handleReject(claimId) {
        try {
            const reason = window.prompt("Enter rejection reason:");

            const updatedClaims = rejectClaim(claimId, reason);
            setClaims([...updatedClaims]);
            setErrorMessage("");
        } catch (error) {
            setErrorMessage(error.message);
        }
    }

    return (
        <main className="claims-dashboard">
            <h1>Insurance Claim Review Dashboard</h1>

            {errorMessage && (
                <p className="error-message">{errorMessage}</p>
            )}

            <ClaimTable
                claims={claims}
                onApprove={handleApprove}
                onReject={handleReject}
            />
        </main>
    );
}

export default ClaimsDashboard;
```

---

# 20. Step 10: Update App.jsx

Prompt:

```text
@workspace

Update #file:src/App.jsx to render #file:src/pages/ClaimsDashboard.jsx.
Do not modify unrelated files.
```

Expected output:

```jsx
import ClaimsDashboard from "./pages/ClaimsDashboard";
import "./App.css";

function App() {
    return <ClaimsDashboard />;
}

export default App;
```

---

# 21. Step 11: Generate Tests Using the Skill

Prompt:

```text
@workspace /tests

Use the API Test Planner skill if available.

Create test scenarios for #file:src/services/claimService.js.

Cover:
1. getClaims returns claim list.
2. approveClaim approves a Pending claim.
3. approveClaim fails when claim is already Approved.
4. approveClaim fails when approved amount is greater than requested amount.
5. rejectClaim rejects a Pending claim.
6. rejectClaim fails when reason is empty.

Follow #file:.github/instructions/tests.instructions.md.
```

---

# 22. Step 12: Review Code Using Custom Agent

Select:

```text
Claim Code Reviewer
```

Then ask:

```text
Review these files:
#file:src/services/claimService.js
#file:src/components/ClaimTable.jsx
#file:src/pages/ClaimsDashboard.jsx

Check:
- repository instructions
- path-specific instructions
- claim business rules
- naming conventions
- component/service separation
- missing tests
```

---

# 23. What Context Variables to Use?

Context variables help Copilot understand exactly what to inspect.

## Common Context Variables for This Topic

| Context Variable | Use It When |
|---|---|
| `@workspace` | You want Copilot to understand project-wide context |
| `#file` | You want Copilot to inspect specific files |
| `#selection` | You selected code and want Copilot to explain, fix, or review it |
| `#terminalLastCommand` | You want Copilot to use the latest terminal command/error |
| `#changes` | You want Copilot to review current Git changes |
| `#codebase` | You want broader codebase context if available in your setup |
| `#problems` | You want Copilot to inspect visible VS Code problems/errors |
| `#function` | You want Copilot to focus on a function |
| `#class` | You want Copilot to focus on a class |

---

# 24. Best Context Variable Examples

## Example 1: Create Service with Exact File

```text
@workspace

Create #file:src/services/claimService.js.
Follow service instructions and repository instructions.
```

Use when:

```text
Creating or updating one specific file
```

## Example 2: Review Selected Code

Select a function, then ask:

```text
/explain Explain #selection.
Check whether it follows the claim business rules.
```

Use when:

```text
You want focused explanation
```

## Example 3: Fix Terminal Error

```text
@workspace /fix

Use #terminalLastCommand and #file:src/pages/ClaimsDashboard.jsx.

Fix the React runtime error.
Explain the root cause.
```

Use when:

```text
Terminal error or runtime issue occurred
```

## Example 4: Review Current Changes

```text
Review #changes.

Check whether the changes follow:
#file:.github/copilot-instructions.md
#file:.github/instructions/react-components.instructions.md
#file:.github/instructions/services.instructions.md
```

Use when:

```text
Before committing code
```

## Example 5: Generate Tests

```text
@workspace /tests

Create tests for #file:src/services/claimService.js.
Follow #file:.github/instructions/tests.instructions.md.
```

Use when:

```text
Generating tests for a specific file
```

---

# 25. When to Use Skills vs Custom Tools

## Use Skills When

```text
You need repeated task-specific guidance.
You need a checklist.
You need a structured workflow.
You need domain-specific review.
You need test scenario generation.
```

Example:

```text
Generate API test scenarios for claim approval using our standard format.
```

## Use Custom Tools When

```text
Copilot needs to perform an action.
Copilot needs to run tests.
Copilot needs to search files.
Copilot needs access to an external system through MCP.
Copilot needs to call an API or use extension-provided functionality.
```

Example:

```text
Run the test command and fix failures.
```

---

# 26. Who Uses Skills and Custom Tools in a Team?

| Team Member | Uses Skills For | Uses Tools For |
|---|---|---|
| Developer | Code review, test generation, refactoring checklist | Run tests, search files, edit files |
| Tester | API test planning, UI test scenario generation | Run Playwright, inspect reports |
| Tech Lead | Architecture review, PR checklist | Review changes, inspect workspace |
| DevOps Engineer | Deployment checklist, pipeline review | Run scripts, inspect config |
| Security Engineer | Security checklist, vulnerability review | Search dependencies, inspect configs |

---

# 27. Instruction Priority Example in This Project

## Organization Instruction

```text
All applications must follow secure coding practices.
```

## Repository Instruction

```text
Insurance claim business rules must be inside service files.
```

## Path-Specific Instruction

```text
React components must not call services directly unless they are page-level components.
```

## Personal Instruction

```text
Explain everything in trainer-friendly step-by-step language.
```

When asking:

```text
@workspace Create ClaimTable.jsx.
```

Copilot should:

```text
Use secure coding.
Keep business logic outside component.
Accept data through props.
Explain in trainer-friendly style.
```

---

# 28. Practical Trainer Explanation

Explain like this:

> Instructions are rules. Skills are reusable workflows. Tools are actions. Agents are specialized workers. Context variables are how we point Copilot to the exact information it should use.

Then show this mapping:

```text
Rules        → .github/copilot-instructions.md
Folder rules → .github/instructions/*.instructions.md
Workflow     → .github/skills/*/SKILL.md
Special role → .github/agents/*.agent.md
Action       → Agent tools / MCP / terminal tools
Context      → @workspace, #file, #selection, #changes, #terminalLastCommand
```

---

# 29. Final Classroom Summary

## Skills

```text
What:
Reusable task-specific instructions, resources, and scripts.

When:
Repeated workflows like test planning, code review, security checklist.

Who:
Developers, testers, tech leads, DevOps, security teams.

Why:
To standardize repeated tasks and reduce long prompts.
```

## Custom Tools

```text
What:
Capabilities agents can use to perform actions.

When:
Need to run tests, search files, edit files, call external systems, use MCP.

Who:
Developers, testers, DevOps, advanced Copilot users.

Why:
To let Copilot act, not only answer.
```

## Instruction Priority

```text
What:
Rule system that decides which instructions win.

Priority:
1. Personal instructions
2. Repository instructions
3. Organization instructions

Why:
To resolve conflicts and combine user, project, and company rules.
```

Final trainer line:

> In current GitHub Copilot, professional usage is not only writing prompts. It is about building a guidance system using instructions, skills, agents, tools, and context variables so Copilot behaves like a trained team member inside your project.
