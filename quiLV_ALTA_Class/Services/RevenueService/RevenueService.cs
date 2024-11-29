using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.RevenueService
{
    public class RevenueService : IRevenueService
    {
        private readonly AppDBContext _context;

        public RevenueService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateRevenueAsync(Revenue revenues)
        {
            await _context.revenue.AddAsync(revenues);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRevenueAsync(int id)
        {
            var revenues = await _context.revenue.FindAsync(id);
            if (revenues != null)
            {
                _context.revenue.Remove(revenues);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Revenue>> GetAllRevenueAsync()
        {
            return await _context.revenue.ToListAsync();
        }

        public async Task<Revenue> GetRevenueByIdAsync(int id)
        {
            return await _context.revenue.FindAsync(id);
        }

        public async Task UpdateRevenueAsync(Revenue revenues)
        {
            _context.revenue.Update(revenues);
            await _context.SaveChangesAsync();
        }
    }
}
