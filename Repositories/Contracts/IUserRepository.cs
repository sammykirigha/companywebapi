using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebApi.Dtos;
using CompanyWebApi.Entities;

namespace CompanyWebApi.Repositories.Contracts
{
    public interface IUserRepository
    {
        User CreateNewUser(UserDto userToRegister);
        Task<User> Login(LoginDto payload);
        public abstract void CreatePasswordHash(string password, out string passwordHash);
        public abstract string CreateToken(User user);
        public abstract bool VerifyPasswordHash(string password, string passwordHash);
    }
}