using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BlanketPticeJovana.Controllers;

[ApiController]
[Route("[controller]")]
public class PodrucjeController : ControllerBase
{
    public Context Context { get; set; }

    public PodrucjeController(Context context)
    {
        Context = context;
    }

    [Route("DodajPodrucje")]
    [HttpPost]

    public async Task<ActionResult> DodajPodrucje([FromBody] Podrucje podrucje)
    {

        if(podrucje.Naziv.Length >30 || podrucje.Naziv.Length<0)
        {
            return BadRequest("Los naziv!");
        }

        try
        {
            await Context.Podrucja.AddAsync(podrucje);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno je dodato podrucje sa ID-jem: {podrucje.ID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [Route("VratiPodrucja")]
    [HttpGet]

    public async Task<ActionResult> VratiPodrucja()
    {
        
        try
        {
            //var podrucje = await Context.Podrucja.ToListAsync();

            return Ok(await Context.Podrucja
                    .Include(p=>p.Vidjenja)
                    .Select(p=> new{
                        PodrucjeID = p.ID,
                        PodrucjeNaziv = p.Naziv,
                        BrojVidjenja = p.Vidjenja.Count()
                    }).ToListAsync()
                    );
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [Route("IzmeniPodrucje/{podrucjeID}")]
    [HttpPut]

    public async Task<ActionResult> IzmeniPodrucje([FromBody] Podrucje podrucje, int podrucjeID)
    {
        if(await Context.Podrucja.FindAsync(podrucjeID) == null)
        {
            return BadRequest("Nije pronajdeno podrucje sa navedenim ID-jem");
        }

        if(podrucje.Naziv.Length >30 || podrucje.Naziv.Length<0)
        {
            return BadRequest("Los naziv!");
        }

        try
        {
            var staroPodrucje = await Context.Podrucja.FindAsync(podrucjeID);

            staroPodrucje.Naziv = podrucje.Naziv;

            Context.Podrucja.Update(staroPodrucje);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno je izmenjeno podrucje sa ID-jem: {podrucje.ID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("IzbrisiPodrucje/{podrucjeID}")]
    [HttpDelete]

    public async Task<ActionResult> IzbrisiPodrucje(int podrucjeID)
    {
        if(await Context.Podrucja.FindAsync(podrucjeID) == null)
        {
            return BadRequest("Nije pronajdeno podrucje sa navedenim ID-jem");
        }

        try
        {
            var staroPodrucje = await Context.Podrucja.FindAsync(podrucjeID);

            Context.Podrucja.Remove(staroPodrucje);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno je izbrisano podrucje sa ID-jem: {podrucjeID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
