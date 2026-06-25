import { useEffect, useState } from "react";
import ClaimTable from "../components/ClaimTable";
import { getClaims, approveClaim, rejectClaim } from "../services/claimService";

function ClaimsDashboard() {
  const [claims, setClaims] = useState([]);
  const [error, setError] = useState("");

  useEffect(() => {
    setClaims(getClaims());
  }, []);

  function handleApprove(id, approvedAmount) {
    setError("");

    let amount = approvedAmount;
    if (amount === null || amount === undefined) {
      const input = prompt("Enter approved amount:");
      if (input === null) return; // user cancelled
      const num = Number(input);
      if (Number.isNaN(num)) {
        setError("Invalid approved amount.");
        alert("Invalid approved amount.");
        return;
      }
      amount = num;
    }

    try {
      const updated = approveClaim(id, amount);
      setClaims(updated);
    } catch (e) {
      setError(e.message || "Failed to approve claim.");
      alert(e.message || "Failed to approve claim.");
    }
  }

  function handleReject(id, reason) {
    setError("");
    let r = reason;
    if (r === null || r === undefined) {
      const input = prompt("Enter rejection reason:");
      if (input === null) return; // cancelled
      r = input;
    }

    if (!r || !String(r).trim()) {
      setError("Rejection requires a reason.");
      alert("Rejection requires a reason.");
      return;
    }

    try {
      const updated = rejectClaim(id, r);
      setClaims(updated);
    } catch (e) {
      setError(e.message || "Failed to reject claim.");
      alert(e.message || "Failed to reject claim.");
    }
  }

  return (
    <div className="claims-dashboard">
      <h2>Claims Dashboard</h2>
      {error && <div className="error-message">{error}</div>}
      <ClaimTable
        claims={claims}
        onApprove={handleApprove}
        onReject={handleReject}
      />
    </div>
  );
}

export default ClaimsDashboard;
