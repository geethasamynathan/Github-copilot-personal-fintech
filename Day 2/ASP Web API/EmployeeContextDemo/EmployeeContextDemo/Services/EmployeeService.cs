using EmployeeContextDemo.Models;

namespace EmployeeContextDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private static readonly List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                EmployeeId = 1,
                Name = "Arun",
                Department = "IT",
                Salary = 45000
            },
            new Employee
            {
                EmployeeId = 2,
                Name = "Priya",
                Department = "HR",
                Salary = 40000
            }
        };

        public Task<List<Employee>> GetAllEmployeesAsync()
        {
            return Task.FromResult(_employees);
        }

        public Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.EmployeeId == id);

            return Task.FromResult(employee);
        }

        public Task<Employee> AddEmployeeAsync(Employee employee)
        {
            employee.EmployeeId = _employees.Max(e => e.EmployeeId) + 1;

            _employees.Add(employee);

            return Task.FromResult(employee);
        }
    }
}