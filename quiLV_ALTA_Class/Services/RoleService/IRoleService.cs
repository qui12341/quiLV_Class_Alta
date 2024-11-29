using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.RoleService
{
    public interface IRoleService
    {
        Task<IEnumerable<Roles>> GetAllRolesAsync();
        Task<Roles> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Roles role);
        Task UpdateRoleAsync(Roles role);
        Task DeleteRoleAsync(int id);
    }
}
