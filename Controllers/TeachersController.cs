using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly UniversityContext _context;

        public TeachersController(UniversityContext context)
            => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _context.Teachers.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            return teacher is null ? NotFound() : Ok(teacher);
        }

        [HttpGet("{id}/subjects")]
        public async Task<IActionResult> GetSubjects(int id)
        {
            var subjects = await _context.Subjects
                                         .Where(s => s.TeacherId == id)
                                         .ToListAsync();

            return Ok(subjects);
        }
    }
}