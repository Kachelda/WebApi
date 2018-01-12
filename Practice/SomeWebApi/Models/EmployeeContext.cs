using System.Data.Entity;

namespace SomeWebApi.Models
{
    public class EmployeeContext: DbContext
    {
        public EmployeeContext() :
            base("DefaultConnection")
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}