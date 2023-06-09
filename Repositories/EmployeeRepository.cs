

using AutoMapper;
using CompanyWebApi.Data;
using CompanyWebApi.Dto;
using CompanyWebApi.Entities;
using CompanyWebApi.Exceptions;
using CompanyWebApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public EmployeeRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public ICollection<Employee> GetAllEmployees()
        {
            try
            {
                var employees = _dataContext.Employees.OrderBy(e => e.Id).ToList();
                return employees;

            }
            catch (ErrorHandlerException ex)
            {

                throw new ErrorHandlerException(ex.Message);
            }

        }

        public EmployeeDto GetEmployeeById(int id)
        {
            try
            {
                var employee = _dataContext.Employees.Find(id);
                var returnedEmployeeDto = _mapper.Map<EmployeeDto>(employee);
                return returnedEmployeeDto == null ? throw new EmployeeErrorHandler("Could not retrieve employee with that id") : returnedEmployeeDto;
            }
            catch (Exception)
            {

                throw new ErrorHandlerException("Error occurred while retrieving the employee!");
            }

        }

        public EmployeeDto CreateNewEmployee(Employee employeeToCreate)
        {
            try
            {
                var existingEmployee = _dataContext.Employees.FirstOrDefault(e => e.Email == employeeToCreate.Email);
                if (existingEmployee == null)
                {
                    _dataContext.Employees.Add(employeeToCreate);
                    _dataContext.SaveChanges();
                    var createdEmployee = _dataContext.Employees.FirstOrDefault(e => e.Email == employeeToCreate.Email);
                    var employeeToCreateMap = _mapper.Map<EmployeeDto>(createdEmployee);
                    return employeeToCreateMap;
                }
                else
                {
                    throw new EmployeeErrorHandler();
                }
            }
            catch (ErrorHandlerException ex)
            {

                throw new ErrorHandlerException(ex.Message);
            }


        }

        public EmployeeDto DeleteEmployee(int id)
        {

            try
            {
                var employee = _dataContext.Employees.Find(id);
                var deletedEmployee = _mapper.Map<EmployeeDto>(employee);
                _dataContext.Employees.Remove(employee);
                _dataContext.SaveChangesAsync();
                return employee == null ? throw new EmployeeErrorHandler("No Employee with that record found") : deletedEmployee;
            }
            catch (ErrorHandlerException ex)
            {

                throw new ErrorHandlerException("No Employee with that record found");
            }

        }

        public Employee UpdateEmployee(EmployeeDto employee, int id)
        {
            try
            {
                var foundEmployee = _dataContext.Employees.Find(id);
                if (foundEmployee != null)
                {
                    foundEmployee.MaritalStatus = employee.MaritalStatus;
                    foundEmployee.JobTitle = employee.JobTitle;
                    foundEmployee.Department = employee.Department;
                    foundEmployee.EmployeeNumber = employee.EmployeeNumber;
                    foundEmployee.Email = employee.Email;
                    foundEmployee.FirstName = employee.FirstName;
                    foundEmployee.LastName = employee.LastName;
                    foundEmployee.Gender = employee.Gender;
                    foundEmployee.PhoneNumber = employee.PhoneNumber;
                    foundEmployee.Email = employee.Email;
                    foundEmployee.JoinedDate = employee.JoinedDate;

                    _dataContext.SaveChangesAsync();

                    var updatedEmployee = _dataContext.Employees.Find(id);

                    return updatedEmployee;
                }
                else
                {
                    throw new EmployeeErrorHandler("No Employee with that record found");
                }


            }
            catch (Exception ex)
            {

                throw new EmployeeErrorHandler(ex.Message);
            }

        }
    }
}