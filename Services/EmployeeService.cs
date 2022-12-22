using Newtonsoft.Json;
using upstack_test.Interfaces;
using upstack_test.Models;
using upstack_test.ViewModels;

namespace upstack_test.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly string path = "data";
        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            using StreamReader r = new($"{path}/employee.json");
            string json = r.ReadToEnd();
            var item = JsonConvert.DeserializeObject<Employee>(json);
            var result = item?.Employees?.Select(s => new EmployeeViewModel
            {
                Id = s.Id,
                Email = s.Email,
                Name = s.Name,
                UserName = s.UserName,
                RoleId = s.RoleId
            });

            return result;
        }

        public IEnumerable<EmployeeViewModel> SearchEmployeesByName(string query)
        {
            var result = GetEmployees().Where(w => w.Name.ToLowerInvariant().Contains(query.ToLowerInvariant()));
            return result;
        }

        public EmployeeViewModel FindEmployeeById(int id)
        {
            var result = GetEmployees().Where(w => w.Id == id).FirstOrDefault();
            return result;
        }

        public void Save(EmployeeViewModel role)
        {
            //save the data using a repository and return ok            
        }


        public void Update(EmployeeViewModel role)
        {
            //save the data using a repository and return ok or thow exception
        }
    }
}
