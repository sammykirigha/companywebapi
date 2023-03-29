using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebApi.Enums;

namespace CompanyWebApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public Roles Role { get; set; } = Roles.Admin;
        public string Username { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string PasswordHash { get; set; }

        public string? Token { get; set; }



        // internal void Deconstruct(out object id, out object role, out object username, out object email, out object jobTitle)
        // {
        //     id = Id;
        //     role = Role;
        //     username = Username;
        //     email = Email;
        //     jobTitle = JobTitle;
        // }
    }
}