using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.Point_TypeService
{
    public class PointTypeService:IPointTypeService
    {
        private readonly AppDBContext _context;

        public PointTypeService(AppDBContext context)
        {
            _context = context;
        }

        public async Task CreatePointTypeAsync(Point_Type point_Type)
        {
            await _context.point_types.AddAsync(point_Type);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePointTypeAsync(int id)
        {
            var point_Type = await _context.point_types.FindAsync(id);
            if (point_Type != null)
            {
                _context.point_types.Remove(point_Type);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Point_Type>> GetAllPointTypeAsync()
        {
            return await _context.point_types.ToListAsync();
        }

        public async Task<Point_Type> GetPointTypeByIdAsync(int id)
        {
            return await _context.point_types.FindAsync(id);
        }

        public async Task UpdatePointTypeAsync(Point_Type point_Type)
        {
            _context.point_types.Update(point_Type);
            await _context.SaveChangesAsync();
        }
    }
}
