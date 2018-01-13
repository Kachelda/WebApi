using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Practice.Domain.Core;
using Practice.Domain.Interfaces;

namespace Practice.Infrastructure.Data
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private EmployeeContext db;

        public EmployeeRepository()
        {
            this.db = new EmployeeContext();
        }

        public IEnumerable<Employee> GetEmployeesList()
        {
            return db.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return db.Employees.Find(id);
        }

        public void Create(Employee employee)
        {
            db.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee != null)
                db.Employees.Remove(employee);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}