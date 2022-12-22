using Newtonsoft.Json;
using upstack_test.Interfaces;
using upstack_test.Models;
using upstack_test.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace upstack_test.Services
{
    public class RoleService : IRoleService
    {
        private readonly string path = "data";

        public RoleViewModel FindRoleById(int id)
        {
            var result = GetRoles().Where(w => w.Id == id).FirstOrDefault();
            return result;
        }

        public IEnumerable<RoleViewModel> GetRoles()
        {
            using StreamReader r = new($"{path}/role.json");
            string json = r.ReadToEnd();
            var item = JsonConvert.DeserializeObject<Role>(json);
            var result = item?.Roles?.Select(s => new RoleViewModel
            {
                Id = s.Id,
                RoleCode = s.RoleCode,
                RoleName = s.RoleName
            });

            return result;
        }

        public void Save(RoleViewModel role)
        {
            //save the data using a repository and return ok            
        }

        public IEnumerable<RoleViewModel> SearchRoleByCode(string code)
        {
            var result = GetRoles().Where(w => w.RoleCode.ToLowerInvariant().Contains(code.ToLowerInvariant()));
            return result;
        }

        public void Update(RoleViewModel role)
        {
            //save the data using a repository and return ok or thow exception
        }
    }
}
