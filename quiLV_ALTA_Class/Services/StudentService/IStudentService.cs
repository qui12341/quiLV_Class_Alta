using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.StudentService
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task CreateStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
    }
}
