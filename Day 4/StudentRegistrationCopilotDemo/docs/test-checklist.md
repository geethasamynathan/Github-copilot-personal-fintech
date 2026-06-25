# Manual Test Checklist

Follow this checklist to manually verify the Student Registration demo.

1. Add a registration
   - Fill `Student Name`, `Email`, select a `Course` and click `Register`.
   - Expected: success message shown and entry appears in the table.

2. Persistence
   - Reload the page in the browser.
   - Expected: previously saved registrations are still listed.

3. Delete entry
   - Click `Delete` next to a registration and confirm the prompt.
   - Expected: entry is removed from the table and localStorage.

4. Validation
   - Try to submit with empty name, invalid email, or no course selected.
   - Expected: error message displayed and form not saved.

5. Empty state
   - If no registrations exist, verify the `No registrations yet.` message is visible.

6. Responsiveness
   - Resize the window to a narrow/mobile width and verify layout remains usable.
