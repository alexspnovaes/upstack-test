using upstack_test.ViewModels;

namespace upstack_test.Interfaces
{
    public interface IRoleService
    {
        RoleViewModel FindRoleById(int id);
        IEnumerable<RoleViewModel> GetRoles();
        void Save(RoleViewModel role);
        IEnumerable<RoleViewModel> SearchRoleByCode(string code);
        void Update(RoleViewModel role);
    }
}
