using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.CourseService
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCourseAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task CreateCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int id);
    }
}
