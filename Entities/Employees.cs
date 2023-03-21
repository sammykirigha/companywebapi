using System;
using CompanyWebApi.enums;

namespace CompanyWebApi.Entities
{
    public class Employee
    {
        public int? EmployeeId { get; set; }
        public int EmployeeNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Department { get; set; }
        public int? IDNumber { get; set; }
        public string? JobTitle { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Email { get; set; }

        public DateTime? JoinedDate { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public Gender Gender { get; set; }

        public string? PhoneNumber { get; set; }

    }
}