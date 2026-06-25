# Test Checklist

## Basic page structure
- [ ] `index.html` loads without errors.
- [ ] Form is visible with inputs for Student Name, Email, and Course.
- [ ] Course dropdown includes:
  - HTML Basics
  - CSS Fundamentals
  - JavaScript Essentials
  - GitHub Copilot for Developers
- [ ] Table header includes Student Name, Email, Course, and Action.

## Validation
- [ ] Submitting with an empty name shows an error.
- [ ] Submitting with an empty email shows an error.
- [ ] Submitting with an invalid email shows an error.
- [ ] Submitting without selecting a course shows an error.

## LocalStorage persistence
- [ ] A valid registration is saved and displayed in the table.
- [ ] Refreshing the page keeps saved registrations.
- [ ] The table updates correctly after refresh.

## Delete functionality
- [ ] Each registration row has a delete button.
- [ ] Clicking delete removes the registration from the table.
- [ ] Deleted registration is removed from `localStorage`.

## Messages
- [ ] Success message appears after saving a registration.
- [ ] Success message appears after deleting a registration.
- [ ] Error messages appear when validation fails.

## Project rules
- [ ] Uses only plain HTML, CSS, and JavaScript.
- [ ] No frameworks or external libraries are used.
