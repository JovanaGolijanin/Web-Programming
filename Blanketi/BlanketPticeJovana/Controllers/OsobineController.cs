using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BlanketPticeJovana.Controllers;

[ApiController]
[Route("[controller]")]
public class OsobineController : ControllerBase
{
    public Context Context { get; set; }

    public OsobineController(Context context)
    {
        Context = context;
    }

    [Route("DodajOsobinu")]
    [HttpPost]

    public async Task<ActionResult> DodajOsobinu([FromBody] Osobine osobina)
    {

        try
        {
            await Context.Osobine.AddAsync(osobina);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno je dodata osobina sa ID-jem: {osobina.ID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [Route("VratiOsobine")]
    [HttpGet]

    public async Task<ActionResult> VratiOsobine()
    {
        
        try
        {
            var osobine = await Context.Osobine.ToListAsync();

            return Ok(osobine);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [Route("IzmeniOsobinu/{osobinaID}")]
    [HttpPut]

    public async Task<ActionResult> IzmeniOsobinu([FromBody] Osobine osobine, int osobinaID)
    {
        if(await Context.Osobine.FindAsync(osobinaID) == null)
        {
            return BadRequest("Nije pronajdena osobina sa navedenim ID-jem");
        }

        try
        {
            var staraOsobina = await Context.Osobine.FindAsync(osobinaID);

            staraOsobina.Naziv = osobine.Naziv;
            staraOsobina.Vrednost = osobine.Vrednost;
            staraOsobina.ViseVrednosti = osobine.ViseVrednosti;

            Context.Osobine.Update(staraOsobina);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno je izmenjena osobina sa ID-jem: {osobine.ID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("IzbrisiOsobinu/{osobinaID}")]
    [HttpDelete]

    public async Task<ActionResult> IzbrisiOsobinu(int osobinaID)
    {
        if(await Context.Osobine.FindAsync(osobinaID) == null)
        {
            return BadRequest("Nije pronajdena osobina sa navedenim ID-jem");
        }

        try
        {
            var staraOsobina = await Context.Osobine.FindAsync(osobinaID);

            Context.Osobine.Remove(staraOsobina);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno je izbrisana osobina sa ID-jem: {osobinaID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
