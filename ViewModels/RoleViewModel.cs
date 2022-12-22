using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace upstack_test.ViewModels
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        [JsonProperty("role_name")]
        public string RoleName { get; set; }
        [JsonProperty("role_code")]
        public string RoleCode { get; set; }
    }
}
