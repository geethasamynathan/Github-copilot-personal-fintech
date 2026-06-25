import { getSettings, updateSettings } from '../services/settingsService.js';
import { ok } from '../utils/response.js';

export function readSettings(req, res, next) {
  try {
    res.json(ok(getSettings(), 'Settings loaded'));
  } catch (error) {
    next(error);
  }
}

export function saveSettings(req, res, next) {
  try {
    res.json(ok(updateSettings(req.body), 'Settings updated'));
  } catch (error) {
    next(error);
  }
}
