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
