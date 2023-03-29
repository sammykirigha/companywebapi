using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompanyWebApi.Dtos;
using CompanyWebApi.Entities;

namespace CompanyWebApi.Handler
{
    public class AutoMapperUser : Profile
    {
        public AutoMapperUser()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }

    }
}