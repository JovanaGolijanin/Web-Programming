using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace vezbe3.Controllers;

[ApiController]
[Route("[controller]")]
public class PredmetController : ControllerBase
{
    
    public FakultetContext Context {get;set;}

    public PredmetController(FakultetContext context)
    {
       Context = context;
    }

    [Route("PreuzmiPredmete")]
    [HttpGet]
    public async Task<ActionResult> Preuzmi()
    {
        return Ok(await Context.Predmeti
        .Select(p => new { p.ID, p.Naziv}).ToListAsync());
    }
}