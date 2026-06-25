const registrationForm = document.getElementById("registration-form");
const nameInput = document.getElementById("student-name");
const emailInput = document.getElementById("student-email");
const courseSelect = document.getElementById("course-select");
const messageContainer = document.getElementById("message-container");
const registrationsBody = document.getElementById("registrations-body");
const STORAGE_KEY = "studentCourseRegistrations";

function getRegistrations() {
  const storedData = localStorage.getItem(STORAGE_KEY);
  return storedData ? JSON.parse(storedData) : [];
}

function saveRegistrations(registrations) {
  localStorage.setItem(STORAGE_KEY, JSON.stringify(registrations));
}

function showMessage(text, type) {
  messageContainer.innerHTML = "";
  const messageElement = document.createElement("div");
  messageElement.className = `message ${type}`;
  messageElement.textContent = text;
  messageContainer.appendChild(messageElement);
}

function clearMessage() {
  messageContainer.innerHTML = "";
}

function validateForm(name, email, course) {
  if (!name.trim()) {
    showMessage("Please enter the student name.", "error");
    return false;
  }

  if (!email.trim()) {
    showMessage("Please enter the email address.", "error");
    return false;
  }

  const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  if (!emailPattern.test(email.trim())) {
    showMessage("Please enter a valid email address.", "error");
    return false;
  }

  if (!course) {
    showMessage("Please select a course.", "error");
    return false;
  }

  clearMessage();
  return true;
}

function clearForm() {
  nameInput.value = "";
  emailInput.value = "";
  courseSelect.value = "";
}

function renderRegistrations() {
  const registrations = getRegistrations();

  if (registrations.length === 0) {
    registrationsBody.innerHTML = `
      <tr>
        <td colspan="4" class="empty-state">No registrations yet.</td>
      </tr>`;
    return;
  }

  registrationsBody.innerHTML = registrations
    .map(
      (registration) => `
      <tr>
        <td>${registration.name}</td>
        <td>${registration.email}</td>
        <td>${registration.course}</td>
        <td>
          <button class="delete-button" data-id="${registration.id}">Delete</button>
        </td>
      </tr>`,
    )
    .join("");
}

function addRegistration(event) {
  event.preventDefault();

  const name = nameInput.value;
  const email = emailInput.value;
  const course = courseSelect.value;

  if (!validateForm(name, email, course)) {
    return;
  }

  const registrations = getRegistrations();
  const newRegistration = {
    id: Date.now().toString(),
    name: name.trim(),
    email: email.trim(),
    course,
  };

  registrations.push(newRegistration);
  saveRegistrations(registrations);
  renderRegistrations();
  clearForm();
  showMessage("Registration saved successfully.", "success");
}

function deleteRegistration(id) {
  const registrations = getRegistrations();
  const updated = registrations.filter(
    (registration) => registration.id !== id,
  );
  saveRegistrations(updated);
  renderRegistrations();
  showMessage("Registration deleted.", "success");
}

function handleTableClick(event) {
  const target = event.target;
  if (target.matches(".delete-button")) {
    const registrationId = target.getAttribute("data-id");
    deleteRegistration(registrationId);
  }
}

registrationForm.addEventListener("submit", addRegistration);
registrationsBody.addEventListener("click", handleTableClick);
document.addEventListener("DOMContentLoaded", renderRegistrations);
