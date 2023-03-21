using Microsoft.EntityFrameworkCore;
using CompanyWebApi.Entities;
using CompanyWebApi.enums;

namespace CompanyWebApi.Data
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions<EmployeesContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                EmployeeNumber = 0001,
                FirstName = "Samuel",
                LastName = "Kirigha",
                MaritalStatus = MaritalStatus.Single,
                JoinedDate = new DateTime(2020, 3, 1),
                BirthDate = new DateTime(1995, 1, 16),
                Email = "sammy@companywebapi.com",
                Gender = Gender.Male,
                PhoneNumber = "09776573458",
                Department = "IT",
                IDNumber = 23049700,
                JobTitle = "Software Developer"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 2,
                EmployeeNumber = 0002,
                FirstName = "John",
                LastName = "Mwasho",
                MaritalStatus = MaritalStatus.Single,
                JoinedDate = new DateTime(2022, 3, 1),
                BirthDate = new DateTime(1999, 1, 16),
                Email = "john@companywebapi.com",
                Gender = Gender.Male,
                PhoneNumber = "0875667487",
                Department = "IT",
                IDNumber = 230465800,
                JobTitle = "Software Developer"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 3,
                EmployeeNumber = 0003,
                FirstName = "Jane",
                LastName = "Wambui",
                MaritalStatus = MaritalStatus.Married,
                JoinedDate = new DateTime(2021, 3, 1),
                BirthDate = new DateTime(1985, 1, 16),
                Email = "jane@companywebapi.com",
                Gender = Gender.Female,
                PhoneNumber = "07873274671",
                Department = "HR",
                IDNumber = 23049700,
                JobTitle = "Human Resource Manager"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 4,
                EmployeeNumber = 0004,
                FirstName = "Peter",
                MaritalStatus = MaritalStatus.Single,
                JoinedDate = new DateTime(2020, 3, 1),
                BirthDate = new DateTime(1989, 1, 16),
                Email = "peter@companywebapi.com",
                Gender = Gender.Male,
                PhoneNumber = "076748624",
                LastName = "Kamau",
                Department = "Sales",
                IDNumber = 23049700,
                JobTitle = "Sales Manager"
            });
        }


    }
}