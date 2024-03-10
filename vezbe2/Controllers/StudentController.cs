using Microsoft.AspNetCore.Mvc;

namespace termin2.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{


    public StudentController()
    {
       
    }

    [Route("PreuzmiStudenta/{id}")]
    [HttpGet]
    public async Task<ActionResult> PreuzmiStudenta(int? id)
    {
        await Task.Run(async () =>
        {
            await Task.Delay(5000);
        });

        if(id != null)
        {
            if(id <15000)
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
