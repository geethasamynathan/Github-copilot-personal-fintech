const STORAGE_KEY = "studentRegistrations";

function validateRegistration(registration) {
  if (!registration || typeof registration !== "object") {
    throw new Error("registration must be an object");
  }

  const missing = [];
  if (!registration.name || !registration.name.toString().trim())
    missing.push("name");
  if (!registration.email || !registration.email.toString().trim())
    missing.push("email");
  if (!registration.course || !registration.course.toString().trim())
    missing.push("course");

  if (missing.length) {
    throw new Error("Missing required fields: " + missing.join(", "));
  }

  return true;
}

export function getRegistrations() {
  const raw = localStorage.getItem(STORAGE_KEY);
  if (!raw) return [];

  try {
    const data = JSON.parse(raw);
    return Array.isArray(data) ? data : [];
  } catch (e) {
    return [];
  }
}

export function saveRegistrations(registrations) {
  if (!Array.isArray(registrations)) {
    throw new Error("registrations must be an array");
  }

  localStorage.setItem(STORAGE_KEY, JSON.stringify(registrations));
}

export function addRegistration(registration) {
  validateRegistration(registration);

  const existing = getRegistrations();
  const updated = [...existing, registration];
  saveRegistrations(updated);
  return updated;
}

export function deleteRegistration(registrationId) {
  const existing = getRegistrations();
  const updated = existing.filter((r) => r.id !== registrationId);
  saveRegistrations(updated);
  return updated;
}
