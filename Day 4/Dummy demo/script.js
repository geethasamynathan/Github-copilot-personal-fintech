/* ============================================
   PRODUCT REGISTRATION FORM - JAVASCRIPT
   ============================================ */

// ============================================
// VARIABLES & DOM ELEMENTS
// ============================================

const form = document.getElementById("registrationForm");
const errorMessage = document.getElementById("errorMessage");
const successMessage = document.getElementById("successMessage");
const productsList = document.getElementById("productsList");

// Form field elements
const formFields = {
  productName: document.getElementById("productName"),
  modelNumber: document.getElementById("modelNumber"),
  purchaseDate: document.getElementById("purchaseDate"),
  category: document.getElementById("category"),
  warranty: document.getElementById("warranty"),
  fullName: document.getElementById("fullName"),
  email: document.getElementById("email"),
  phone: document.getElementById("phone"),
  country: document.getElementById("country"),
  postalCode: document.getElementById("postalCode"),
};

// Storage key for LocalStorage
const STORAGE_KEY = "productRegistrations";

// ============================================
// VALIDATION FUNCTIONS
// ============================================

/**
 * Validate required field
 * @param {string} value - Field value
 * @returns {boolean} - True if valid
 */
function validateRequired(value) {
  return value.trim() !== "";
}

/**
 * Validate email format
 * @param {string} email - Email address
 * @returns {boolean} - True if valid
 */
function validateEmail(email) {
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return emailRegex.test(email.trim());
}

/**
 * Validate phone number
 * @param {string} phone - Phone number
 * @returns {boolean} - True if valid (at least 10 digits)
 */
function validatePhone(phone) {
  // Remove common formatting characters
  const digitsOnly = phone.replace(/\D/g, "");
  return digitsOnly.length >= 10;
}

/**
 * Validate purchase date (cannot be in future)
 * @param {string} dateString - Date string from input
 * @returns {boolean} - True if valid
 */
function validatePurchaseDate(dateString) {
  if (!validateRequired(dateString)) {
    return false;
  }

  const purchaseDate = new Date(dateString);
  const today = new Date();

  // Set time to midnight for accurate date comparison
  purchaseDate.setHours(0, 0, 0, 0);
  today.setHours(0, 0, 0, 0);

  return purchaseDate <= today;
}

/**
 * Validate entire form
 * @returns {object} - Object with validation results and error messages
 */
function validateForm() {
  const errors = {};
  let isValid = true;

  // Product Name validation
  if (!validateRequired(formFields.productName.value)) {
    errors.productName = "Product name is required";
    isValid = false;
  }

  // Model Number validation
  if (!validateRequired(formFields.modelNumber.value)) {
    errors.modelNumber = "Model/Serial number is required";
    isValid = false;
  }

  // Purchase Date validation
  if (!validatePurchaseDate(formFields.purchaseDate.value)) {
    errors.purchaseDate = "Please select a valid past date";
    isValid = false;
  }

  // Category validation
  if (!validateRequired(formFields.category.value)) {
    errors.category = "Please select a product category";
    isValid = false;
  }

  // Warranty validation
  if (!validateRequired(formFields.warranty.value)) {
    errors.warranty = "Please select a warranty period";
    isValid = false;
  }

  // Full Name validation
  if (!validateRequired(formFields.fullName.value)) {
    errors.fullName = "Full name is required";
    isValid = false;
  }

  // Email validation
  if (!validateRequired(formFields.email.value)) {
    errors.email = "Email address is required";
    isValid = false;
  } else if (!validateEmail(formFields.email.value)) {
    errors.email = "Please enter a valid email address";
    isValid = false;
  }

  // Phone validation
  if (!validateRequired(formFields.phone.value)) {
    errors.phone = "Phone number is required";
    isValid = false;
  } else if (!validatePhone(formFields.phone.value)) {
    errors.phone = "Please enter a valid phone number (at least 10 digits)";
    isValid = false;
  }

  // Country validation
  if (!validateRequired(formFields.country.value)) {
    errors.country = "Please select a country/region";
    isValid = false;
  }

  return { isValid, errors };
}

// ============================================
// MESSAGE DISPLAY FUNCTIONS
// ============================================

