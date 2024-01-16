using SignInSystem.DTO;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface IRoleService
    {
        Task<List<Role>> GetAll();

        Task<List<Role>> GetRoleByID(int id);

        Task<List<Role>> GetRoleByName(string roleName);

        Task<Role> FindIDToResult(int id);

        Task CreateRole(RoleDTO roleDTO);

        Task EditRole(int id, RoleDTO roleDTO);

        Task DeleteRole(int id);
    }
}
