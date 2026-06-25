import { Router } from 'express';
import { listInventory, syncUserInventory } from '../controllers/inventoryController.js';

const router = Router();

router.get('/', listInventory);
router.post('/sync', syncUserInventory);

export default router;
