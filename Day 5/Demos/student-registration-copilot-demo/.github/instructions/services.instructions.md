---
applyTo: "src/services/**/*.js"
---

# Service Instructions

These instructions apply only to service files inside `src/services`.

## Service Responsibilities

- Keep business logic and storage helpers in `src/services`
- Do not use React hooks or JSX in service files
- Do not implement UI rendering or component behavior here
- Keep service helpers reusable and easy to test

## Naming and Structure

- Use camelCase for service file names and exported functions
- Keep one service module focused on a single responsibility
- Use early returns for validation and error handling

## Data and Storage Rules

- Implement validation logic for student registration data
- Require `student name`, `email`, and `course`
- Keep localStorage access inside service helpers only
- Do not use external storage libraries
- Return plain objects, arrays, and primitive values from service functions

## Testing Guidance

- Write services so they are easy to unit test
- Do not depend on DOM APIs inside service functions
- Keep services decoupled from component state and lifecycle
