using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.Student_ClassService
{
    public interface IStudentClassService
    {
        Task<IEnumerable<Student_Class>> GetAllStudentClassAsync();
        Task<Student_Class> GetStudentClassByIdAsync(int id);
        Task CreateStudentClassAsync(Student_Class student_Class);
        Task UpdateStudentClassAsync(Student_Class student_Class);
        Task DeleteStudentClassAsync(int id);
    }
}
