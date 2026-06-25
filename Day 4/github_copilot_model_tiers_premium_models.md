# Model Tiers & Premium Models in GitHub Copilot



This document explains **Model Tiers & Premium Models** in GitHub Copilot with a real-world project example.

---

# 1. What does “Model Tiers & Premium Models” mean in GitHub Copilot?

In GitHub Copilot, **model tier** means the level/type of AI model available for use.

Some models are suitable for normal daily coding tasks. Some models are more powerful and are useful for:

```text
Complex reasoning
Large codebase understanding
Multi-file refactoring
Agent execution
Debugging
Architecture planning
Advanced code review
```

GitHub Copilot today is no longer just “one model for all tasks.” It can provide different model choices depending on your plan, IDE, organization settings, and available rollout.

---

# 2. Simple Explanation for Cohorts

You can explain it like this:

> GitHub Copilot has different AI models. Some are fast and cost-efficient. Some are more powerful and better for complex coding problems. Premium models usually give better reasoning and larger context handling, but they may consume more usage allowance or AI credits.

Simple analogy:

```text
Small model   = Fast junior assistant for regular tasks
Premium model = Senior assistant for complex debugging, planning, refactoring, and architecture
```

---

# 3. GitHub Copilot Plans and Model Access

GitHub Copilot has different plans such as:

```text
Copilot Free
Copilot Student
Copilot Pro
Copilot Pro+
Copilot Max
Copilot Business
Copilot Enterprise
```

A simplified trainer view:

| Plan | Best For | Model Access |
|---|---|---|
| Copilot Free | Trying Copilot | Limited usage and selected models |
| Copilot Student | Students | Student-friendly access depending on eligibility |
| Copilot Pro | Regular individual developer | Unlimited completions and selected models |
| Copilot Pro+ | Power users | Premium models and higher AI credits |
| Copilot Max | Heavy AI users | Highest individual AI credits and priority access |
| Copilot Business | Teams/organizations | Organization-level controls and model access policies |
| Copilot Enterprise | Large enterprises | Enterprise controls, advanced capabilities, and centralized management |

Trainer explanation:

> The available model list can differ from one user to another because it depends on plan, organization policy, IDE version, and rollout status.

---

# 4. What are Premium Models?

**Premium models** are more advanced models available in Copilot Chat or model picker.

They are useful for tasks that need stronger reasoning or larger context.

Examples of tasks where premium models help:

```text
1. Large codebase explanation
2. Multi-file refactoring
3. Complex debugging
4. Architecture planning
5. Security review
6. Migration from old code to new framework
7. Agent mode implementation
8. Generating complete test strategy
9. Reviewing pull requests
10. Understanding many related files
```

Trainer explanation:

> Premium models should be used when the task needs deeper understanding, not for every small prompt.

---

# 5. What are AI Credits / Premium Requests?

GitHub Copilot can use allowances such as AI credits or premium requests depending on the plan and billing model.

Usage can be affected by:

```text
1. Which model you use
2. How many tokens are consumed
3. How much context is sent
4. Whether you use Ask, Edit, Plan, or Agent mode
5. Whether the task involves many files
```

Tokens include:

```text
Input tokens  = what you send to the model
Output tokens = what the model generates
Cached tokens = reused context
```

Trainer explanation:

> A simple inline code suggestion may be low-cost or included. But using a premium model for a large workspace prompt, plan mode, or agent mode can consume more allowance because Copilot needs to read more context and reason more deeply.

---

# 6. Current Model Examples in GitHub Copilot

GitHub Copilot may show model choices from different providers such as:

```text
OpenAI models
Anthropic Claude models
Google Gemini models
Microsoft models
Other fine-tuned coding models
```

Model names may change over time. Examples you may see can include models from families such as:

```text
GPT models
Claude Sonnet models
Claude Opus models
Gemini models
Microsoft MAI models
Coding-specialized models
```

Important trainer note:

> Do not teach that everyone will see the same model list. Model availability depends on the Copilot plan, IDE, organization policy, and current rollout.

---

# 7. Extended Capabilities: Large Context and Reasoning

Some newer Copilot models may support extended capabilities such as:

```text
1. Larger context windows
2. Better code reasoning
3. Configurable reasoning levels
4. Better multi-file understanding
5. Better agent execution
```

A larger context window helps when working across:

```text
Large codebases
Long documentation
Multiple files
Complex feature implementation
Architecture reviews
```

Trainer explanation:

> Larger context and higher reasoning are useful, but they can consume more allowance. Do not always use the most powerful model. Use the right model for the right task.

---

# 8. When to Use Normal Model vs Premium Model

## Use normal/fast model for:

