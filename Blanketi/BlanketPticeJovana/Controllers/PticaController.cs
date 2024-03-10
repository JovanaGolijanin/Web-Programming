using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BlanketPticeJovana.Controllers;

[ApiController]
[Route("[controller]")]
public class PticaController : ControllerBase
{
 
    public Context Context { get; set; }

    public PticaController(Context context)
    {
        Context = context;
    }

    [Route("DodajPticu")]
    [HttpPost]

    public async Task<ActionResult> DodajPticu([FromBody] Ptica ptica)
    {

        if(ptica.Naziv.Length >30 || ptica.Naziv.Length<0)
        {
            return BadRequest("Los naziv!");
        }

        try
        {
            await Context.Ptice.AddAsync(ptica);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno je dodata ptica sa ID-jem: {ptica.ID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("VratiPtice")]
    [HttpGet]

    public async Task<ActionResult> VratiPtice()
    {
        
        try
        {
            var ptice = await Context.Ptice.ToListAsync();

            return Ok(ptice);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet("PreuzmiPtice/{podrucjeID}")]
    public async Task<ActionResult> PreuzmiPtice(int podrucjeID, [FromQuery]int[] osobineIDs)
    {
        try
        {
            var ptice = Context.Ptice
                   .Include(p => p.Osobine!)
                   .Include(p => p.Vidjena!)
                   .ThenInclude(p => p.Podrucje);

            // Ima više načina da se ovaj upit napiše.
            // Jedan od najjednostavnijih je da se proveri da li je broj osobina koje imaju ID
            // koji se nalazi u listi osobineIDs, isti broju elemenata tog niza
            var pSaOsob = ptice
                .Where(p => p.Osobine!.Count(p => osobineIDs.Contains(p.ID)) == osobineIDs.Count());

            // Proverava da li je ptica viđena na području koje je prosleđeno bar jednom
            var osobIPodr = await pSaOsob
                    .Where(p => p.Vidjena!
                            .Any(p => p.Podrucje!.ID == podrucjeID))
                    .ToListAsync();

            return Ok(osobIPodr.Select(p => new
            {
                p.ID,
                p.Naziv,
                p.Slika,
                BrojVidjenja = p.Vidjena!.Where(p => p.Podrucje!.ID == podrucjeID).Count()
            }).ToList());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("VratiPticu/{podrucjeID}/{osobinaID}")]
    [HttpGet]

    public async Task<ActionResult> VratiPticu(int podrucjeID, int osobinaID)
    {

        if(await Context.Podrucja.FindAsync(podrucjeID) == null )
        {
            return BadRequest("Nije pronadjeno podrucje sa navedenimID-jem!");
        }


        if(await Context.Osobine.FindAsync(osobinaID) == null)
        {
            return BadRequest("Nije pronadjena osobina sa navedenimID-jem!");
        }

        try
        {
            var vidjenePtice = await Context.Ptice
                .Include(p=> p.Vidjena)
                .ThenInclude(p=>p.Podrucje)
                .Include(p=>p.Osobine)
                .Select(q => new{
                    Naziv = q.Naziv,
                    Slika = q.Slika, 
                    ListaOsobina = q.Osobine,
                    ListaPodrucja = q.Vidjena.Select(k =>k.Podrucje)
                })
                .ToListAsync();

            

            return Ok(vidjenePtice);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("PovecajBrojVidjenja/{idPtice}/{idPodrucja}")]
    [HttpPut]

    public async Task<ActionResult> PovecajBrojVidjenja(int idPtice, int idPodrucja, [FromBody] Vidjena vidjenje)
    {

        var ptica = await Context.Ptice.FindAsync(idPtice);
        var pod = await Context.Podrucja.FindAsync(idPodrucja);

        if (ptica != null && pod != null &&
            vidjenje.Latitude >= -90 && vidjenje.Latitude <= 90 &&
            vidjenje.Longitude >= -180 && vidjenje.Longitude <= 180)
            //...)
        {
            vidjenje.Ptica = ptica;
            vidjenje.Podrucje = pod;

            await Context.Vidjenja.AddAsync(vidjenje);
            await Context.SaveChangesAsync();
            return Ok("Uspešno!");
        }
        else
        {
            return BadRequest("Nije uspešno!");
        }
    }

    [Route("IzmeniPticu/{pticaID}")]
    [HttpPut]

    public async Task<ActionResult> IzmeniPticu([FromBody] Ptica ptica, int pticaID)
    {
        if(await Context.Ptice.FindAsync(pticaID) == null)
        {
            return BadRequest("Nije pronajdena ptica sa navedenim ID-jem");
        }

        if(ptica.Naziv.Length >30 || ptica.Naziv.Length<0)
        {
            return BadRequest("Los naziv!");
        }

        try
        {
            var staraPtica = await Context.Ptice.FindAsync(pticaID);

            staraPtica.Naziv = ptica.Naziv;
            staraPtica.Slika = ptica.Slika;

            Context.Ptice.Update(staraPtica);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno je izmenjena ptica sa ID-jem: {ptica.ID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("IzbrisiPticu/{pticaID}")]
    [HttpDelete]

    public async Task<ActionResult> IzbrisiPticu(int pticaID)
    {
        if(await Context.Ptice.FindAsync(pticaID) == null)
        {
            return BadRequest("Nije pronajdena ptica sa navedenim ID-jem");
        }

        try
        {
            var staraPtica = await Context.Ptice.FindAsync(pticaID);

            Context.Ptice.Remove(staraPtica);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno je izbrisana ptica sa ID-jem: {pticaID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
