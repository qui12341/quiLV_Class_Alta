using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly AppDBContext _context;

        public RoleService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateRoleAsync(Roles role)
        {
            await _context.role.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _context.role.FindAsync(id);
            if (role != null)
            {
                _context.role.Remove(role);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Roles>> GetAllRolesAsync()
        {
            return await _context.role.ToListAsync();
        }

        public async Task<Roles> GetRoleByIdAsync(int id)
        {
            return await _context.role.FindAsync(id);
        }

        public async Task UpdateRoleAsync(Roles role)
        {
            _context.role.Update(role);
            await _context.SaveChangesAsync();
        }
    }
}
