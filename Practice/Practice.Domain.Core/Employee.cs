using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Domain.Core
{
    public class Employee
    {
        //[JsonProperty("id")]
        public int Id { get; set; }

        //[JsonProperty("name")]
        public string Name { get; set; }

        //[JsonProperty("position")]
        public string Position { get; set; }

        //[JsonProperty("workExp")]
        public int WorkExp { get; set; }

        //[JsonProperty("salary")]
        public int Salary { get; set; }

        //[JsonProperty("parentId")]
        public int Parent { get; set; }

        public List<Employee> Employees { get; set; }

        public Employee()
        {
            Employees = new List<Employee>();
        }
    }
}
