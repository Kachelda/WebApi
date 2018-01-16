using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Domain.Core;

namespace Practice.Domain.Interfaces
{
    public interface IEmployeeRepository: IDisposable
    {
        IEnumerable<Employee> GetEmployeesList();
        Employee GetEmployee(int id);
        void Create(Employee item);
        void Update(Employee item);
        bool Delete(Employee employee);
        void Save();
    }
}