```text
1. Simple code completion
2. Small function generation
3. HTML/CSS changes
4. Simple JavaScript validation
5. Basic unit tests
6. Simple syntax explanation
7. Small bug fixes
```

Example prompt:

```text
/explain Explain this small JavaScript function.
```

or:

```text
Create a function to validate email format.
```

## Use premium model for:

```text
1. Full project analysis
2. Multi-file feature implementation
3. Agent mode task
4. Complex bug across frontend/backend
5. Migration/refactoring
6. Security/code review
7. Performance optimization
8. Architecture decision
9. Large test strategy
10. Understanding workspace-level dependency flow
```

Example prompt:

```text
@workspace /plan

Analyze this Node.js + React project and plan how to add role-based authorization.
Include API changes, UI changes, service changes, tests, and security considerations.
```

---

# 9. Real-Time Use Case: BrickBuddyApp Model Selection

Assume your project is:

```text
BrickBuddyApp
│
├── api
│   ├── controllers
│   │   ├── catalogController.js
│   │   ├── inventoryController.js
│   │   └── settingsController.js
│   ├── services
│   │   ├── catalogService.js
│   │   ├── inventorySyncService.js
│   │   ├── pricingService.js
│   │   └── settingsService.js
│   └── utils
│       └── response.js
│
└── ui
    └── src
        ├── pages
        │   ├── Catalog.jsx
        │   ├── Dashboard.jsx
        │   └── SettingsPage.jsx
        └── services
            └── apiClient.js
```

Now you want to implement:

```text
Low Inventory Alert Feature
```

Feature requirement:

```text
1. Backend should identify items below reorder level.
2. Frontend dashboard should show low inventory items.
3. API should return standardized response using response.js.
4. Service layer should contain business logic.
5. Jest tests should cover service and controller.
6. UI should show alert cards.
```

---

# 10. Example 1: Using a Basic/Fast Model

## Task

Create a small helper function.

## Prompt

```text
Create a JavaScript function named isLowStock that accepts quantity and reorderLevel.
Return true when quantity is less than or equal to reorderLevel.
```

## Expected Output

```javascript
function isLowStock(quantity, reorderLevel) {
    return quantity <= reorderLevel;
}
```

## Trainer Explanation

> This is a small isolated task. A normal/fast model is enough. No need to use a premium reasoning model.

---

# 11. Example 2: Using Premium Model for Planning

## Task

Plan the low inventory feature across API and UI.

## Prompt

```text
@workspace /plan

Use a premium reasoning model.

Plan a Low Inventory Alert feature for this BrickBuddyApp.

Requirements:
- Backend should expose GET /api/inventory/low-stock
- Business logic should be in inventorySyncService.js
- Controller should be thin
- Response should use utils/response.js
- UI Dashboard.jsx should show low stock alert cards
- apiClient.js should have a method getLowStockItems()
- Add Jest tests for controller and service

Do not write code yet.
Give file-wise implementation plan.
```

## Why Premium Model Is Suitable

```text
It must understand multiple folders.
It must reason about backend and frontend flow.
It must plan tests.
It must follow architecture rules.
It must avoid duplicate logic.
```

Trainer explanation:

> This is not a single-file task. It needs planning across backend, frontend, services, routes, response utilities, and tests. This is where a premium model is useful.

---

# 12. Example 3: Using Premium Model for Agent Execution

After approving the plan, ask:

```text
@workspace

Use the implementation plan from docs/low-inventory-plan.md.

Implement the Low Inventory Alert feature.

Create or update:
- api/controllers/inventoryController.js
- api/services/inventorySyncService.js
- api/routes/inventoryRoutes.js
- api/utils/response.js if needed
- ui/src/services/apiClient.js
- ui/src/pages/Dashboard.jsx
- Jest tests for controller and service

Rules:
- Keep controller thin.
- Put logic in service.
- Use standard ok response.
- Do not break existing catalog and settings features.
```

## Why Premium Model Is Suitable

```text
Agent execution changes multiple files.
It must preserve existing project behavior.
It must understand dependencies.
It must create tests.
It must avoid breaking routes and imports.
```

Trainer explanation:

> Agent mode can touch many files. A premium model is usually better when the agent must understand architecture, dependencies, and existing patterns.

---

# 13. Example 4: Using Premium Model for Debugging

Suppose you get this error:

```text
TypeError: getLowStockItems is not a function
```

Use:

```text
@workspace /fix

I get this runtime error:
TypeError: getLowStockItems is not a function

Check:
#file:ui/src/services/apiClient.js
#file:ui/src/pages/Dashboard.jsx
#file:api/routes/inventoryRoutes.js
#file:api/controllers/inventoryController.js
#file:api/services/inventorySyncService.js

Find the mismatch between frontend API call, export/import, and backend route.
Give the corrected code.
```

