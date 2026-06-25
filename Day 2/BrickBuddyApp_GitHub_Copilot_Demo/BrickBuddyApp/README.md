# BrickBuddyApp - GitHub Copilot Codebase Navigation Demo

BrickBuddyApp is a small working inventory application created for training learners on how to use **GitHub Copilot to understand a new codebase**.

It follows the same learning flow from the transcription script:

1. Open a new project in VS Code.
2. Ask Copilot for an architecture overview.
3. Create or improve a project cheat sheet.
4. Add `.github/copilot-instructions.md` as persistent project context.
5. Trace a UI action from React to Express API.
6. Map backend dependencies.
7. Troubleshoot a pricing issue using codebase context.

---

## Project Structure

```text
BrickBuddyApp/
├── .cursor/
│   └── rules.md
├── .github/
│   └── copilot-instructions.md
├── api/
│   ├── controllers/
│   ├── data/
│   ├── routes/
│   ├── services/
│   ├── utils/
│   └── server.js
├── docs/
│   ├── project_cheat_sheet.md
│   └── sync_journey_map.md
├── scripts/
├── ui/
│   ├── index.html
│   └── src/
├── package.json
└── README.md
```

---

## How to Run

### Step 1: Install dependencies

```bash
npm install
```

### Step 2: Run both UI and API

```bash
npm run dev
```

### Step 3: Open the application

Open:

```text
http://localhost:5173
```

The API runs at:

```text
http://localhost:4000
```

---

## Demo Pages

| Page | Purpose |
|---|---|
| Dashboard | Shows high-level inventory metrics |
| User Inventory | Contains the **Sync Inventory** workflow used for Copilot code-path tracing |
| Catalog | Demonstrates pricing logic and the pricing discrepancy bug scenario |
| API Testing | Internal tool to test API endpoints from the browser |
| Settings | Allows switching pricing region and pricing basis |

---

## Copilot Training Prompts

Use these prompts in GitHub Copilot Chat inside VS Code.

### Architecture Overview

```text
Give me a basic architecture overview of this project. Include key components, folder structure, API data flow, and common patterns.
```

### Shared Components

```text
What components or services are used repeatedly in this project? Create a reusable component and service summary.
```

### Trace Sync Workflow

```text
Show me how the inventory sync functionality works from the UI button click to the backend API response.
```

### Find API Endpoint

```text
The UI calls out to an API for inventory sync. Where is that endpoint defined, and which backend files handle the request?
```

### Troubleshoot Pricing

```text
When the user adds item 3001 black brick to the batch and pricing region is global, the price looks incorrect. Look through the codebase and identify the likely issue.
```

---

## Important Training Idea

> Copilot is the assistant, but the developer is the driver. Always provide context, verify its response, and iterate with better prompts.
