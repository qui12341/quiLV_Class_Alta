using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.Nest_DepartmentService
{
    public interface INestDepartmentService
    {
        Task<IEnumerable<Nest_Department>> GetAllNestDepartmentAsync();
        Task<Nest_Department> GetNestDepartmentByIdAsync(int id);
        Task CreateNestDepartmentAsync(Nest_Department nest_Department);
        Task UpdateNestDepartmentAsync(Nest_Department nest_Department);
        Task DeleteNestDepartmentAsync(int id);
    }
}
