import { priceGuideRows } from '../data/mockDatabase.js';
import { getSettings } from './settingsService.js';

export function getPriceGuide({ itemNumber, itemType = 'PART', colorId, condition = 'used', region, guideType }) {
  const row = priceGuideRows.find(
    item =>
      item.itemNumber === String(itemNumber) &&
      item.itemType === itemType &&
      Number(item.colorId) === Number(colorId) &&
      item.condition === condition
  );

  if (!row) {
    return null;
  }

  const settings = getSettings();
  const selectedRegion = region || settings.pricingRegion;
  const selectedGuideType = guideType || settings.pricingBasis;

  return mapPriceGuideToLot(row, selectedRegion, selectedGuideType);
}

export function mapPriceGuideToLot(row, region, guideType) {
  const normalizedRegion = region === 'north_america' ? 'NorthAmerica' : 'Global';
  const normalizedGuideType = guideType === 'current' ? 'CurrentInventory' : 'AvgSoldPrice';
  const key = `used${normalizedGuideType}${normalizedRegion}`;

  return {
    itemNumber: row.itemNumber,
    itemType: row.itemType,
    colorId: row.colorId,
    condition: row.condition,
    region,
    guideType,
    selectedPriceField: key,
    averagePrice: row[key],
    allPrices: {
      northAmericaSold: row.usedAvgSoldPriceNorthAmerica,
      globalSold: row.usedAvgSoldPriceGlobal,
      northAmericaCurrentInventory: row.usedCurrentInventoryNorthAmerica,
      globalCurrentInventory: row.usedCurrentInventoryGlobal
    }
  };
}
