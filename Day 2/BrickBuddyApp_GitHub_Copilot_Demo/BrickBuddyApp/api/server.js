import express from 'express';
import cors from 'cors';
import inventoryRoutes from './routes/inventoryRoutes.js';
import catalogRoutes from './routes/catalogRoutes.js';
import settingsRoutes from './routes/settingsRoutes.js';

const app = express();
const PORT = process.env.PORT || 4000;

app.use(cors());
app.use(express.json());

app.get('/api/health', (req, res) => {
  res.json({ success: true, message: 'BrickBuddy API is running' });
});

app.use('/api/inventory', inventoryRoutes);
app.use('/api/catalog', catalogRoutes);
app.use('/api/settings', settingsRoutes);

app.use((req, res) => {
  res.status(404).json({ success: false, message: `Route not found: ${req.method} ${req.originalUrl}` });
});

app.use((error, req, res, next) => {
  const statusCode = error.statusCode || 500;
  res.status(statusCode).json({ success: false, message: error.message || 'Internal server error' });
});

app.listen(PORT, () => {
  console.log(`BrickBuddy API running at http://localhost:${PORT}`);
});
