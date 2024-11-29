using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.TeacherService
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllTeacherAsync();
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task CreateTeacherAsync(Teacher teacher);
        Task UpdateTeacherAsync(Teacher teacher);
        Task DeleteTeacherAsync(int id);
    }
}
