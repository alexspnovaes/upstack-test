using Newtonsoft.Json;

namespace upstack_test.Models
{
    public class Employee
    {
        public EmployeeData[]? Employees {get;set;}
    }

    public class EmployeeData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        [JsonProperty("role_id")]
        public int RoleId { get; set; }
    }
}
