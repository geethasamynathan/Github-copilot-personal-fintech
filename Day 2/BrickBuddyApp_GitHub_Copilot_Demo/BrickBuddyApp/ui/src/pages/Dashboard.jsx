import InfoCard from '../components/InfoCard.jsx';

export default function Dashboard() {
  return (
    <main className="page-grid">
      <section className="hero-card">
        <p className="eyebrow">Training Scenario</p>
        <h2>Understand a new codebase using GitHub Copilot</h2>
        <p>
          This application is intentionally organized like a real project. Learners can ask Copilot to analyze architecture,
          trace API flows, generate cheat sheets, and troubleshoot bugs.
        </p>
      </section>

      <div className="metrics-grid">
        <InfoCard title="Frontend" value="React" description="Component-based UI with pages, shared components, and API client." />
        <InfoCard title="Backend" value="Express" description="Routes, controllers, services, mock data, and error handling." />
        <InfoCard title="Copilot Context" value="Ready" description="Includes .github/copilot-instructions.md and documentation files." />
      </div>

      <section className="card">
        <h3>Suggested Copilot Prompt</h3>
        <pre>{`Give me a basic architecture overview of this project. Include folder structure, key components, API data flow, and common patterns.`}</pre>
      </section>
    </main>
  );
}
