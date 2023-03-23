using Microsoft.AspNetCore.Mvc;
using CompanyWebApi.Entities;
using AutoMapper;
using CompanyWebApi.Repositories.Contracts;
using CompanyWebApi.Data;
using CompanyWebApi.Dto;

namespace EmployeesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper _mapper;


        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _mapper.Map<List<EmployeeDto>>(employeeRepository.GetAllEmployees());
                if (employees == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(employees);
                }

            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                var employee = await employeeRepository.GetEmployeeById(id);
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
            try
            {
                var newEmployee = await employeeRepository.CreateNewEmployee(employee);
                if (newEmployee == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(newEmployee);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee, int id)
        {
            try
            {
                var foundEmployee = await employeeRepository.UpdateEmployee(employee, id);
                if (foundEmployee == null) return BadRequest("Employee with that id was not found");

                return Ok(employee);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var employee = await employeeRepository.DeleteEmployee(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok("Employee deleted successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}