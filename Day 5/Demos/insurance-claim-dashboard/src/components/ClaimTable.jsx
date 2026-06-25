function ClaimTable({ claims = [], onApprove, onReject }) {
  const hasClaims = Array.isArray(claims) && claims.length > 0;

  function formatCurrency(value) {
    if (value === null || value === undefined) return "-";
    return `$${Number(value).toLocaleString()}`;
  }

  return (
    <div className="claim-table">
      {!hasClaims ? (
        <div className="empty-state">No claims available.</div>
      ) : (
        <table className="claim-table__table">
          <thead>
            <tr>
              <th>Claimant</th>
              <th>Claim Type</th>
              <th>Requested</th>
              <th>Approved</th>
              <th>Status</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {claims.map((c) => (
              <tr key={c.id} className="claim-row">
                <td>{c.policyHolder || "Unknown"}</td>
                <td>{c.claimType || c.type || "N/A"}</td>
                <td>{formatCurrency(c.requestedAmount)}</td>
                <td>
                  {c.approvedAmount != null
                    ? formatCurrency(c.approvedAmount)
                    : "-"}
                </td>
                <td>
                  <span className="claim-status-badge">{c.status}</span>
                </td>
                <td>
                  {c.status === "Pending" ? (
                    <>
                      <button
                        className="btn-approve"
                        onClick={() => {
                          let approved = null;
                          const input = prompt(
                            `Enter approved amount for ${c.policyHolder} (max ${c.requestedAmount}):`,
                            String(c.requestedAmount),
                          );
                          if (input !== null) {
                            const num = Number(input);
                            approved = Number.isNaN(num) ? null : num;
                          }
                          onApprove && onApprove(c.id, approved);
                        }}
                      >
                        Approve
                      </button>
                      <button
                        className="btn-reject"
                        onClick={() => {
                          const reason = prompt(
                            `Reason for rejecting ${c.policyHolder}:`,
                          );
                          if (reason === null) return;
                          onReject && onReject(c.id, reason);
                        }}
                      >
                        Reject
                      </button>
                    </>
                  ) : (
                    <span className="no-actions">—</span>
                  )}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}

export default ClaimTable;
