import { Boxes, Bot, Map, Settings, TestTube2 } from 'lucide-react';

export default function Header({ activePage, onNavigate }) {
  const links = [
    { id: 'dashboard', label: 'Dashboard', icon: Boxes },
    { id: 'inventory', label: 'User Inventory', icon: Map },
    { id: 'catalog', label: 'Catalog', icon: Bot },
    { id: 'api-testing', label: 'API Testing', icon: TestTube2 },
    { id: 'settings', label: 'Settings', icon: Settings }
  ];

  return (
    <header className="app-header">
      <div>
        <h1>BrickBuddyApp</h1>
        <p>GitHub Copilot Codebase Navigation Training Project</p>
      </div>
      <nav>
        {links.map(link => {
          const Icon = link.icon;
          return (
            <button
              key={link.id}
              className={activePage === link.id ? 'active' : ''}
              onClick={() => onNavigate(link.id)}
            >
              <Icon size={16} /> {link.label}
            </button>
          );
        })}
      </nav>
    </header>
  );
}
