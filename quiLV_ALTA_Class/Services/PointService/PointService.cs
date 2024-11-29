using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.PointService
{
    public class PointService : IPointService
    {
        private readonly AppDBContext _context;

        public PointService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreatePointAsync(Point point)
        {
            await _context.points.AddAsync(point);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePointAsync(int id)
        {
            var point = await _context.points.FindAsync(id);
            if (point != null)
            {
                _context.points.Remove(point);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Point>> GetAllPointAsync()
        {
            return await _context.points.ToListAsync();
        }

        public async Task<Point> GetPointByIdAsync(int id)
        {
            return await _context.points.FindAsync(id);
        }

        public async Task UpdatePointAsync(Point point)
        {
            _context.points.Update(point);
            await _context.SaveChangesAsync();
        }
    }
}
