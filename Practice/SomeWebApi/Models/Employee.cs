using System.ComponentModel.DataAnnotations;

namespace SomeWebApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int WorkExp { get; set; }
        public int Salary { get; set; }
        public int Parent { get; set; }
    }
}