using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.Role;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Service
{
    public class RoleService : IRoleService
    {
        private readonly SignInSystemContext _context;

        public RoleService(SignInSystemContext context)
        {
            _context = context;
        }

        public async Task CreateRole(RoleDTO roleDTO)
        {
            Role role = new Role();
            role.RoleName = roleDTO.RoleName;

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRole(int id)
        {
            var list = _context.Roles.FirstOrDefault(r => r.RoleID == id);
            
            _context.Remove(list);
            await _context.SaveChangesAsync();
        }

        public async Task EditRole(int id, RoleDTO roleDTO)
        {
            var list = _context.Roles.FirstOrDefault(r => r.RoleID == id);

            list.RoleName = roleDTO.RoleName;

            _context.Roles.Update(list);
            await _context.SaveChangesAsync();  
        }

        public async Task<Role> FindIDToResult(int id)
        {
            var list = await _context.Roles.FindAsync(id);
            return list;
        }

        public async Task<List<Role>> GetRoleByName(string name)
        {
            var list = await _context.Roles.Where(r => r.RoleName.Trim().ToLower().Contains(name.Trim().ToLower())).ToListAsync();
            return list;
        }

        public async Task<List<Role>> GetAll()
        {
            var list = await _context.Roles.ToListAsync();
            return list;
        }

        public async Task<List<Role>> GetRoleByID(int id)
        {
            var list = await _context.Roles.Where(r => r.RoleID == id).ToListAsync();
            return list;
        }
    }
}
