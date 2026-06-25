import { inventoryItems, colors } from '../data/mockDatabase.js';
import { getPriceGuide } from './pricingService.js';

export function getCatalogItems({ debug = false } = {}) {
  if (debug) {
    try {
      console.debug(`getCatalogItems called - items=${inventoryItems.length}, colors=${colors.length}, ts=${new Date().toISOString()}`);
    } catch (e) {
      // ignore logging errors
    }
  }

  return inventoryItems.map(item => ({
    ...item,
    availableColors: colors
  }));
}

export function getItemDetails({ itemNumber, itemType = 'PART', colorId, condition = 'used', region, guideType }) {
  const item = inventoryItems.find(
    product => product.itemNumber === String(itemNumber) && Number(product.colorId) === Number(colorId)
  );

  const priceGuide = getPriceGuide({ itemNumber, itemType, colorId, condition, region, guideType });

  return {
    item: item || {
      itemNumber,
      itemName: 'Unknown item',
      colorId,
      condition
    },
    priceGuide
  };
}
