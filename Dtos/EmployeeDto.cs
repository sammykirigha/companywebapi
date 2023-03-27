using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebApi.enums;

namespace CompanyWebApi.Dto
{
    public class EmployeeDto
    {

        public int? Id { get; set; }
        public int EmployeeNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Department { get; set; }
        public string? JobTitle { get; set; }

        public string? Email { get; set; }

        public DateTime? JoinedDate { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public Gender Gender { get; set; }

        public string? PhoneNumber { get; set; }
    }
}