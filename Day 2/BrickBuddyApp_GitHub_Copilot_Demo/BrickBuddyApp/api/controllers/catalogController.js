import { getCatalogItems, getItemDetails } from '../services/catalogService.js';
import { ok } from '../utils/response.js';

export function listCatalog(req, res, next) {
  try {
    res.json(ok(getCatalogItems(), 'Catalog loaded'));
  } catch (error) {
    next(error);
  }
}

export function itemDetails(req, res, next) {
  try {
    const details = getItemDetails({
      itemNumber: req.query.itemNumber,
      itemType: req.query.itemType || 'PART',
      colorId: req.query.colorId,
      condition: req.query.condition || 'used',
      region: req.query.region,
      guideType: req.query.guideType
    });

    res.json(ok(details, 'Item details loaded'));
  } catch (error) {
    next(error);
  }
}
