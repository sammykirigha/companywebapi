using Microsoft.EntityFrameworkCore;
using CompanyWebApi.Entities;
using CompanyWebApi.enums;

namespace CompanyWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Email = "sammy@test.com",
                Username = "Sammy",
                PasswordHash = "$2a$11$qb5sPvPOcvBUU3xaGfGG6.UeAydaeNXvWKENmiNiqJK5plCeM6chG",
                JobTitle = "HR Manager",
                Role_Id = 1
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                EmployeeNumber = 1,
                FirstName = "Samuel",
                LastName = "Kirigha",
                MaritalStatus = "Single",
                JoinedDate = new DateTime(2020, 3, 1),
                BirthDate = new DateTime(1995, 1, 16),
                Email = "sammy@companywebapi.com",
                Gender = "Male",
                PhoneNumber = "09776573458",
                Department = "IT",
                JobTitle = "Software Developer"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 2,
                EmployeeNumber = 2,
                FirstName = "John",
                LastName = "Mwasho",
                MaritalStatus = "Single",
                JoinedDate = new DateTime(2022, 3, 1),
                BirthDate = new DateTime(1999, 1, 16),
                Email = "john@companywebapi.com",
                Gender = "Male",
                PhoneNumber = "0875667487",
                Department = "IT",
                JobTitle = "Software Developer"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 3,
                EmployeeNumber = 3,
                FirstName = "Jane",
                LastName = "Wambui",
                MaritalStatus = "Married",
                JoinedDate = new DateTime(2021, 3, 1),
                BirthDate = new DateTime(1985, 1, 16),
                Email = "jane@companywebapi.com",
                Gender = "Female",
                PhoneNumber = "07873274671",
                Department = "HR",
                JobTitle = "Human Resource Manager"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 4,
                EmployeeNumber = 4,
                FirstName = "Peter",
                MaritalStatus = "Single",
                JoinedDate = new DateTime(2020, 3, 1),
                BirthDate = new DateTime(1989, 1, 16),
                Email = "peter@companywebapi.com",
                Gender = "Male",
                PhoneNumber = "076748624",
                LastName = "Kamau",
                Department = "Sales",
                JobTitle = "Sales Manager"
            });


        }
    }
}