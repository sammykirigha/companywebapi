using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompanyWebApi.Dto;
using CompanyWebApi.Entities;

namespace CompanyWebApi.Handler
{
    public class AutoMapperEmployee : Profile
    {
        public AutoMapperEmployee()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}