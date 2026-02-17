using asp.net_Proj.Data;
using asp.net_Proj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp.net_Proj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Student - Vrati sve studente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var students = await _context.Student.ToListAsync();
            return Ok(students);
        }

        // GET: api/Student/5 - Vrati studenta po ID-u
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var student = await _context.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound(new { message = "Student sa tim ID-em ne postoji" });
            }

            return Ok(student);
        }

        // POST: api/Student - Dodaj novog studenta
        [HttpPost("DodajStudenta")]
        public async Task<ActionResult<Student>> Create(Student student)
        {
            var sstudent = new Student
            {
             FirstName = student.FirstName,
             LastName = student.LastName
            };

            _context.Student.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        // PUT: api/Student/5 - Ažuriraj studenta
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest(new { message = "ID se ne poklapa" });
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Student.AnyAsync(s => s.Id == id))
                {
                    return NotFound(new { message = "Student ne postoji" });
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Student/5 - Obriši studenta
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound(new { message = "Student ne postoji" });
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}