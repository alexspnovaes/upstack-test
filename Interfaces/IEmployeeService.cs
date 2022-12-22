using upstack_test.ViewModels;

namespace upstack_test.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeViewModel> GetEmployees();
        IEnumerable<EmployeeViewModel> SearchEmployeesByName(string query);

        EmployeeViewModel FindEmployeeById(int id);
        void Save(EmployeeViewModel role);
        void Update(EmployeeViewModel role);
    }
}
