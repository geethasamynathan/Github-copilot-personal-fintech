# Implementation Plan

## Overview
Create a simple student course registration website using plain HTML, CSS, and JavaScript that follows the project constraints: no frameworks, no external libraries, and split files by role.

## Project Files
- docs/implementation-plan.md — (this file) Implementation plan and responsibilities.
- index.html — Main HTML document containing the registration form, table for registrations, and placeholders for messages.
- styles.css — All styling for layout, form, table, and messages; responsive and accessible.
- script.js — All JavaScript: DOM interactions, validation, localStorage persistence, rendering, and delete actions.
- README.md — Short project description, run instructions, feature list, and manual test checklist.

## File Responsibilities

### index.html
- Use semantic HTML elements (`header`, `main`, `form`, `section`, `table`, `footer`).
- Include a registration form with fields:
  - Student Name (text input)
  - Email (email input)
  - Course (select dropdown with options: HTML Basics, CSS Fundamentals, JavaScript Essentials, GitHub Copilot for Developers)
  - Register button
- Include a table or list element to display saved registrations.
- Add visible placeholders for success and error messages.
- Link to `styles.css` and `script.js`.

### styles.css
- Provide a clean, beginner-friendly visual design.
- Style form layout and controls for clarity and accessibility.
- Style the registrations table: header, rows, zebra striping, and responsive behavior.
- Style success and error messages with distinct colors and dismiss/timed styles.
- Provide focus outlines and readable typography; ensure responsive layout for narrow viewports.

### script.js
- DOM selection helpers and initialization (load registrations on DOMContentLoaded).
- Validation:
  - Student name: non-empty
  - Email: basic regex check for format
  - Course: must be selected
- Persistence:
  - Save registration objects to localStorage
  - Load registrations from localStorage on start
  - Delete registration by id (or index) and update storage
- Rendering:
  - Render registrations into the table with a delete button per row
  - Render empty-state UI when no registrations exist
- UX:
  - Show success and error messages (timed and dismissible)
  - Optionally confirm deletes with a small affordance (e.g., confirm prompt)
- Code style:
  - Use `const` and `let`
  - Use clear, descriptive function names and small functions
  - Add comments for important logic

### README.md
- Project purpose and features.
- How to run: open the HTML file in a browser.
- Constraints (no frameworks/libraries).
- Manual test checklist (add, persist after reload, delete, validation, responsive view).

## Implementation Order (step-by-step)
1. Scaffold files: `index.html`, `styles.css`, `script.js`, `README.md`.
2. Add basic semantic HTML structure and static form/table markup in `index.html`.
3. Add base styles in `styles.css` to layout the form and table.
4. Implement `script.js` load/render logic to show stored registrations.
5. Implement form submit handler: validation, save to localStorage, re-render, show success message.
6. Implement delete handler: remove from storage, re-render, show success message.
7. Add validation messages and error handling in UI.
8. Add responsive tweaks and accessibility checks (focus, labels).
9. Manual testing and polish (edge cases, empty-state, small screens).

## UX & Validation Details
- Email validation via a simple regex (not overly strict).
- Display friendly, dismissible messages for success and errors.
- Prevent saving when validation fails; highlight invalid fields.
- Optional: prevent exact duplicate registrations (name + email + course).

## Testing Checklist
- Add a new registration; verify it appears in the table.
- Reload the page; verify registration persists.
- Delete a registration; verify it is removed from UI and localStorage.
- Test validation: empty name, invalid email, no course selected.
- Verify empty-state message when no registrations exist.
- Check layout on narrow/mobile viewport.

## Next Step
If this plan looks good, implement the files in the order above and run the manual tests.
# Implementation Plan

## Overview
Create a simple student course registration website using plain HTML, CSS, and JavaScript that follows the project constraints: no frameworks, no external libraries, and split files by role.

## Project Files
- docs/implementation-plan.md — (this file) Implementation plan and responsibilities.
- index.html — Main HTML document containing the registration form, table for registrations, and placeholders for messages.
- styles.css — All styling for layout, form, table, and messages; responsive and accessible.
- script.js — All JavaScript: DOM interactions, validation, localStorage persistence, rendering, and delete actions.
- README.md — Short project description, run instructions, feature list, and manual test checklist.

## File Responsibilities

### index.html
- Use semantic HTML elements (`header`, `main`, `form`, `section`, `table`, `footer`).
- Include a registration form with fields:
  - Student Name (text input)
  - Email (email input)
  - Course (select dropdown with options: HTML Basics, CSS Fundamentals, JavaScript Essentials, GitHub Copilot for Developers)
  - Register button
- Include a table or list element to display saved registrations.
- Add visible placeholders for success and error messages.
- Link to `styles.css` and `script.js`.

### styles.css
- Provide a clean, beginner-friendly visual design.
- Style form layout and controls for clarity and accessibility.
- Style the registrations table: header, rows, zebra striping, and responsive behavior.
- Style success and error messages with distinct colors and dismiss/timed styles.
- Provide focus outlines and readable typography; ensure responsive layout for narrow viewports.

### script.js
- DOM selection helpers and initialization (load registrations on DOMContentLoaded).
- Validation:
  - Student name: non-empty
  - Email: basic regex check for format
  - Course: must be selected
- Persistence:
  - Save registration objects to localStorage
  - Load registrations from localStorage on start
  - Delete registration by id (or index) and update storage
- Rendering:
  - Render registrations into the table with a delete button per row
  - Render empty-state UI when no registrations exist
- UX:
  - Show success and error messages (timed and dismissible)
  - Optionally confirm deletes with a small affordance (e.g., confirm prompt)
- Code style:
  - Use `const` and `let`
  - Use clear, descriptive function names and small functions
  - Add comments for important logic

### README.md
- Project purpose and features.
- How to run: open the HTML file in a browser.
- Constraints (no frameworks/libraries).
- Manual test checklist (add, persist after reload, delete, validation, responsive view).

## Implementation Order (step-by-step)
1. Scaffold files: `index.html`, `styles.css`, `script.js`, `README.md`.
2. Add basic semantic HTML structure and static form/table markup in `index.html`.
3. Add base styles in `styles.css` to layout the form and table.
4. Implement `script.js` load/render logic to show stored registrations.
5. Implement form submit handler: validation, save to localStorage, re-render, show success message.
6. Implement delete handler: remove from storage, re-render, show success message.
7. Add validation messages and error handling in UI.
8. Add responsive tweaks and accessibility checks (focus, labels).
9. Manual testing and polish (edge cases, empty-state, small screens).

## UX & Validation Details
- Email validation via a simple regex (not overly strict).
- Display friendly, dismissible messages for success and errors.
- Prevent saving when validation fails; highlight invalid fields.
- Optional: prevent exact duplicate registrations (name + email + course).

## Testing Checklist
- Add a new registration; verify it appears in the table.
- Reload the page; verify registration persists.
- Delete a registration; verify it is removed from UI and localStorage.
- Test validation: empty name, invalid email, no course selected.
- Verify empty-state message when no registrations exist.
- Check layout on narrow/mobile viewport.

## Next Step
If this plan looks good, I will implement the files in the order above and provide the complete source for `index.html`, `styles.css`, `script.js`, and `README.md`.