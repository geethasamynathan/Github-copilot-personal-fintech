using System.Reflection;
using EmployeeContextDemo.Models;
using EmployeeContextDemo.Services;
using NUnit.Framework;

namespace EmployeeContextDemo.Tests;

public class EmployeeServiceTests
{
    private EmployeeService _service = null!;

    [SetUp]
    public void Setup()
    {
        ResetStaticEmployeeList();
        _service = new EmployeeService();
    }

    [Test]
    public async Task GetAllEmployeesAsync_ReturnsAllSeedEmployees()
    {
        var employees = await _service.GetAllEmployeesAsync();

        Assert.That(employees, Has.Count.EqualTo(2));
        Assert.That(employees.Select(e => e.EmployeeId), Is.EqualTo(new[] { 1, 2 }));
        Assert.That(employees.Select(e => e.Name), Is.EqualTo(new[] { "Arun", "Priya" }));
    }

    [Test]
    public async Task GetEmployeeByIdAsync_ReturnsEmployee_WhenIdExists()
    {
        var employee = await _service.GetEmployeeByIdAsync(1);

        Assert.That(employee, Is.Not.Null);
        Assert.That(employee?.Name, Is.EqualTo("Arun"));
        Assert.That(employee?.Department, Is.EqualTo("IT"));
        Assert.That(employee?.Salary, Is.EqualTo(45000));
    }

    [Test]
    public async Task GetEmployeeByIdAsync_ReturnsNull_WhenIdDoesNotExist()
    {
        var employee = await _service.GetEmployeeByIdAsync(999);

        Assert.That(employee, Is.Null);
    }

    [Test]
    public async Task GetEmployeeByIdAsync_ReturnsNull_WhenIdIsZero()
    {
        var employee = await _service.GetEmployeeByIdAsync(0);

        Assert.That(employee, Is.Null);
    }

    [Test]
    public async Task GetEmployeeByIdAsync_ReturnsNull_WhenIdIsNegative()
    {
        var employee = await _service.GetEmployeeByIdAsync(-1);

        Assert.That(employee, Is.Null);
    }

    [Test]
    public async Task AddEmployeeAsync_AssignsNewIdAndAddsEmployee()
    {
        var newEmployee = new Employee
        {
            Name = "Ravi",
            Department = "Finance",
            Salary = 38000
        };

        var addedEmployee = await _service.AddEmployeeAsync(newEmployee);
        var employees = await _service.GetAllEmployeesAsync();

        Assert.That(addedEmployee.EmployeeId, Is.EqualTo(3));
        Assert.That(addedEmployee.Name, Is.EqualTo("Ravi"));
        Assert.That(addedEmployee.Department, Is.EqualTo("Finance"));
        Assert.That(addedEmployee.Salary, Is.EqualTo(38000));
        Assert.That(employees, Has.Count.EqualTo(3));
        Assert.That(employees.Select(e => e.EmployeeId), Contains.Item(3));
    }

    [Test]
    public void AddEmployeeAsync_ThrowsArgumentNullException_WhenEmployeeIsNull()
    {
        Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.AddEmployeeAsync(null!));
    }

    private static void ResetStaticEmployeeList()
    {
        var field = typeof(EmployeeService).GetField("_employees", BindingFlags.Static | BindingFlags.NonPublic);
        if (field?.GetValue(null) is List<Employee> employees)
        {
            employees.Clear();
            employees.AddRange(new[]
            {
                new Employee { EmployeeId = 1, Name = "Arun", Department = "IT", Salary = 45000 },
                new Employee { EmployeeId = 2, Name = "Priya", Department = "HR", Salary = 40000 }
            });
        }
    }
}
