using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.Class
{
    public class ClassService : IClassService
    {
        private readonly AppDBContext _context;

        public ClassService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateClassAsync(Classes classes)
        {
            await _context.classes.AddAsync(classes);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClassAsync(int id)
        {
            var classes = await _context.classes.FindAsync(id);
            if (classes != null)
            {
                _context.classes.Remove(classes);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Classes>> GetAllClassAsync()
        {
            return await _context.classes.ToListAsync();
        }

        public async Task<Classes> GetClassByIdAsync(int id)
        {
            return await _context.classes.FindAsync(id);
        }

        public async Task UpdateClassAsync(Classes classes)
        {
            _context.classes.Update(classes);
            await _context.SaveChangesAsync();
        }
    }
}
