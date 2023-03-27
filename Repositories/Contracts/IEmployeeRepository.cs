

using CompanyWebApi.Dto;
using CompanyWebApi.Entities;

namespace CompanyWebApi.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetAllEmployees();

        EmployeeDto GetEmployeeById(int id);

        EmployeeDto CreateNewEmployee(Employee employeeToCreate);

        EmployeeDto DeleteEmployee(int id);

        Employee UpdateEmployee(EmployeeDto employeeToUpdate, int id);
    }
}