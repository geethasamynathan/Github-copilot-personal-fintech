# GitHub Copilot Instructions for BrickBuddyApp

You are assisting with BrickBuddyApp, a training project used to teach developers how to navigate and understand codebases using GitHub Copilot.

## Project Overview

BrickBuddyApp is an inventory management demo for toy building pieces. It includes a React frontend and Express backend.

## Folder Guide

- `ui/src/pages` contains main React pages.
- `ui/src/components` contains reusable UI components.
- `ui/src/services/apiClient.js` contains frontend API calls.
- `api/routes` contains Express routes.
- `api/controllers` contains request handlers.
- `api/services` contains business logic.
- `api/data/mockDatabase.js` contains mock inventory, pricing, colors, and settings.
- `docs` contains training documentation and journey maps.

## Important Workflows

### Inventory Sync

Start from `ui/src/pages/UserInventory.jsx`, especially the `syncInventory()` function. It calls `apiClient.syncInventory()`, which sends `POST /api/inventory/sync`. The request flows through `inventoryRoutes.js`, `inventoryController.js`, and `inventorySyncService.js`.

### Catalog Pricing

Start from `ui/src/pages/Catalog.jsx`, especially `handleColorClick()`. It calls `apiClient.getItemDetails()`, which sends `GET /api/catalog/items/details`. The backend uses `catalogController.js`, `catalogService.js`, and `pricingService.js`.

## Response Style

When explaining this project:

- Start with the high-level architecture.
- Mention exact files and functions.
- Trace code paths step by step.
- Avoid guessing when the answer can be verified from the code.
- Recommend that learners inspect files manually after Copilot provides an answer.
