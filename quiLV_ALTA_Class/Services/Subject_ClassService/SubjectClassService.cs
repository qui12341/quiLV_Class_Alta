using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.Subject_ClassService
{
    public class SubjectClassService : ISubjectClassService
    {
        private readonly AppDBContext _context;

        public SubjectClassService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateSubjectClassAsync(Subject_Class subject_Class)
        {
            await _context.subject_Classes.AddAsync(subject_Class);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubjectClassAsync(int id)
        {
            var subject_Class = await _context.subject_Classes.FindAsync(id);
            if (subject_Class != null)
            {
                _context.subject_Classes.Remove(subject_Class);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Subject_Class>> GetAllSubjectClassAsync()
        {
            return await _context.subject_Classes.ToListAsync();
        }

        public async Task<Subject_Class> GetSubjectClassByIdAsync(int id)
        {
            return await _context.subject_Classes.FindAsync(id);
        }

        public async Task UpdateSubjectClassAsync(Subject_Class subject_Class)
        {
            _context.subject_Classes.Update(subject_Class);
            await _context.SaveChangesAsync();
        }
    }
}
