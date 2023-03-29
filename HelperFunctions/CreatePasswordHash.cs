using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebApi.HelperFunctions
{
    public class CreatePasswordHash
    {
        private void CreatePasswordHashFromRequest(string password, out string passwordHash)
        {
            passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

    }
}