using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Domain.Core;

namespace Practice.Infrastructure.Data
{
    public class EmployeeContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Ignore(e => e.Employees);
        }
    }
}