/**
 * Show error message
 * @param {string} message - Error message to display
 */
function showError(message) {
  errorMessage.textContent = message;
  errorMessage.style.display = "block";
  successMessage.style.display = "none";

  // Scroll to top to show message
  window.scrollTo({ top: 0, behavior: "smooth" });
}

/**
 * Show success message
 * @param {string} message - Success message to display
 */
function showSuccess(message) {
  successMessage.textContent = message;
  successMessage.style.display = "block";
  errorMessage.style.display = "none";

  // Scroll to top to show message
  window.scrollTo({ top: 0, behavior: "smooth" });
}

/**
 * Clear all messages
 */
function clearMessages() {
  errorMessage.style.display = "none";
  successMessage.style.display = "none";
}

// ============================================
// ERROR HIGHLIGHTING FUNCTIONS
// ============================================

/**
 * Highlight field as invalid
 * @param {HTMLElement} field - Form field element
 */
function highlightError(field) {
  field.classList.add("input--error");
}

/**
 * Remove error highlight from field
 * @param {HTMLElement} field - Form field element
 */
function clearErrorHighlight(field) {
  field.classList.remove("input--error");
}

/**
 * Display inline error messages
 * @param {object} errors - Errors object from validation
 */
function displayFieldErrors(errors) {
  // Clear all previous error highlights
  Object.values(formFields).forEach((field) => {
    clearErrorHighlight(field);
  });

  // Display new errors
  Object.keys(errors).forEach((fieldName) => {
    const errorElement = document.getElementById(fieldName + "Error");
    const field = formFields[fieldName];

    if (errorElement) {
      errorElement.textContent = errors[fieldName];
      highlightError(field);
    }
  });
}

/**
 * Clear field error display
 * @param {string} fieldName - Name of the field
 */
function clearFieldError(fieldName) {
  const errorElement = document.getElementById(fieldName + "Error");
  const field = formFields[fieldName];

  if (errorElement) {
    errorElement.textContent = "";
  }

  if (field) {
    clearErrorHighlight(field);
  }
}

// ============================================
// STORAGE FUNCTIONS
// ============================================

/**
 * Get all registrations from LocalStorage
 * @returns {array} - Array of registered products
 */
function getRegistrations() {
  const data = localStorage.getItem(STORAGE_KEY);
  return data ? JSON.parse(data) : [];
}

/**
 * Save registration to LocalStorage
 * @param {object} registration - Registration data to save
 */
function saveRegistration(registration) {
  const registrations = getRegistrations();
  registrations.push({
    ...registration,
    id: Date.now(), // Simple unique ID
    registeredAt: new Date().toISOString(),
  });
  localStorage.setItem(STORAGE_KEY, JSON.stringify(registrations));
}

/**
 * Delete a single registration by ID
 * @param {number} productId - ID of the product to delete
 */
function deleteProduct(productId) {
  const registrations = getRegistrations();
  const filteredRegistrations = registrations.filter(
    (product) => product.id !== productId,
  );
  localStorage.setItem(STORAGE_KEY, JSON.stringify(filteredRegistrations));
}

// ============================================
// FORM DISPLAY FUNCTIONS
// ============================================

/**
 * Get form data as object
 * @returns {object} - Form data
 */
function getFormData() {
  return {
    productName: formFields.productName.value.trim(),
    modelNumber: formFields.modelNumber.value.trim(),
    purchaseDate: formFields.purchaseDate.value,
    category: formFields.category.value,
    warranty: formFields.warranty.value,
    fullName: formFields.fullName.value.trim(),
    email: formFields.email.value.trim(),
    phone: formFields.phone.value.trim(),
    country: formFields.country.value,
    postalCode: formFields.postalCode.value.trim(),
  };
}

/**
 * Display registered products
 */
