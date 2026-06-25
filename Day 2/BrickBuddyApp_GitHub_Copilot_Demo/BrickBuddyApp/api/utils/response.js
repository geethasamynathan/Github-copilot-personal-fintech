export function ok(data, message = 'Success') {
  return { success: true, message, data };
}

export function fail(message, statusCode = 400) {
  const error = new Error(message);
  error.statusCode = statusCode;
  return error;
}