## Why Premium Model Helps

```text
The bug may be caused by route mismatch.
The bug may be caused by export/import mismatch.
The bug may be caused by function naming mismatch.
The bug may be caused by frontend/backend contract mismatch.
It needs cross-file reasoning.
```

Trainer explanation:

> Cross-file bugs are a good reason to use a stronger model with workspace context.

---

# 14. Example 5: Using Premium Model for Code Review

## Prompt

```text
@workspace

Review the Low Inventory Alert feature implementation.

Focus on:
- correctness
- controller/service separation
- response format
- error handling
- test coverage
- security
- maintainability
- unnecessary AI credit usage or overly broad context

Give issues by severity and suggest fixes.
```

## Why Premium Model Helps

```text
Code review needs reasoning.
It must inspect multiple files.
It must identify hidden design issues.
It must understand architecture.
It must detect missing tests.
```

Trainer explanation:

> Use premium models when quality and reasoning matter more than speed.

---

# 15. Trainer Demo: How to Choose Model inside VS Code

In VS Code Copilot Chat:

```text
1. Open Copilot Chat panel.
2. Look for the model picker/dropdown near the chat input area.
3. Select Auto for normal tasks.
4. Select a specific premium model for complex tasks.
5. Use Ask mode for questions.
6. Use Edit mode for controlled file edits.
7. Use Agent mode for multi-file implementation.
```

Trainer note:

> The exact model names shown in the picker depend on the user’s Copilot plan, organization policy, IDE version, and rollout status.

---

# 16. Model Selection by Task

| Task | Recommended Mode | Recommended Model Tier |
|---|---|---|
| Explain one selected function | Ask | Normal/fast model |
| Generate small helper function | Inline/Ask | Normal/fast model |
| Generate simple unit test | Ask/Edit | Normal/fast or mid-tier |
| Fix syntax error | Ask/Edit | Normal/fast |
| Fix cross-file runtime bug | Ask/Edit | Premium |
| Plan new feature | Plan | Premium reasoning model |
| Multi-file implementation | Agent | Premium model |
| Refactor architecture | Agent/Edit | Premium reasoning model |
| Security review | Ask/Review | Premium reasoning model |
| Large codebase explanation | Ask with workspace | Premium with larger context if needed |

---

# 17. How Model Choice Affects Usage

You can explain this to cohorts:

```text
Small task + small context = lower usage
Large task + workspace context = higher usage
Premium model + high reasoning = higher usage
Agent mode + many files = higher usage
Repeated large prompts = unnecessary usage
```

Best practice:

```text
Do not send entire project context for a small function.
Use #file or #selection for focused tasks.
Use @workspace only when project-level context is required.
Use premium model only when normal model is not enough.
Use /plan before Agent for complex tasks.
```

---

# 18. Good vs Bad Usage Examples

## Bad Example

```text
@workspace Use the most powerful model and rewrite my whole app.
```

## Problem

```text
Too broad.
Expensive in usage.
Risky.
No clear file boundary.
No test strategy.
```

## Good Example

```text
@workspace /plan

Plan only the Low Inventory Alert feature.
Use existing controller-service-route pattern.
Do not modify unrelated files.
List exact files to change.
```

## Why It Is Better

```text
Focused scope.
Clear expectation.
Less rework.
Safer Agent execution.
```

---

# 19. Best Classroom Explanation

Use this explanation:

> Model tiers in GitHub Copilot are like choosing the right developer for the task. For a small validation function, a fast model is enough. For a cross-file feature or architecture refactor, use a premium model. Premium models are powerful, but they can consume more AI credits, so use them intentionally.

---

# 20. Practical Trainer Script

You can explain to cohorts like this:

> Earlier Copilot was mostly seen as inline autocomplete. But now Copilot supports chat, edit mode, plan mode, agent mode, and multiple models. So model choice matters.

Then continue:

> If I ask Copilot to create a small JavaScript function, I do not need a premium model. But if I ask Copilot to analyze the full BrickBuddyApp and implement a low inventory alert feature across backend and frontend, I should use a stronger model.

Then explain:

> Premium models are useful for reasoning, but they should not be used blindly. The best developer workflow is to first plan with the right model, then execute carefully with controlled context.

---

# 21. Final Summary

```text
Model tier = level/type of AI model available in Copilot.
Premium model = advanced model for complex reasoning and larger tasks.
AI credits/premium requests = usage allowance affected by model and context size.
Ask mode = questions and explanation.
Edit mode = controlled edits.
Plan mode = design before implementation.
Agent mode = multi-file execution.
```

Final trainer point:

> In professional development, the goal is not to always use the strongest model. The goal is to choose the right model for the right task, provide the right context, and control cost and quality.
