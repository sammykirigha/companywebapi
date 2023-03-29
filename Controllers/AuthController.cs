using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CompanyWebApi.Dtos;
using CompanyWebApi.Entities;
using CompanyWebApi.Repositories.Contracts;
using CompanyWebApi.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CompanyWebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(User))]
        public async Task<ActionResult<string>> Register([FromBody] UserDto request)
        {

            try
            {
                var newUser = _userRepository.CreateNewUser(request);
                return newUser == null ? NoContent() : Ok(new AuthResponse(201, "success", "User Created successfully"));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }




        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        public async Task<ActionResult<User>> Login(string email, string password)
        {
            try
            {
                var result = await _userRepository.Login(email, password);
                return result == null ? NoContent() : Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }
    }
}