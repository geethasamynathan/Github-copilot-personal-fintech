# Copilot Instructions for student-registration-copilot-demo

## Project Overview

You are developing a minimal React + Vite frontend application for student registration. The application should remain small and simple, with UI components in `src/components`, business logic in `src/services`, and styling in plain CSS.

## Technology stack

This project uses:

- React with JavaScript
- Vite for development and build
- ESLint for linting
- Plain CSS for styling
- npm for package management

## Architecture Rules

Develop the application with a clean frontend structure:

- Keep reusable UI components in `src/components`
- Keep business logic and local storage helpers in `src/services`
- Keep tests in `src/tests`
- Keep components small and focused.
- Do not place localstorage logic directly inside comnponents unless there is a strong reason.

## Coding Standards

Follow these coding standards when writing or updating code:

- Use React with JavaScript only
- Do not use TypeScript
- Use `const` and `let` appropriately do not use `var`
- Use functional components and React hooks
- Use React hooks such as`useState` ,`useEffect`
- use meaningful function names.
- use early reurns for validation.
- Keep code beginner-friendly and readble.

## Naming conventions

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
