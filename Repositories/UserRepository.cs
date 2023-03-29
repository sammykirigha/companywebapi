using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CompanyWebApi.Data;
using CompanyWebApi.Dtos;
using CompanyWebApi.Entities;
using CompanyWebApi.Enums;
using CompanyWebApi.Exceptions;
using CompanyWebApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CompanyWebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserRepository(DataContext dataContext, IMapper mapper, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public User CreateNewUser(UserDto userToRegister)
        {
            try
            {
                var existingUser = _dataContext.Users.FirstOrDefault(e => e.Email == userToRegister.Email);
                if (existingUser != null)
                {
                    throw new ErrorHandlerException("Email already in use");
                }
                else
                {

                    var userToRegisterMap = _mapper.Map<User>(userToRegister);

                    CreatePasswordHash(userToRegister.Password, out string passwordHash);
                    userToRegisterMap.PasswordHash = passwordHash;

                    _dataContext.Users.Add(userToRegisterMap);
                    _dataContext.SaveChanges();

                    var createdUser = _dataContext.Users.FirstOrDefault(u => u.Email == userToRegister.Email)!;

                    // Deconstruct(userToRegisterMap, out string username, out string email, out string role, out string jobTitle);
                    return createdUser;
                }
            }
            catch (ErrorHandlerException ex)
            {

                throw new ErrorHandlerException($"'reg'{ex.Message}");
            }
        }


        public async Task<User> Login(string email, string password)
        {
            try
            {
                // var payloadMap = _mapper.Map<User>(payload);
                var existingUser = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (existingUser == null)
                {
                    throw new ErrorHandlerException("Wrong email!! try again");
                };
                if (!VerifyPasswordHash(password, existingUser!.PasswordHash)) throw new ErrorHandlerException("password wong!!");

                string token = CreateToken(existingUser);
                existingUser.Token = token;
                _dataContext.SaveChanges();
                return existingUser;
            }
            catch (ErrorHandlerException ex)
            {

                throw new ErrorHandlerException(ex.Message);
            }
        }
        // private void Deconstruct(User payload, out string username, out string email, out string role, out string jobTitle, out string token)
        // {
        //     username = payload.Username;
        //     email = payload.Email;
        //     role = Enum.GetName(typeof(Roles), payload.Role)!;
        //     jobTitle = payload.JobTitle;
        //     token = payload.token;
        // }



        public void CreatePasswordHash(string password, out string passwordHash)
        {
            passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public bool VerifyPasswordHash(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}