import { Router } from 'express';
import { itemDetails, listCatalog } from '../controllers/catalogController.js';

const router = Router();

router.get('/', listCatalog);
router.get('/items/details', itemDetails);

export default router;
