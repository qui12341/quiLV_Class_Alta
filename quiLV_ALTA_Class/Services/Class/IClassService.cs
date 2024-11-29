using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.Class
{
    public interface IClassService
    {
        Task<IEnumerable<Classes>> GetAllClassAsync();
        Task<Classes> GetClassByIdAsync(int id);
        Task CreateClassAsync(Classes classes);
        Task UpdateClassAsync(Classes classes);
        Task DeleteClassAsync(int id);
    }
}
