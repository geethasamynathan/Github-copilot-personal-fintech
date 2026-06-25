import { Router } from 'express';
import { readSettings, saveSettings } from '../controllers/settingsController.js';

const router = Router();

router.get('/', readSettings);
router.put('/', saveSettings);

export default router;
