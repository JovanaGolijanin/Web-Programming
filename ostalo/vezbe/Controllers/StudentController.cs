using Microsoft.AspNetCore.Mvc;

namespace vezbe.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<StudentController> _logger;

    public StudentController()
    {
      
    }

    [Route("PreuzmiStudenta/{id} ")]
    [HttpGet]
    public async Task<ActionResult> PreuzmiStudenta(int id)
    {

        if(id != null)
        {
            if(id < 15000)
            {
                return BadRequest("Broj indeksa premali");
            }
            else
            {
                return Ok(id);
            }
        }
        else
        {
            return StatusCode(404, "Student Not Found");
        }
        
        
    }
}
