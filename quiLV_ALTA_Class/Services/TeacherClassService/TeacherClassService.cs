using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.TeacherClassService
{
    public class TeacherClassService : ITeacherClassService
    {
        private readonly AppDBContext _context;

        public TeacherClassService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateTeacherClassAsync(Teacher_CLass teacher_CLass)
        {
            await _context.teacher_CLasses.AddAsync(teacher_CLass);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeacherClassAsync(int id)
        {
            var teacher_CLass = await _context.teacher_CLasses.FindAsync(id);
            if (teacher_CLass != null)
            {
                _context.teacher_CLasses.Remove(teacher_CLass);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Teacher_CLass>> GetAllTeacherClassAsync()
        {
            return await _context.teacher_CLasses.ToListAsync();
        }

        public async Task<Teacher_CLass> GetTeacherClassByIdAsync(int id)
        {
            return await _context.teacher_CLasses.FindAsync(id);
        }

        public async Task UpdateTeacherClassAsync(Teacher_CLass teacher_CLass)
        {
            _context.teacher_CLasses.Update(teacher_CLass);
            await _context.SaveChangesAsync();
        }
    }
}
