using asp.net_Proj.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp.net_Proj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                // Testira konekciju sa bazom
                var canConnect = await _context.Database.CanConnectAsync();
                
                if (canConnect)
                {
                    return Ok(new { 
                        message = "Uspešno povezan sa bazom!", 
                        database = _context.Database.GetConnectionString() 
                    });
                }
                else
                {
                    return BadRequest(new { message = "Ne mogu da se povežem sa bazom" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Greška", error = ex.Message });
            }
        }
    }
}