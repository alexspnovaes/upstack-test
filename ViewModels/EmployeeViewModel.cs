using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace upstack_test.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        [JsonProperty("role_id")]
        public int RoleId { get; set; }
    }
}
