export const inventoryItems = [
  {
    lotId: 1001,
    itemNumber: '3001',
    itemName: 'Brick 2 x 4',
    colorId: 11,
    colorName: 'Black',
    condition: 'used',
    quantity: 250,
    warehouse: 'Chennai Warehouse',
    lastSyncedAt: null
  },
  {
    lotId: 1002,
    itemNumber: '3001',
    itemName: 'Brick 2 x 4',
    colorId: 5,
    colorName: 'Red',
    condition: 'new',
    quantity: 90,
    warehouse: 'Bangalore Warehouse',
    lastSyncedAt: null
  },
  {
    lotId: 1003,
    itemNumber: '3023',
    itemName: 'Plate 1 x 2',
    colorId: 11,
    colorName: 'Black',
    condition: 'used',
    quantity: 480,
    warehouse: 'Coimbatore Retail Store',
    lastSyncedAt: null
  }
];

export const priceGuideRows = [
  {
    itemNumber: '3001',
    itemType: 'PART',
    colorId: 11,
    condition: 'used',
    usedAvgSoldPriceNorthAmerica: 0.10,
    usedAvgSoldPriceGlobal: 0.07,
    usedCurrentInventoryNorthAmerica: 0.12,
    usedCurrentInventoryGlobal: 0.08
  },
  {
    itemNumber: '3001',
    itemType: 'PART',
    colorId: 5,
    condition: 'new',
    usedAvgSoldPriceNorthAmerica: 0.18,
    usedAvgSoldPriceGlobal: 0.16,
    usedCurrentInventoryNorthAmerica: 0.20,
    usedCurrentInventoryGlobal: 0.17
  },
  {
    itemNumber: '3023',
    itemType: 'PART',
    colorId: 11,
    condition: 'used',
    usedAvgSoldPriceNorthAmerica: 0.04,
    usedAvgSoldPriceGlobal: 0.03,
    usedCurrentInventoryNorthAmerica: 0.05,
    usedCurrentInventoryGlobal: 0.04
  }
];

export const colors = [
  { colorId: 11, name: 'Black' },
  { colorId: 5, name: 'Red' },
  { colorId: 1, name: 'White' },
  { colorId: 7, name: 'Blue' }
];

export const userSettings = {
  pricingRegion: 'global',
  pricingBasis: 'sold'
};
