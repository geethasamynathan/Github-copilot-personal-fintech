# EmployeeServiceTests Documentation

## 1. Title
EmployeeServiceTests Documentation

## 2. Purpose of this test file
This file contains unit tests for the `EmployeeService` class. Its goal is to verify that the service methods behave correctly for employee retrieval and creation scenarios. The tests help catch bugs early and confirm that the service returns expected values for both valid and invalid input.

## 3. Technologies used
- C#
- .NET 10
- NUnit testing framework
- `EmployeeContextDemo` project classes
- Reflection (`System.Reflection`) to reset internal static test state

## 4. Explain the EmployeeServiceTest Class
The `EmployeeServiceTests` class is a test container. It groups related tests for `EmployeeService` and holds shared setup code. Each test method inside this class runs independently to verify a specific behavior of the service.

## 5. Explain Setup Method
The `Setup` method is marked with `[SetUp]`, which means NUnit runs it before every test method.

Inside `Setup`:
- `ResetStaticEmployeeList()` restores the shared employee list to a known starting state.
- `_service = new EmployeeService();` creates a fresh service instance for each test.

This ensures tests do not interfere with each other.

## 6. Explain each test method one by one.

### GetAllEmployeesAsync_ReturnsAllSeedEmployees
- Purpose: Verify that `GetAllEmployeesAsync` returns the seeded employee list.
- What it does: Calls the service method and checks the returned collection size and employee IDs/names.
- Why it is useful: Confirms the service can read existing employees correctly.

### GetEmployeeByIdAsync_ReturnsEmployee_WhenIdExists
- Purpose: Verify that requesting a valid employee ID returns the correct employee.
- What it does: Calls `GetEmployeeByIdAsync(1)` and checks the returned employee details.
- Why it is useful: Confirms the service can find an existing employee.

### GetEmployeeByIdAsync_ReturnsNull_WhenIdDoesNotExist
- Purpose: Verify that an unknown employee ID returns `null`.
- What it does: Calls `GetEmployeeByIdAsync(999)` and expects `null`.
- Why it is useful: Confirms the service handles missing employees gracefully.

### GetEmployeeByIdAsync_ReturnsNull_WhenIdIsZero
- Purpose: Verify that ID `0` is treated as invalid and returns `null`.
- What it does: Calls `GetEmployeeByIdAsync(0)` and checks for `null`.
- Why it is useful: Confirms invalid IDs do not return spurious data.

### GetEmployeeByIdAsync_ReturnsNull_WhenIdIsNegative
- Purpose: Verify that a negative ID returns `null`.
- What it does: Calls `GetEmployeeByIdAsync(-1)` and expects `null`.
- Why it is useful: Confirms the service validates invalid input values.

### AddEmployeeAsync_AssignsNewIdAndAddsEmployee
- Purpose: Verify that adding a valid employee works and assigns a new ID.
- What it does: Creates a new employee, calls `AddEmployeeAsync`, and checks the returned employee ID and list count.
- Why it is useful: Confirms the service can add employees and update its internal data.

### AddEmployeeAsync_ThrowsArgumentNullException_WhenEmployeeIsNull
- Purpose: Verify that passing `null` into `AddEmployeeAsync` throws an error.
- What it does: Calls `AddEmployeeAsync(null!)` and expects `ArgumentNullException`.
- Why it is useful: Confirms the service protects itself from invalid `null` input.

## 7. How to Run these tests
1. Open the solution or the test project in a terminal.
2. Navigate to `EmployeeContextDemo.Tests` folder if needed.
3. Run:

```powershell
dotnet test
```

This command will build the test project and execute all NUnit tests.

## 8. Explain about Arrange, Act, Assert used in this tests
Each test follows the Arrange-Act-Assert pattern:

- Arrange: Set up the objects and state needed for the test.
  - Example: `var newEmployee = new Employee { ... };`
- Act: Call the method being tested.
  - Example: `var employee = await _service.GetEmployeeByIdAsync(1);`
- Assert: Verify the result matches expectations.
  - Example: `Assert.That(employee, Is.Not.Null);`

This pattern makes tests easy to read and understand.

## 9. Summary Table
| Method Name | Scenario | Expected Result | Test Type |
|---|---|---|---|
| `GetAllEmployeesAsync_ReturnsAllSeedEmployees` | Retrieve all seeded employees | Returns 2 employees with expected IDs and names | Positive |
| `GetEmployeeByIdAsync_ReturnsEmployee_WhenIdExists` | Retrieve an existing employee by ID | Returns employee with ID 1 and matching details | Positive |
| `GetEmployeeByIdAsync_ReturnsNull_WhenIdDoesNotExist` | Request a nonexistent ID | Returns `null` | Negative |
| `GetEmployeeByIdAsync_ReturnsNull_WhenIdIsZero` | Request ID `0` | Returns `null` | Negative |
| `GetEmployeeByIdAsync_ReturnsNull_WhenIdIsNegative` | Request negative ID | Returns `null` | Negative |
| `AddEmployeeAsync_AssignsNewIdAndAddsEmployee` | Add a valid employee | Returns added employee with new ID and increases list count | Positive |
| `AddEmployeeAsync_ThrowsArgumentNullException_WhenEmployeeIsNull` | Add `null` employee | Throws `ArgumentNullException` | Negative |

## 10. Beginner-friendly tips
- Unit tests are small checks that verify one behavior at a time.
- The test class is only for checking the service logic, not the web API endpoints.
- Each test uses a fresh service instance and resets shared data so tests stay independent.
- `Assert.That(...)` is the line where the test decides whether the behavior is correct.

## 11. Conclusion
This documentation explains how the `EmployeeServiceTests` class verifies both valid and invalid cases for employee operations. The tests are useful for ensuring the service works correctly before using it inside the API.