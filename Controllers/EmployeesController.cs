using Microsoft.AspNetCore.Mvc;
using CompanyWebApi.Data;
using CompanyWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesContext employeesContext;

        public EmployeesController(EmployeesContext employeesContext)
        {
            this.employeesContext = employeesContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var employees = await employeesContext.Employees.ToArrayAsync();
            return Ok(employees);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                var employee = await employeesContext.Employees.FindAsync(id);
                if (employee == null)
                {
                    return BadRequest("Employee with that id was not found");
                }
                else
                {
                    return Ok(employee);
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }


        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            employeesContext.Employees.Add(employee);
            await employeesContext.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee, int id)
        {
            var foundEmployee = await employeesContext.Employees.FindAsync(id);
            if (foundEmployee == null) return BadRequest("Employee with that id was not found");

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

            return Ok(employee);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await employeesContext.Employees.FindAsync(id);
            if (employee == null) return BadRequest("Employee with that id was not found");
            employeesContext.Employees.Remove(employee);
            await employeesContext.SaveChangesAsync();
            return Ok("Employee deleted successfully");
        }
    }
}