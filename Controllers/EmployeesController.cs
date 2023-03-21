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
            return Ok(await employeesContext.Employees.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int employeeId)
        {
            var employee = await employeesContext.Employees.FindAsync(employeeId);
            if (employee == null) return BadRequest("Employee with that id was not found");
            return Ok(employee);

        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            employeesContext.Add(employee);
            await employeesContext.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee, int employeeId)
        {
            var foundEmployee = await employeesContext.Employees.FindAsync(employeeId);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int employeeId)
        {
            var employee = await employeesContext.Employees.FindAsync();
            if (employee == null) return BadRequest("Employee with that id was not found");
            return Ok("Employee deleted successfully");
        }
    }
}