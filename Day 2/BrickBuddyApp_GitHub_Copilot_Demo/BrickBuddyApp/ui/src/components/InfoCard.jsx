export default function InfoCard({ title, value, description }) {
  return (
    <section className="card metric-card">
      <p className="metric-title">{title}</p>
      <h2>{value}</h2>
      <p>{description}</p>
    </section>
  );
}
