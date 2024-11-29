using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDBContext _context;

        public TeacherService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateTeacherAsync(Teacher teacher)
        {
            await _context.teacher.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeacherAsync(int id)
        {
            var teacher = await _context.teacher.FindAsync(id);
            if (teacher != null)
            {
                _context.teacher.Remove(teacher);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Teacher>> GetAllTeacherAsync()
        {
            return await _context.teacher.ToListAsync();
        }

        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            return await _context.teacher.FindAsync(id);
        }

        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            _context.teacher.Update(teacher);
            await _context.SaveChangesAsync();
        }
    }
}
