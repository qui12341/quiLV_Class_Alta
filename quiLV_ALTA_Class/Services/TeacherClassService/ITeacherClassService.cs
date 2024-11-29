using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.TeacherClassService
{
    public interface ITeacherClassService
    {
        Task<IEnumerable<Teacher_CLass>> GetAllTeacherClassAsync();
        Task<Teacher_CLass> GetTeacherClassByIdAsync(int id);
        Task CreateTeacherClassAsync(Teacher_CLass teacher_CLass);
        Task UpdateTeacherClassAsync(Teacher_CLass teacher_CLass);
        Task DeleteTeacherClassAsync(int id);
    }
}
