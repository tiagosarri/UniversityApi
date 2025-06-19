using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly UniversityContext _context;

        public StudentsController(UniversityContext context) 
            => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _context.Students.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            return student is null ? NotFound() : Ok(student);
        }

        [HttpGet("{id}/subjects")]
        public async Task<IActionResult> GetSubjects(int id)
        {
            var subjects = await _context.Students
                                         .Where(s => s.Id == id)
                                         .SelectMany(s => s.Subjects)
                                         .ToListAsync();

            return Ok(subjects);
        }
    }
}