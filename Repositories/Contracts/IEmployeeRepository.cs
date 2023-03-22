

using CompanyWebApi.Entities;

namespace CompanyWebApi.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<Employee> GetEmployeeById(int id);

        Task<Employee> CreateNewEmployee(Employee employee);

        Task<Employee> DeleteEmployee(int id);

        Task<Employee> UpdateEmployee(Employee employee, int id);
    }
}