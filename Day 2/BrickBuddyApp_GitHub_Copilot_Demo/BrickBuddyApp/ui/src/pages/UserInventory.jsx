import { useEffect, useState } from 'react';
import { apiClient } from '../services/apiClient.js';

export default function UserInventory() {
  const [inventory, setInventory] = useState([]);
  const [syncResult, setSyncResult] = useState(null);
  const [loading, setLoading] = useState(false);

  async function loadInventory() {
    const data = await apiClient.getInventory();
    setInventory(data);
  }

  async function syncInventory() {
    setLoading(true);
    try {
      const result = await apiClient.syncInventory();
      setSyncResult(result);
      await loadInventory();
    } finally {
      setLoading(false);
    }
  }

  useEffect(() => {
    loadInventory();
  }, []);

  return (
    <main>
      <section className="hero-card compact">
        <p className="eyebrow">Code Path Tracing Demo</p>
        <h2>User Inventory Sync</h2>
        <p>
          Ask Copilot to trace the button click from <strong>syncInventory()</strong> in this React page to the Express API endpoint.
        </p>
        <button className="primary-button" onClick={syncInventory} disabled={loading}>
          {loading ? 'Syncing...' : 'Sync Inventory'}
        </button>
      </section>

      {syncResult && (
        <section className="card success-card">
          <h3>Sync Completed</h3>
          <p>Total lots synced: {syncResult.totalLotsSynced}</p>
          <p>Sync started at: {syncResult.syncStartedAt}</p>
        </section>
      )}

      <section className="card">
        <h3>Inventory Lots</h3>
        <table>
          <thead>
            <tr>
              <th>Lot</th>
              <th>Item</th>
              <th>Color</th>
              <th>Quantity</th>
              <th>Warehouse</th>
              <th>Last Synced</th>
            </tr>
          </thead>
          <tbody>
            {inventory.map(item => (
              <tr key={item.lotId}>
                <td>{item.lotId}</td>
                <td>{item.itemName}</td>
                <td>{item.colorName}</td>
                <td>{item.quantity}</td>
                <td>{item.warehouse}</td>
                <td>{item.lastSyncedAt || 'Not synced yet'}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </section>
    </main>
  );
}
