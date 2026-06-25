import { useEffect, useState } from 'react';
import { apiClient } from '../services/apiClient.js';

export default function SettingsPage() {
  const [settings, setSettings] = useState({ pricingRegion: 'global', pricingBasis: 'sold' });
  const [message, setMessage] = useState('');

  async function loadSettings() {
    const data = await apiClient.getSettings();
    setSettings(data);
  }

  async function saveSettings(nextSettings) {
    const updated = await apiClient.updateSettings(nextSettings);
    setSettings(updated);
    setMessage('Settings updated. Now test catalog pricing again.');
  }

  useEffect(() => {
    loadSettings();
  }, []);

  return (
    <main>
      <section className="hero-card compact">
        <p className="eyebrow">Bug Context</p>
        <h2>Pricing Settings</h2>
        <p>
          Change the pricing region between <strong>global</strong> and <strong>north_america</strong> to reproduce the pricing investigation flow.
        </p>
      </section>

      <section className="card form-card">
        <label>
          Pricing Region
          <select
            value={settings.pricingRegion}
            onChange={event => saveSettings({ pricingRegion: event.target.value })}
          >
            <option value="global">Global</option>
            <option value="north_america">North America</option>
          </select>
        </label>

        <label>
          Pricing Basis
          <select
            value={settings.pricingBasis}
            onChange={event => saveSettings({ pricingBasis: event.target.value })}
          >
            <option value="sold">Last Six Month Sales</option>
            <option value="current">Current Inventory</option>
          </select>
        </label>

        {message && <p className="success-text">{message}</p>}
      </section>
    </main>
  );
}
