using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.Class;
using System.Data;

namespace quiLV_ALTA_Class.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly AppDBContext _context;

        public StudentService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateStudentAsync(Student student)
        {
            await _context.student.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _context.student.FindAsync(id);
            if (student != null)
            {
                _context.student.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            return await _context.student.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.student.FindAsync(id);

        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.student.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
