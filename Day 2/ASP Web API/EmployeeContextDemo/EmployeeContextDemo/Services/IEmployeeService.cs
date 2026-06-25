using EmployeeContextDemo.Models;

namespace EmployeeContextDemo.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();

        Task<Employee?> GetEmployeeByIdAsync(int id);

        Task<Employee> AddEmployeeAsync(Employee employee);
    }
}