using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;
using System.Data;

namespace quiLV_ALTA_Class.Services.Nest_DepartmentService
{
    public class NestDepartmentService : INestDepartmentService
    {
        private readonly AppDBContext _context;

        public NestDepartmentService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateNestDepartmentAsync(Nest_Department nest_Department)
        {
            await _context.nest_Departments.AddAsync(nest_Department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNestDepartmentAsync(int id)
        {
            var nest_Department = await _context.nest_Departments.FindAsync(id);
            if (nest_Department != null)
            {
                _context.nest_Departments.Remove(nest_Department);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Nest_Department>> GetAllNestDepartmentAsync()
        {
            return await _context.nest_Departments.ToListAsync();
        }

        public async Task<Nest_Department> GetNestDepartmentByIdAsync(int id)
        {
            return await _context.nest_Departments.FindAsync(id);
        }

        public async Task UpdateNestDepartmentAsync(Nest_Department nest_Department)
        {
            _context.nest_Departments.Update(nest_Department);
            await _context.SaveChangesAsync();
        }
    }
}
