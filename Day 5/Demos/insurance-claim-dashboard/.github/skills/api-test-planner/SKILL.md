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
| ------- | -------- | ----- | --------------- | ---- |

## Business Rules to Validate

- Pending claims can be approved.
- Pending claims can be rejected.
- Approved claims cannot be approved again.
- Rejected claims cannot be approved.
- Rejection reason is required for rejected claims
