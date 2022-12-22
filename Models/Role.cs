using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace upstack_test.Models
{
    public class Role
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public RoleData[]? Roles {get;set;}
    }

    public class RoleData
    {
        public int Id { get; set; }
        [JsonProperty("role_name")]
        public string RoleName { get; set; }
        [JsonProperty("role_code")]
        public string RoleCode { get; set; }
    }
}
