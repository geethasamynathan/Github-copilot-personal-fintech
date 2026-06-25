import { inventoryItems } from '../data/mockDatabase.js';

export async function syncInventory({ requestedBy = 'training-user' }) {
  const syncStartedAt = new Date().toISOString();

  const syncedLots = inventoryItems.map(item => {
    item.lastSyncedAt = syncStartedAt;
    return {
      lotId: item.lotId,
      itemNumber: item.itemNumber,
      status: 'synced',
      lastSyncedAt: item.lastSyncedAt
    };
  });

  return {
    requestedBy,
    syncStartedAt,
    totalLotsSynced: syncedLots.length,
    syncedLots
  };
}

export function getInventory() {
  return inventoryItems;
}
