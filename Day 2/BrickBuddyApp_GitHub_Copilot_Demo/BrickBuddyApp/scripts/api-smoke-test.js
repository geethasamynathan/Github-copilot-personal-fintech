const endpoints = [
  'http://localhost:4000/api/health',
  'http://localhost:4000/api/inventory',
  'http://localhost:4000/api/catalog',
  'http://localhost:4000/api/settings'
];

for (const endpoint of endpoints) {
  try {
    const response = await fetch(endpoint);
    const payload = await response.json();
    console.log(endpoint, payload.success ? 'OK' : 'FAILED');
  } catch (error) {
    console.error(endpoint, error.message);
  }
}
