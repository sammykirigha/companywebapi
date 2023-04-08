using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebApi.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public int Role_Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Password { get; set; }
    }
}
