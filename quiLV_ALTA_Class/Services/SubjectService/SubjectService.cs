using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;
using System.Data;

namespace quiLV_ALTA_Class.Services.SubjectService
{
    public class SubjectService : ISubjectService
    {
        private readonly AppDBContext _context;

        public SubjectService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateSubjectAsync(Subject subject)
        {
            await _context.subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubjectAsync(int id)
        {
            var subject = await _context.subjects.FindAsync(id);
            if (subject != null)
            {
                _context.subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectAsync()
        {
            return await _context.subjects.ToListAsync();
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _context.subjects.FindAsync(id);
        }

        public async Task UpdateSubjectAsync(Subject subject)
        {
            _context.subjects.Update(subject);
            await _context.SaveChangesAsync();
        }
    }
}
