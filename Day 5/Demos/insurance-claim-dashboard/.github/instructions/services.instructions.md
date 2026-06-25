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
