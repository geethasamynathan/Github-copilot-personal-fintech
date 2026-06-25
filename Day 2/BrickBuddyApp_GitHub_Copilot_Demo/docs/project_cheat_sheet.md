# BrickBuddyApp Project Cheat Sheet

## Purpose

BrickBuddyApp is a small training/demo application designed to help learners understand a React + Express codebase and practice codebase navigation with GitHub Copilot.

## Architecture Overview

- `BrickBuddyApp/ui/src`
  - `App.jsx`: root React component and page navigation state.
  - `main.jsx`: app bootstrap and React DOM render entry point.
  - `components/`: shared UI pieces like `Header.jsx` and `InfoCard.jsx`.
  - `pages/`: page-level views such as `Dashboard.jsx`, `UserInventory.jsx`, `Catalog.jsx`, `ApiTesting.jsx`, and `SettingsPage.jsx`.
  - `services/apiClient.js`: centralized frontend API helper for calls to the backend.
  - `styles/app.css`: application CSS.

- `BrickBuddyApp/api`
  - `server.js`: Express app setup, middleware, and route mounting.
  - `routes/`: route definitions for `catalog`, `inventory`, and `settings`.
  - `controllers/`: request handlers that translate HTTP requests into service calls.
  - `services/`: backend business logic and orchestration.
  - `data/mockDatabase.js`: in-memory data store used by services.
  - `utils/response.js`: helper functions for standardized API success/error responses.

## Key Components & Patterns

- React component composition
  - `App.jsx` renders `Header` and the active page from the `pages` map.
  - Pages are isolated into self-contained views under `ui/src/pages`.

- State and side effects
  - `useState` for local component state (`activePage`, `inventory`, `catalog`, `loading`, etc.).
  - `useEffect` for loading data on mount (`loadInventory()`, `loadCatalog()`).

- Prop-driven navigation
  - `Header.jsx` receives `activePage` and `onNavigate` props.
  - Clicking a header button updates the active page in `App.jsx`.

- Presentational/reusable UI components
  - `InfoCard.jsx` is a reusable card component used by the dashboard.
  - `Header.jsx` is the main navigation bar shared across the app.

- Separation of concerns
  - Frontend pages call `apiClient` instead of using `fetch` directly.
  - Backend uses `routes -> controllers -> services -> data` flow.

## APIs & Data Flow

- Frontend communicates with the backend through `apiClient.js`.
  - Base URL: `http://localhost:4000/api`
  - Endpoints:
    - `GET /api/health`
    - `GET /api/inventory`
    - `POST /api/inventory/sync`
    - `GET /api/catalog`
    - `GET /api/catalog/items/details` with query params
    - `GET /api/settings`
    - `PUT /api/settings`

- Typical flow from UI to data:
  1. React page calls `apiClient.<method>()`.
  2. `apiClient.request()` performs `fetch()` and standardizes JSON parsing and error handling.
  3. Express route receives the request and forwards it to a controller.
  4. Controller calls a service function.
  5. Service reads or updates `mockDatabase` and returns structured data.
  6. Controller sends the API response back to the UI.

- Example flow: Inventory sync
  - `UserInventory.jsx` calls `apiClient.syncInventory()`.
  - `api/inventoryRoutes.js` routes the request to `inventoryController.syncUserInventory()`.
  - Controller uses `inventorySyncService.syncInventory()`.
  - Service updates the inventory list and returns a summary.
  - UI refreshes inventory via `loadInventory()`.

- Example flow: Catalog pricing
  - `Catalog.jsx` calls `apiClient.getItemDetails()` with item query params.
  - `catalogController.getItemDetails()` calls `catalogService.getItemDetails()`.
  - `pricingService.getPriceGuide()` resolves pricing logic and returns the selected price guide.

## Reusable Utilities & Helpers

- `ui/src/services/apiClient.js`
  - Central API wrapper used by all frontend pages.
  - Handles base URL, JSON headers, response parsing, and error throwing.

- `api/utils/response.js`
  - `ok(data, message)`: create a standardized success payload.
  - `fail(message, statusCode)`: create errors with a status payload.

- `api/controllers/*`
  - Controllers centralize request/response handling and let services remain focused on business rules.

- `api/services/*`
  - Backend services are reusable business logic units that can be shared by multiple controllers.

- UI shared components
  - `Header.jsx` for top-level navigation.
  - `InfoCard.jsx` for dashboard metrics and cards.

## Notes for Copilot Usage

- The project is intentionally small and layered to practice tracing logic end-to-end.
- Use Copilot to ask for `route -> controller -> service` mappings, especially for the inventory sync and catalog pricing flows.
- Prefer using the existing `apiClient` helper and backend `services` instead of adding direct `fetch` calls or duplicating business logic.
