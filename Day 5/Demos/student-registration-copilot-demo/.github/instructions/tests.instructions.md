---
applyTo: "src/tests/**/*.js"
---

# Test Instructions

These instructions apply only to test files inside `src/tests`.

## Test responsibilities

- Write tests for components and service functions
- Keep tests focused on one behavior per test case
- Avoid using application-specific UI hacks or implementation details
- Prefer testing public component behavior and service outputs

## Test style

- Use descriptive test names
- Arrange, act, assert in each test
- Keep test files small and easy to understand
- Avoid deep coupling to internal component state

## Test scope

- Component tests should verify rendered output, user interactions, and validation behavior
- Service tests should verify validation logic, local storage helpers, and data transformation
- Do not test CSS or styling in unit tests

## Test file organization

- Name test files to match the module they cover, e.g. `registrationService.test.js`
- Keep one component or service test suite per file
- Keep helper code minimal and reusable across tests
