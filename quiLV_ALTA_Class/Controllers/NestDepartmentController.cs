using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.Class;
using quiLV_ALTA_Class.Services.Nest_DepartmentService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class NestDepartmentController : ControllerBase
    {
        private readonly INestDepartmentService _nestDepartmentService;
        public NestDepartmentController(INestDepartmentService nestDepartmentService)
        {
            _nestDepartmentService = nestDepartmentService;
        }
        [HttpGet]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<IEnumerable<Nest_Department>>> GetNestDepartment()
        {
            var nest_Departments = await _nestDepartmentService.GetAllNestDepartmentAsync();
            return Ok(nest_Departments);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Nest_Department>> GetNestDepartment(int id)
        {
            var nest_Department = await _nestDepartmentService.GetNestDepartmentByIdAsync(id);
            if (nest_Department == null)
            {
                return NotFound();
            }
            return Ok(nest_Department);
        }

        [HttpPost]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Nest_Department>> CreateNestDepartment(Nest_Department nest_Department)
        {
            await _nestDepartmentService.CreateNestDepartmentAsync(nest_Department);
            return CreatedAtAction(nameof(GetNestDepartment), new { id = nest_Department.Nest_Department_Id }, nest_Department);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> UpdateNestDepartment(int id, Nest_Department nest_Department)
        {
            if (id != nest_Department.Nest_Department_Id)
            {
                return BadRequest();
            }

            await _nestDepartmentService.UpdateNestDepartmentAsync(nest_Department);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> DeleteNestDepartment(int id)
        {
            await _nestDepartmentService.DeleteNestDepartmentAsync(id);
            return NoContent();
        }
    }
}
