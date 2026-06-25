# Inventory Sync Journey Map

```text
User clicks Sync Inventory
        |
        v
ui/src/pages/UserInventory.jsx
syncInventory()
        |
        v
ui/src/services/apiClient.js
POST /api/inventory/sync
        |
        v
api/server.js
app.use('/api/inventory', inventoryRoutes)
        |
        v
api/routes/inventoryRoutes.js
router.post('/sync', syncUserInventory)
        |
        v
api/controllers/inventoryController.js
syncUserInventory(req, res, next)
        |
        v
api/services/inventorySyncService.js
syncInventory({ requestedBy })
        |
        v
Mock inventory lots updated with lastSyncedAt
        |
        v
JSON response returned to React UI
```

## Copilot Prompt

```text
Show me how the inventory sync functionality works from the UI button click to the backend API response. Create a journey map and identify each file involved.
```