function displayRegisteredProducts() {
  const registrations = getRegistrations();

  if (registrations.length === 0) {
    productsList.innerHTML =
      '<p class="empty-message">No products registered yet. Fill out the form above to register your first product.</p>';
    return;
  }

  // Build HTML for products list
  let productsHTML = "";
  registrations.forEach((product) => {
    const registeredDate = new Date(product.registeredAt).toLocaleDateString();

    productsHTML += `
            <div class="product-item" data-product-id="${product.id}">
                <div class="product-header">
                    <h3>${escapeHtml(product.productName)}</h3>
                    <button type="button" class="btn-delete" title="Delete this product">×</button>
                </div>
                <div class="product-info">
                    <div>
                        <strong>Model:</strong>
                        <span>${escapeHtml(product.modelNumber)}</span>
                    </div>
                    <div>
                        <strong>Category:</strong>
                        <span>${escapeHtml(product.category)}</span>
                    </div>
                    <div>
                        <strong>Purchase Date:</strong>
                        <span>${new Date(product.purchaseDate).toLocaleDateString()}</span>
                    </div>
                    <div>
                        <strong>Warranty:</strong>
                        <span>${escapeHtml(product.warranty)}</span>
                    </div>
                    <div>
                        <strong>Customer:</strong>
                        <span>${escapeHtml(product.fullName)}</span>
                    </div>
                    <div>
                        <strong>Email:</strong>
                        <span>${escapeHtml(product.email)}</span>
                    </div>
                    <div>
                        <strong>Phone:</strong>
                        <span>${escapeHtml(product.phone)}</span>
                    </div>
                    <div>
                        <strong>Country:</strong>
                        <span>${escapeHtml(product.country)}</span>
                    </div>
                    <div>
                        <strong>Registered:</strong>
                        <span>${registeredDate}</span>
                    </div>
                </div>
            </div>
        `;
  });

  productsList.innerHTML = productsHTML;
  attachDeleteListeners();
}

/**
 * Escape HTML special characters (security)
 * @param {string} text - Text to escape
 * @returns {string} - Escaped text
 */
function escapeHtml(text) {
  const div = document.createElement("div");
  div.textContent = text;
  return div.innerHTML;
}

/**
 * Attach delete event listeners to delete buttons
 */
function attachDeleteListeners() {
  const deleteButtons = document.querySelectorAll(".btn-delete");
  deleteButtons.forEach((button) => {
    button.addEventListener("click", function (e) {
      e.preventDefault();
      const productItem = button.closest(".product-item");
      const productId = parseInt(productItem.getAttribute("data-product-id"));
      const productName = productItem.querySelector("h3").textContent;

      if (
        confirm(
          `Are you sure you want to delete "${productName}"? This action cannot be undone.`,
        )
      ) {
        deleteProduct(productId);
        displayRegisteredProducts();
        showSuccess(`"${productName}" has been deleted successfully.`);
      }
    });
  });
}

// ============================================
// EVENT LISTENERS
// ============================================

/**
 * Form submission handler
 */
form.addEventListener("submit", function (event) {
  event.preventDefault();

  // Clear previous messages
  clearMessages();

  // Validate form
  const validation = validateForm();

  if (!validation.isValid) {
    // Display field errors
    displayFieldErrors(validation.errors);

    // Show general error message
    showError("Please correct the errors above and try again.");
    return;
  }

  // Get form data
  const formData = getFormData();

  // Save registration
  saveRegistration(formData);

  // Show success message
  showSuccess(
    `✓ Successfully registered ${formData.productName}! Your warranty period is ${formData.warranty}.`,
  );

  // Clear error highlights
  Object.values(formFields).forEach((field) => {
    clearErrorHighlight(field);
  });

  // Reset form
  form.reset();

  // Update displayed products
  displayRegisteredProducts();
});

/**
 * Form reset handler
 */
form.addEventListener("reset", function () {
  clearMessages();

  // Clear all error displays
  Object.keys(formFields).forEach((fieldName) => {
    clearFieldError(fieldName);
  });
});

/**
 * Real-time field validation
 */
Object.entries(formFields).forEach(([fieldName, field]) => {
  field.addEventListener("blur", function () {
    const validation = validateForm();

    if (validation.errors[fieldName]) {
      document.getElementById(fieldName + "Error").textContent =
        validation.errors[fieldName];
      highlightError(field);
    } else {
      clearFieldError(fieldName);
    }
  });

  // Clear error on input
  field.addEventListener("input", function () {
    clearFieldError(fieldName);
  });
});

// ============================================
// INITIALIZATION
// ============================================

// Display registered products on page load
document.addEventListener("DOMContentLoaded", function () {
  displayRegisteredProducts();
});
