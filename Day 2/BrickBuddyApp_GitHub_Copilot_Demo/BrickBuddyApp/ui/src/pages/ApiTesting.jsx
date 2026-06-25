import { useState } from 'react';
import { apiClient } from '../services/apiClient.js';

export default function ApiTesting() {
  const [form, setForm] = useState({
    itemNumber: '3001',
    itemType: 'PART',
    colorId: '11',
    condition: 'used',
    region: 'global',
    guideType: 'sold'
  });
  const [response, setResponse] = useState(null);

  function updateField(event) {
    setForm({ ...form, [event.target.name]: event.target.value });
  }

  async function testEndpoint() {
    const result = await apiClient.getItemDetails(form);
    setResponse(result);
  }

  return (
    <main>
      <section className="hero-card compact">
        <p className="eyebrow">Internal Tool</p>
        <h2>API Testing</h2>
        <p>Use this page to simulate the internal API testing tool from the transcription script.</p>
      </section>

      <section className="card form-card">
        <h3>GET /api/catalog/items/details</h3>
        <div className="form-grid">
          {Object.entries(form).map(([key, value]) => (
            <label key={key}>
              {key}
              <input name={key} value={value} onChange={updateField} />
            </label>
          ))}
        </div>
        <button className="primary-button" onClick={testEndpoint}>Test Endpoint</button>
      </section>

      {response && (
        <section className="card">
          <h3>API Response</h3>
          <pre>{JSON.stringify(response, null, 2)}</pre>
        </section>
      )}
    </main>
  );
}
