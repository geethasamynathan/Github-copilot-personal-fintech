describe("claimService - business rules", () => {
  let service;
  let getClaims, approveClaim, rejectClaim;

  beforeEach(async () => {
    // Ensure a fresh module instance for each test
    if (typeof jest !== "undefined" && jest.resetModules) {
      jest.resetModules();
    }
    service = await import("../services/claimService.js");
    ({ getClaims, approveClaim, rejectClaim } = service);
  });

  test("getClaims returns claim list", () => {
    // Arrange
    // Act
    const claims = getClaims();
    // Assert
    expect(Array.isArray(claims)).toBe(true);
    expect(claims.length).toBeGreaterThan(0);
  });

  test("approveClaim approves a Pending claim", () => {
    // Arrange
    const initial = getClaims();
    const pending = initial.find((c) => c.status === "Pending");
    expect(pending).toBeDefined();

    // Act
    const updated = approveClaim(pending.id, pending.requestedAmount);

    // Assert
    const target = updated.find((c) => c.id === pending.id);
    expect(target.status).toBe("Approved");
    expect(target.approvedAmount).toBe(pending.requestedAmount);
  });

  test("approveClaim fails when claim is already approved", () => {
    // Arrange
    const initial = getClaims();
    const approved = initial.find((c) => c.status === "Approved");
    expect(approved).toBeDefined();

    // Act & Assert
    expect(() => approveClaim(approved.id)).toThrow(
      "Only Pending claims can be approved.",
    );
  });

  test("approveClaim fails when approved amount is greater than requested amount", () => {
    // Arrange
    const initial = getClaims();
    const pending = initial.find((c) => c.status === "Pending");
    expect(pending).toBeDefined();

    // Act & Assert
    expect(() => approveClaim(pending.id, pending.requestedAmount + 1)).toThrow(
      "Approved claim amount cannot be greater than requested amount.",
    );
  });

  test("rejectClaim rejects a pending claim", () => {
    // Arrange
    const initial = getClaims();
    const pending = initial.find((c) => c.status === "Pending");
    expect(pending).toBeDefined();

    // Act
    const updated = rejectClaim(pending.id, "Invalid documentation");

    // Assert
    const target = updated.find((c) => c.id === pending.id);
    expect(target.status).toBe("Rejected");
    expect(target.rejectionReason).toBe("Invalid documentation");
  });

  test("rejectClaim fails when reason is empty", () => {
    // Arrange
    const initial = getClaims();
    const pending = initial.find((c) => c.status === "Pending");
    expect(pending).toBeDefined();

    // Act & Assert
    expect(() => rejectClaim(pending.id, "")).toThrow(
      "Rejected claims require a rejection reason.",
    );
  });
});
