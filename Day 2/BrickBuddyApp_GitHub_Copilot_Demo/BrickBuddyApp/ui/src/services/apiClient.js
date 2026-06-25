const API_BASE_URL = 'http://localhost:4000/api';

async function request(path, options = {}) {
  const response = await fetch(`${API_BASE_URL}${path}`, {
    headers: {
      'Content-Type': 'application/json',
      ...(options.headers || {})
    },
    ...options
  });

  const payload = await response.json();

  if (!response.ok) {
    throw new Error(payload.message || 'API request failed');
  }

  return payload.data;
}

export const apiClient = {
  getHealth: () => request('/health'),
  getInventory: () => request('/inventory'),
  syncInventory: () => request('/inventory/sync', { method: 'POST', body: JSON.stringify({ requestedBy: 'demo-user' }) }),
  getCatalog: () => request('/catalog'),
  getItemDetails: params => request(`/catalog/items/details?${new URLSearchParams(params).toString()}`),
  getSettings: () => request('/settings'),
  updateSettings: settings => request('/settings', { method: 'PUT', body: JSON.stringify(settings) })
};
