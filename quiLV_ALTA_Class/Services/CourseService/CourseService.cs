using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly AppDBContext _context;

        public CourseService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateCourseAsync(Course course)
        {
            await _context.courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _context.courses.FindAsync(id);
            if (course != null)
            {
                _context.courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Course>> GetAllCourseAsync()
        {
            return await _context.courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.courses.FindAsync(id);
        }

        public async Task UpdateCourseAsync(Course course)
        {
            _context.courses.Update(course);
            await _context.SaveChangesAsync();
        }
    }
}
