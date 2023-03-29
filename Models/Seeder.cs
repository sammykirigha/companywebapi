using AutoFixture;
using CompanyWebApi.Data;
using CompanyWebApi.Entities;

namespace CompanyWebApi.Seed
{
    public static class Seeder
    {
        public static void Seed(this DataContext employeesContext)
        {
            if (!employeesContext.Employees.Any())
            {
                Fixture fixture = new Fixture();
                fixture.Customize<Employee>(employee => employee.Without(e => e.Id));
                List<Employee> employees = fixture.CreateMany<Employee>(20).ToList();
                employeesContext.AddRange(employees);
                employeesContext.SaveChanges();
            }
        }
    }
}