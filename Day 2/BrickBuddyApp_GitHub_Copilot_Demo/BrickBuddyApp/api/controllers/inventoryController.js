import { getInventory, syncInventory } from '../services/inventorySyncService.js';
import { ok } from '../utils/response.js';

export async function listInventory(req, res, next) {
  try {
    res.json(ok(getInventory(), 'Inventory loaded'));
  } catch (error) {
    next(error);
  }
}

export async function syncUserInventory(req, res, next) {
  try {
    const result = await syncInventory({ requestedBy: req.body.requestedBy || 'training-user' });
    res.json(ok(result, 'Inventory sync completed'));
  } catch (error) {
    next(error);
  }
}
