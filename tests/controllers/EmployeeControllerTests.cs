using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebApi.Entities;
using CompanyWebApi.Repositories.Contracts;
using EmployeesApi.Controllers;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CompanyWebApi.tests.controllers
{
    public class EmployeeControllerTests
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeControllerTests()
        {
            _employeeRepository = A.Fake<IEmployeeRepository>();
        }

        [Fact]
        public void EmployeeController_GetAllEmployees_ReturnOk()
        {
            //Arrange
            var employees = A.Fake<ICollection<Employee>>();
            var employeeList = A.Fake<List<Employee>>();
            A.CallTo(() => _employeeRepository.GetAllEmployees()).Returns(employeeList);
            var controller = new EmployeesController(_employeeRepository);

            //act
            var result = controller.GetAllEmployees();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}