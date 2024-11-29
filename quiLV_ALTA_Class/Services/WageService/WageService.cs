using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.WageService
{
    public class WageService : IWageService
    {
        private readonly AppDBContext _context;

        public WageService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateWageAsync(Wage wage)
        {
            await _context.wages.AddAsync(wage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWageAsync(int id)
        {
            var wage = await _context.wages.FindAsync(id);
            if (wage != null)
            {
                _context.wages.Remove(wage);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Wage>> GetAllWageAsync()
        {
            return await _context.wages.ToListAsync();
        }

        public async Task<Wage> GetWageByIdAsync(int id)
        {
            return await _context.wages.FindAsync(id);
        }

        public async Task UpdateWageAsync(Wage wage)
        {
            _context.wages.Update(wage);
            await _context.SaveChangesAsync();
        }
    }
}
