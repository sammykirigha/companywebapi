

using CompanyWebApi.Entities;

namespace CompanyWebApi.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetAllEmployees();

        Task<Employee> GetEmployeeById(int id);

        Employee CreateNewEmployee(Employee employeeToCreate);

        Task<Employee> DeleteEmployee(int id);

        Task<Employee> UpdateEmployee(Employee employee, int id);
    }
}