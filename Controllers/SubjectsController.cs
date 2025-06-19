using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly UniversityContext _context;

        public SubjectsController(UniversityContext context)
            => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _context.Subjects.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            return subject is null ? NotFound() : Ok(subject);
        }

        [HttpGet("{id}/teachers")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var teacher = await _context.Subjects
                                        .Include(s => s.Teacher)
                                        .Where(s => s.Id == id)
                                        .Select(s => s.Teacher)
                                        .FirstOrDefaultAsync();

            return teacher is null ? NotFound() : Ok(teacher);
        }

        [HttpGet("{id}/room")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var room = await _context.Subjects
                                     .Include(s => s.Room)
                                     .Where(s => s.Id == id)
                                     .Select(s => s.Room)
                                     .FirstOrDefaultAsync();

            return room is null ? NotFound() : Ok(room);
        }

        [HttpGet("{id}/students")]
        public async Task<IActionResult> GetStudents(int id)
        {
            var students = await _context.Subjects
                                         .Where(s => s.Id == id)
                                         .SelectMany(s => s.Students)
                                         .ToListAsync();

            return Ok(students);
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var result = await _context.Subjects
                                       .Where(s => s.Id == id)
                                       .Include(s => s.Teacher)
                                       .Include(s => s.Room)
                                       .Include(s => s.Students)
                                       .Select(s => new
                                       {
                                           subject = new { s.Id, s.Name },
                                           room = new { s.Room.Id, s.Room.Name },
                                           teacher = new { s.Teacher.Id, s.Teacher.Name },
                                           students = s.Students.Select(st => new { st.Id, st.Name })
                                       })
                                       .FirstOrDefaultAsync();

            return result is null ? NotFound() : Ok(result);
        }
    }
}