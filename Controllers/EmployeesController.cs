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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Employee>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = employeeRepository.GetAllEmployees();
                var employeesDto = _mapper.Map<List<EmployeeDto>>(employees);
                return employeesDto == null ? NotFound() : Ok(employeesDto);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EmployeeDto> GetEmployeeById(int id)
        {
            try
            {
                var employee = employeeRepository.GetEmployeeById(id);
                return employee == null ? NotFound("Employee with that id was not found") : Ok(employee);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }


        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Employee))]
        public IActionResult CreateEmployee([FromBody] Employee employeeToCreate)
        {
            try
            {
                var newEmployee = employeeRepository.CreateNewEmployee(employeeToCreate);
                return newEmployee == null ? NoContent() : Ok(newEmployee);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        public ActionResult<Employee> UpdateEmployee(EmployeeDto employee, int id)
        {
            try
            {
                var updatedEmployee = employeeRepository.UpdateEmployee(employee, id);
                var updatedEmployeeDto = _mapper.Map<EmployeeDto>(updatedEmployee);
                return updatedEmployee == null ? NotFound("Employee with that id was not found") : Ok(updatedEmployeeDto);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        public ActionResult<EmployeeDto> DeleteEmployee(int id)
        {
            try
            {
                var employee = employeeRepository.DeleteEmployee(id);
                return employee == null ? NotFound() : Ok("Employee deleted successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }

    }
}