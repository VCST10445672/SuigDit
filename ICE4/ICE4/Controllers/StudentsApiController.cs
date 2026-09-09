using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ICE4.Data;
using ICE4.Models;

namespace ICE4.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();//Selct * from students
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var students = await _context.Students.FirstOrDefaultAsync(r=>r.StudentId==id);//Selct * from students
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }
    }
}
