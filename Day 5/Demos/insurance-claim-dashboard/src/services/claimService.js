const mockClaims = [
  {
    id: "CLAIM-001",
    policyHolder: "Alex Johnson",
    status: "Pending",
    requestedAmount: 3200,
    approvedAmount: null,
    rejectionReason: "",
    submittedDate: "2026-06-10",
  },
  {
    id: "CLAIM-002",
    policyHolder: "Maria Lopez",
    status: "Pending",
    requestedAmount: 1500,
    approvedAmount: null,
    rejectionReason: "",
    submittedDate: "2026-06-08",
  },
  {
    id: "CLAIM-003",
    policyHolder: "James Smith",
    status: "Approved",
    requestedAmount: 7800,
    approvedAmount: 7800,
    rejectionReason: "",
    submittedDate: "2026-06-06",
  },
  {
    id: "CLAIM-004",
    policyHolder: "Nina Patel",
    status: "Rejected",
    requestedAmount: 2400,
    approvedAmount: 0,
    rejectionReason: "Missing documentation",
    submittedDate: "2026-06-09",
  },
];

function getClaims() {
  return mockClaims.map((claim) => ({ ...claim }));
}

function approveClaim(claimId, approvedAmount = null) {
  const claim = mockClaims.find((item) => item.id === claimId);
  if (!claim) {
    throw new Error(`Claim with id ${claimId} not found.`);
  }

  if (claim.status !== "Pending") {
    throw new Error("Only Pending claims can be approved.");
  }

  const finalApprovedAmount =
    approvedAmount === null ? claim.requestedAmount : approvedAmount;
  if (finalApprovedAmount > claim.requestedAmount) {
    throw new Error(
      "Approved claim amount cannot be greater than requested amount.",
    );
  }

  claim.status = "Approved";
  claim.approvedAmount = finalApprovedAmount;
  claim.rejectionReason = "";

  return getClaims();
}

function rejectClaim(claimId, rejectionReason) {
  const claim = mockClaims.find((item) => item.id === claimId);
  if (!claim) {
    throw new Error(`Claim with id ${claimId} not found.`);
  }

  if (claim.status !== "Pending") {
    throw new Error("Only Pending claims can be rejected.");
  }

  if (!rejectionReason || !rejectionReason.toString().trim()) {
    throw new Error("Rejected claims require a rejection reason.");
  }

  claim.status = "Rejected";
  claim.rejectionReason = rejectionReason.toString().trim();
  claim.approvedAmount = 0;

  return getClaims();
}

export { getClaims, approveClaim, rejectClaim };
