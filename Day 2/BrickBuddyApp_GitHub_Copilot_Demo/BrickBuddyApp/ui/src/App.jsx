import { useState } from 'react';
import Header from './components/Header.jsx';
import Dashboard from './pages/Dashboard.jsx';
import UserInventory from './pages/UserInventory.jsx';
import Catalog from './pages/Catalog.jsx';
import ApiTesting from './pages/ApiTesting.jsx';
import SettingsPage from './pages/SettingsPage.jsx';
import './styles/app.css';

export default function App() {
  const [activePage, setActivePage] = useState('dashboard');

  const pages = {
    dashboard: <Dashboard />,
    inventory: <UserInventory />,
    catalog: <Catalog />,
    'api-testing': <ApiTesting />,
    settings: <SettingsPage />
  };

  return (
    <div className="app-shell">
      <Header activePage={activePage} onNavigate={setActivePage} />
      {pages[activePage]}
    </div>
  );
}
