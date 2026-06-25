import { useEffect, useState } from 'react';
import { apiClient } from '../services/apiClient.js';

export default function Catalog() {
  const [catalog, setCatalog] = useState([]);
  const [selectedDetails, setSelectedDetails] = useState(null);

  async function loadCatalog() {
    const data = await apiClient.getCatalog();
    setCatalog(data);
  }

  async function handleColorClick(item) {
    const details = await apiClient.getItemDetails({
      itemNumber: item.itemNumber,
      itemType: 'PART',
      colorId: item.colorId,
      condition: item.condition
    });

    setSelectedDetails(details);
  }

  useEffect(() => {
    loadCatalog();
  }, []);

  return (
    <main>
      <section className="hero-card compact">
        <p className="eyebrow">Troubleshooting Demo</p>
        <h2>Catalog Pricing</h2>
        <p>
          This page demonstrates the pricing-region troubleshooting scenario. Try item <strong>3001</strong> in black and inspect
          how the price comes from the backend pricing service.
        </p>
      </section>

      <section className="catalog-grid">
        {catalog.map(item => (
          <article className="card product-card" key={item.lotId}>
            <h3>{item.itemName}</h3>
            <p>Item Number: {item.itemNumber}</p>
            <p>Color: {item.colorName}</p>
            <p>Condition: {item.condition}</p>
            <button onClick={() => handleColorClick(item)}>View Price</button>
          </article>
        ))}
      </section>

      {selectedDetails && (
        <section className="card">
          <h3>Selected Price Details</h3>
          <p>Item: {selectedDetails.item.itemName}</p>
          <p>Selected price field: {selectedDetails.priceGuide?.selectedPriceField}</p>
          <p>Average price: ${selectedDetails.priceGuide?.averagePrice}</p>
          <pre>{JSON.stringify(selectedDetails.priceGuide?.allPrices, null, 2)}</pre>
        </section>
      )}
    </main>
  );
}
