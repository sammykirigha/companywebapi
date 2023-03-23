

using CompanyWebApi.Data;
using CompanyWebApi.Entities;
using CompanyWebApi.Exceptions;
using CompanyWebApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeesContext employeesContext;

        public EmployeeRepository(EmployeesContext employeesContext)
        {
            this.employeesContext = employeesContext;
        }

        public async Task<ICollection<Employee>> GetAllEmployees()
        {
            var employees = await this.employeesContext.Employees.OrderBy(e => e.Id).ToListAsync();
            return employees;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await this.employeesContext.Employees.FindAsync(id);
            return employee;
        }

        public async Task<Employee> CreateNewEmployee(Employee employee)
        {
            try
            {
                var existingEmployee = employeesContext.Employees.FirstOrDefault(e => e.Email == employee.Email);
                if (existingEmployee == null)
                {
                    this.employeesContext.Employees.Add(employee);
                    await employeesContext.SaveChangesAsync();
                    return employee;
                }
                else
                {
                    throw new CreateNewEmployeeErrorHandler();
                }
            }
            catch (ErrorHandlerException ex)
            {

                throw new ErrorHandlerException(ex.Message);
            }


        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var employee = await employeesContext.Employees.FindAsync(id);
            employeesContext.Employees.Remove(employee);
            await employeesContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee, int id)
        {
            var foundEmployee = await employeesContext.Employees.FindAsync(id);

            foundEmployee.MaritalStatus = employee.MaritalStatus;
            foundEmployee.JobTitle = employee.JobTitle;
            foundEmployee.Department = employee.Department;
            foundEmployee.BirthDate = employee.BirthDate;
            foundEmployee.EmployeeNumber = employee.EmployeeNumber;
            foundEmployee.Email = employee.Email;
            foundEmployee.FirstName = employee.FirstName;
            foundEmployee.LastName = employee.LastName;
            foundEmployee.Gender = employee.Gender;
            foundEmployee.PhoneNumber = employee.PhoneNumber;
            foundEmployee.Email = employee.Email;
            foundEmployee.JoinedDate = employee.JoinedDate;

            await employeesContext.SaveChangesAsync();

            return employee;
        }
    }
}