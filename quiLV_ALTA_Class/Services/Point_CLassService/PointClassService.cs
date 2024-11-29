using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;
using System.Data;

namespace quiLV_ALTA_Class.Services.Point_CLassService
{
    public class PointClassService : IPointClassService
    {
        private readonly AppDBContext _context;

        public PointClassService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreatePointClassAsync(Point_Class point_Class)
        {
            await _context.point_Classes.AddAsync(point_Class);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePointClassAsync(int id)
        {
            var point_Class = await _context.point_Classes.FindAsync(id);
            if (point_Class != null)
            {
                _context.point_Classes.Remove(point_Class);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Point_Class>> GetAllPointClassAsync()
        {
            return await _context.point_Classes.ToListAsync();
        }

        public async Task<Point_Class> GetPointClassByIdAsync(int id)
        {
            return await _context.point_Classes.FindAsync(id);
        }

        public async Task UpdatePointClassAsync(Point_Class point_Class)
        {
            _context.point_Classes.Update(point_Class);
            await _context.SaveChangesAsync();
        }
    }
}
