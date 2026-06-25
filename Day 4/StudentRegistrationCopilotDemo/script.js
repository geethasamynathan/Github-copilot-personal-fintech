// Student Registration script
const STORAGE_KEY = "registrations";

// Simple email regex (not exhaustive)
const EMAIL_RE = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

// DOM elements
const form = document.getElementById("registration-form");
const nameInput = document.getElementById("student-name");
const emailInput = document.getElementById("student-email");
const courseSelect = document.getElementById("course-select");
const messages = document.getElementById("messages");
const tableBody = document.querySelector("#registrations-table tbody");
const emptyState = document.getElementById("empty-state");

function getRegistrations() {
  try {
    const raw = localStorage.getItem(STORAGE_KEY);
    return raw ? JSON.parse(raw) : [];
  } catch (e) {
    return [];
  }
}

function saveRegistrations(list) {
  localStorage.setItem(STORAGE_KEY, JSON.stringify(list));
}

function showMessage(type, text, timeout = 3000) {
  // type: 'success' | 'error'
  const el = document.createElement("div");
  el.className = `msg ${type}`;
  el.textContent = text;
  messages.innerHTML = "";
  messages.appendChild(el);
  if (timeout > 0) {
    setTimeout(() => {
      if (messages.contains(el)) messages.removeChild(el);
    }, timeout);
  }
}

function render() {
  const regs = getRegistrations();
  tableBody.innerHTML = "";
  if (regs.length === 0) {
    emptyState.style.display = "block";
  } else {
    emptyState.style.display = "none";
    regs.forEach((r) => {
      const tr = document.createElement("tr");
      tr.innerHTML = `
        <td>${escapeHtml(r.name)}</td>
        <td>${escapeHtml(r.email)}</td>
        <td>${escapeHtml(r.course)}</td>
        <td><button class="action-btn" data-id="${r.id}">Delete</button></td>
      `;
      tableBody.appendChild(tr);
    });
  }
}

function escapeHtml(s) {
  if (!s) return "";
  return String(s)
    .replace(/&/g, "&amp;")
    .replace(/</g, "&lt;")
    .replace(/>/g, "&gt;");
}

function validate(name, email, course) {
  const errors = [];
  if (!name || name.trim() === "") errors.push("Name is required");
  if (!email || !EMAIL_RE.test(email)) errors.push("Valid email is required");
  if (!course || course.trim() === "") errors.push("Course must be selected");
  return errors;
}

function handleSubmit(e) {
  e.preventDefault();
  const name = nameInput.value.trim();
  const email = emailInput.value.trim();
  const course = courseSelect.value;
  const errors = validate(name, email, course);
  if (errors.length) {
    showMessage("error", errors.join(". "));
    return;
  }

  const regs = getRegistrations();
  const id = Date.now().toString();
  regs.push({ id, name, email, course });
  saveRegistrations(regs);
  render();
  form.reset();
  showMessage("success", "Registration saved");
}

function handleDelete(id) {
  if (!confirm("Delete this registration?")) return;
  const regs = getRegistrations().filter((r) => r.id !== id);
  saveRegistrations(regs);
  render();
  showMessage("success", "Registration deleted");
}

// Event delegation for delete buttons
tableBody.addEventListener("click", (e) => {
  const btn = e.target.closest("button");
  if (!btn) return;
  const id = btn.getAttribute("data-id");
  if (id) handleDelete(id);
});

form.addEventListener("submit", handleSubmit);

// Initialize
document.addEventListener("DOMContentLoaded", () => {
  render();
});
