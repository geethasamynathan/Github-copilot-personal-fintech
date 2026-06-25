import { userSettings } from '../data/mockDatabase.js';

export function getSettings() {
  return { ...userSettings };
}

export function updateSettings(nextSettings) {
  if (nextSettings.pricingRegion) {
    userSettings.pricingRegion = nextSettings.pricingRegion;
  }

  if (nextSettings.pricingBasis) {
    userSettings.pricingBasis = nextSettings.pricingBasis;
  }

  return getSettings();
}
