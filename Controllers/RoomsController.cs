using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly UniversityContext _context;

        public RoomsController(UniversityContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _context.Rooms.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            return room is null ? NotFound() : Ok(room);
        }
    }
}