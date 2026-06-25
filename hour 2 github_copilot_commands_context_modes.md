# GitHub Copilot Chat – Commands, Context, Participants & Modes (React Example)

## Overview

This guide explains how to use:

- Slash Commands
- Context Variables (#)
- Chat Participants (@)
- Chat Modes
- Best Practices

Using a React application example.

---

## React Project Structure

```
src/
 ├── components/
 │   ├── ProductList.jsx
 │   ├── Cart.jsx
 │   └── SearchBar.jsx
 ├── pages/
 │   └── Home.jsx
 ├── utils/
 │   └── api.js
 └── App.jsx
```

---

# 1. Slash Commands

## /explain
Explain code

Example:
```
/explain #file ProductList.jsx
```

## /fix
Fix errors

Example:
```
/fix #problems in Cart.jsx
```

## /tests
Generate test cases

Example:
```
/tests #file Cart.jsx
```

## /new
Create new code

Example:
```
/new create a React hook for cart
```

## /clear
Clear chat context

## /help
Show available commands

## /init
Initialize project context

## /search
Search codebase

Example:
```
/search where cart total is calculated
```

## /delegate
Handle complex tasks

Example:
```
/delegate create checkout feature
```

---

# 2. Context Variables (#)

## #file
Specific file

```
/explain #file Cart.jsx
```

## #selection
Selected code

```
/fix #selection
```

## #codebase
Whole project

```
/search #codebase cart logic
```

## #problems
Errors

```
/fix #problems
```

## #terminalLastCommand
Terminal errors

```
/fix #terminalLastCommand
```

## #function / #class
Specific logic

```
/explain #function handleAddToCart
```

---

# 3. Chat Participants (@)

## @workspace
Project context

```
@workspace /fix cart issue
```

## @vscode
Editor help

```
@vscode enable auto format
```

## @terminal
Terminal help

```
@terminal run react app
```

## @github
Git help

```
@github create PR description
```

## @azure
Cloud help

```
@azure deploy app
```

---

# 4. Chat Modes

## Ask Mode
Explain / review

## Edit Mode
Modify code

## Agent Mode
Multi-file automation

## Plan Mode
Planning steps

## Inline Chat
Quick edits

## Voice Chat
Speech interaction

---

# 5. Best Practices

## Combine all features

Example:
```
@workspace /fix #problems in Cart.jsx
```

## Good Workflow

1. Plan
2. Generate
3. Fix
4. Test
5. Explain

---

# Final Rule

Precise Prompt = Better Output

```
@workspace + /command + #context
```
