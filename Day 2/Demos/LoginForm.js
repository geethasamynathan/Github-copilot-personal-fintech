//validate username and password before login
function validateLogin(username, password) {
  if (username === "admin" && password === "password") {
    return true;
  } else {
    return false;
  }
}

// Example usage
const username = prompt("Enter your username:");
const password = prompt("Enter your password:");

if (validateLogin(username, password)) {
  alert("Login successful!");
} else {
  alert("Invalid username or password.");
}
