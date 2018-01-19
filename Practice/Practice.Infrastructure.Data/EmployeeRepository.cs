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
        
        public IEnumerable<Employee> GetChildEmployee(int parentId)
        {
            var result = db.Employees.Where(emp => emp.Parent == parentId);
           
            foreach (var item in result)
            {
                item.Employees.AddRange(GetChildEmployee(item.Id));
            }

            return result;
        }

        public int GetMinParentId()
        {
            var minParentId = db.Employees.Min(p => p.Parent);
            return minParentId;
        }

        public void Create(Employee employee)
        {
            db.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
        }

        public bool Delete(Employee employee)
        {
            if (employee != null)
            {
                db.Employees.Remove(employee);
                return true;
            }
            return false;
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