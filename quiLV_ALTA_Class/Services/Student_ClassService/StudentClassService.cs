using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;
using System.Data;

namespace quiLV_ALTA_Class.Services.Student_ClassService
{
    public class StudentClassService : IStudentClassService
    {
        private readonly AppDBContext _context;

        public StudentClassService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateStudentClassAsync(Student_Class student_Class)
        {
            await _context.student_Classes.AddAsync(student_Class);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentClassAsync(int id)
        {
            var student_Class = await _context.student_Classes.FindAsync(id);
            if (student_Class != null)
            {
                _context.student_Classes.Remove(student_Class);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student_Class>> GetAllStudentClassAsync()
        {
            return await _context.student_Classes.ToListAsync();
        }

        public async Task<Student_Class> GetStudentClassByIdAsync(int id)
        {
            return await _context.student_Classes.FindAsync(id);
        }

        public async Task UpdateStudentClassAsync(Student_Class student_Class)
        {
            _context.student_Classes.Update(student_Class);
            await _context.SaveChangesAsync();
        }
    }
}
