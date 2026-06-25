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
