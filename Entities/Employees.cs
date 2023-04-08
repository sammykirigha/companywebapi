using System;

namespace CompanyWebApi.Entities
{
    public class Employee
    {
        public int? Id { get; set; }
        public int EmployeeNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Department { get; set; }
        public string? JobTitle { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Email { get; set; }

        public DateTime? JoinedDate { get; set; }

        public string? MaritalStatus { get; set; }

        public string? Gender { get; set; }

        public string? PhoneNumber { get; set; }

    }
}