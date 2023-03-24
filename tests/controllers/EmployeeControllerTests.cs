using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompanyWebApi.Dto;
using CompanyWebApi.Entities;
using CompanyWebApi.Repositories.Contracts;
using EmployeesApi.Controllers;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System.Threading.Tasks;

namespace CompanyWebApi.tests.controllers
{
    public class EmployeeControllerTests
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeControllerTests()
        {
            _employeeRepository = A.Fake<IEmployeeRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void EmployeeController_GetAllEmployees_ReturnOk()
        {
            //Arrange
            var employees = A.Fake<ICollection<EmployeeDto>>();
            var employeeList = A.Fake<List<EmployeeDto>>();
            A.CallTo(() => _mapper.Map<List<EmployeeDto>>(employees)).Returns(employeeList);
            var controller = new EmployeesController(_employeeRepository, _mapper);

            //act
            var result = controller.GetAllEmployees();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void EmployeeControler_CreateEmployee_ReturnOK()
        {

            var employeeMap = A.Fake<Employee>();
            var employee = A.Fake<Employee>();
            var employeeToCreate = A.Fake<EmployeeDto>();
            var employees = A.Fake<ICollection<EmployeeDto>>();
            var employeeList = A.Fake<List<EmployeeDto>>();

            A.CallTo(() => _mapper.Map<Employee>(employeeToCreate)).Returns(employee);
            A.CallTo(() => _employeeRepository.CreateNewEmployee(employeeMap)).Returns(employee);
            var controller = new EmployeesController(_employeeRepository, _mapper);

            var result = controller.CreateEmployee(employeeToCreate);

            result.Should().NotBeNull();

        }
    }
}