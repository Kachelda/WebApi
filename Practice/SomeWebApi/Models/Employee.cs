using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SomeWebApi.Models
{
    public class Employee
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("workExp")]
        public int WorkExp { get; set; }

        [JsonProperty("salary")]
        public int Salary { get; set; }

        [JsonProperty("parentId")]
        public int Parent { get; set; }
    }
}