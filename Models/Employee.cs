using System.Text.Json.Serialization;

namespace WebApplicationEmpProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Email {  get; set; }

        public int DepartmentId {  get; set; }
        [JsonIgnore]
        public Department? Department { get; set; }
    }
}
