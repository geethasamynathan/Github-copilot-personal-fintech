# Product Registration - Test Checklist

## Test Categories

### 1. Form Validation Tests

#### Required Field Validation
- [ ] Test submitting form with empty product name
  - Expected: Error message displayed
  - Status: ___________
  
- [ ] Test submitting form with empty model number
  - Expected: Error message displayed
  - Status: ___________
  
- [ ] Test submitting form with empty customer name
  - Expected: Error message displayed
  - Status: ___________
  
- [ ] Test submitting form with empty email
  - Expected: Error message displayed
  - Status: ___________
  
- [ ] Test submitting form with empty phone number
  - Expected: Error message displayed
  - Status: ___________
  
- [ ] Test submitting form with empty purchase date
  - Expected: Error message displayed
  - Status: ___________

#### Email Validation
- [ ] Test valid email format (user@example.com)
  - Expected: No error message
  - Status: ___________
  
- [ ] Test invalid email (missing @)
  - Expected: Error message displayed
  - Status: ___________
  
- [ ] Test invalid email (missing domain)
  - Expected: Error message displayed
  - Status: ___________
  
- [ ] Test invalid email (extra spaces)
  - Expected: Error message or trimmed
  - Status: ___________

#### Phone Number Validation
- [ ] Test valid 10-digit phone number
  - Expected: Accepted
  - Status: ___________
  
- [ ] Test phone number with formatting (+1-555-123-4567)
  - Expected: Accepted or formatted
  - Status: ___________
  
- [ ] Test phone number with less than 10 digits
  - Expected: Error message displayed
  - Status: ___________
  
- [ ] Test phone number with invalid characters
  - Expected: Error message displayed
  - Status: ___________

#### Date Validation
- [ ] Test future date selection
  - Expected: Error message (cannot register future product)
  - Status: ___________
  
- [ ] Test valid past date
  - Expected: Accepted
  - Status: ___________
  
- [ ] Test date older than 20 years
  - Expected: Warning or accepted (based on requirements)
  - Status: ___________

### 2. Form Submission Tests

- [ ] Test successful form submission with all valid data
  - Expected: Success message shown, form data saved
  - Status: ___________
  
- [ ] Test that success message appears
  - Expected: Clear success message displayed
  - Status: ___________
  
- [ ] Test that form data persists after refresh
  - Expected: Data still visible in form or storage
  - Status: ___________
  
- [ ] Test form reset button
  - Expected: All fields cleared
  - Status: ___________
  
- [ ] Test multiple submissions
  - Expected: Each submission saved separately
  - Status: ___________

### 3. UI/UX Tests

#### Error Message Display
- [ ] Error messages are clearly visible
  - Status: ___________
  
- [ ] Error messages are red/clearly marked as errors
  - Status: ___________
  
- [ ] Invalid fields are highlighted
  - Status: ___________
  
- [ ] Error messages disappear when user corrects input
  - Status: ___________

#### Form Interaction
- [ ] Tab through form fields in logical order
  - Expected: Tab order is logical and accessible
  - Status: ___________
  
- [ ] Click on labels focuses corresponding input
  - Expected: Input field receives focus
  - Status: ___________
  
- [ ] Dropdown selections work correctly
  - Status: ___________
  
- [ ] Form fields have proper focus states
  - Status: ___________

#### Visual Design
- [ ] Form appears centered and properly aligned
  - Status: ___________
  
- [ ] Spacing between form elements is consistent
  - Status: ___________
  
- [ ] Colors are readable with proper contrast
  - Status: ___________
  
- [ ] Buttons are clearly clickable
  - Status: ___________

### 4. Responsive Design Tests

#### Mobile (320px - 480px)
- [ ] Form is fully visible without horizontal scroll
  - Status: ___________
  
- [ ] Form fields stack vertically
  - Status: ___________
  
- [ ] Buttons are easily tappable (min 44px height)
  - Status: ___________
  
- [ ] Text is readable without zooming
  - Status: ___________

#### Tablet (481px - 1024px)
- [ ] Form layout adapts appropriately
  - Status: ___________
  
- [ ] Form is readable and usable
  - Status: ___________

#### Desktop (1025px+)
- [ ] Form displays in optimal width
  - Status: ___________
  
- [ ] Multi-column layout works if implemented
  - Status: ___________

### 5. Browser Compatibility Tests

#### Chrome
- [ ] Form loads without errors
  - Status: ___________
  
- [ ] All validation works
  - Status: ___________
  
- [ ] Styling looks correct
  - Status: ___________

#### Firefox
- [ ] Form loads without errors
  - Status: ___________
  
- [ ] All validation works
  - Status: ___________
  
- [ ] Styling looks correct
  - Status: ___________

#### Safari
- [ ] Form loads without errors
  - Status: ___________
  
- [ ] All validation works
  - Status: ___________
  
- [ ] Styling looks correct
  - Status: ___________

#### Edge
- [ ] Form loads without errors
  - Status: ___________
  
- [ ] All validation works
  - Status: ___________
  
- [ ] Styling looks correct
  - Status: ___________

### 6. Data Storage Tests

- [ ] Data is saved to LocalStorage after submission
  - Status: ___________
  
- [ ] Data persists after page refresh
  - Status: ___________
  
- [ ] Multiple registrations are stored separately
  - Status: ___________
  
- [ ] Clear data button works correctly
  - Status: ___________
  
- [ ] No sensitive data is exposed in console
  - Status: ___________

### 7. Accessibility Tests

- [ ] Page has proper heading hierarchy
  - Status: ___________
  
- [ ] Form labels are associated with inputs
  - Status: ___________
  
- [ ] Keyboard navigation works (Tab key)
  - Status: ___________
  
- [ ] Form works with screen readers
  - Status: ___________
  
- [ ] Color contrast meets WCAG standards
  - Status: ___________

### 8. Performance Tests

- [ ] Page loads in under 2 seconds
  - Status: ___________
  
- [ ] Form validation is instant (no lag)
  - Status: ___________
  
- [ ] No console errors or warnings
  - Status: ___________
  
- [ ] Memory usage is reasonable
  - Status: ___________

## Test Results Summary

### Total Tests: _____ / 
### Passed: _____ 
### Failed: _____ 
### Blocked: _____ 

## Issues Found
1. ___________________________
2. ___________________________
3. ___________________________

## Sign-off
- Tested By: _________________
- Date: _________________
- Status: ☐ PASS  ☐ FAIL  ☐ NEEDS REVISION
