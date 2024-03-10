namespace WebTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class StadionController : ControllerBase
{
    public IspitContext Context { get; set; }

    public StadionController(IspitContext context)
    {
        Context = context;
    }

    [Route("VratiStadione")]
    [HttpGet]

    public async Task<ActionResult> VratiStadione()
    {

        
        try
        {
            return Ok(await Context.Stadion
                .Include(q=>q.Utakmice)
                .ToListAsync()); 

        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [Route("DodajStadion")]
    [HttpPost]

    public async Task<ActionResult> DodajStadion([FromBody] Stadion stadion)
    {
        if(stadion.Naziv.Length > 50 || stadion.Naziv.Length <0)
        {
            return BadRequest("Pogresan naziv!");
        }

        if(stadion.Lokacija.Length > 50 || stadion.Lokacija.Length <0)
        {
            return BadRequest("Pogresna lokacija!");
        }

        if(stadion.Kapacitet >500000 || stadion.Kapacitet<0)
        {
            return BadRequest("Pogresan kapacitet");
        }

        try
        {
            await Context.Stadion.AddAsync(stadion);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno je dodat stadion sa ID-jem : {stadion.ID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }

    }


    [Route("IzmeniStadion/{stadionID}")]
    [HttpPut]

    public async Task<ActionResult> IzmeniStadion(int stadionID, [FromBody] Stadion stadion)
    {
        if(await Context.Stadion.FindAsync(stadionID) == null)
        {
            return BadRequest($"Nije pronadjen stadion sa navedenim ID-jem: {stadionID}!");
        }

        try
        {
            var stariStadion = await Context.Stadion.FindAsync(stadionID);

            stariStadion.Naziv = stadion.Naziv;
            stariStadion.Lokacija = stadion.Lokacija;
            stariStadion.Kapacitet = stadion.Kapacitet;
            stariStadion.DatumOtvaranja = stadion.DatumOtvaranja;

            Context.Stadion.Update(stariStadion);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno je izmenjen stadion sa ID-jem:{stadionID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("ObrisiStadion/{stadionID}")]
    [HttpDelete]

    public async Task<ActionResult> ObrisiStadion(int stadionID)
    {
        if (await Context.Stadion.FindAsync(stadionID) == null)
        {
            return BadRequest("Stadion sa navedenim ID-jem ne postoji!");
        }

        try 
        {
            var stariStadion = await Context.Stadion.FindAsync(stadionID);
            Context.Stadion.Remove(stariStadion);

            await Context.SaveChangesAsync();

            return Ok($"Uspesno je izbrisan stadion sa ID-jem: {stadionID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [Route("ProsecnaPosecenost")]
    [HttpGet]

    public async Task<ActionResult> ProsecnaPosecenost()
    {
        try
        {
            var stadion = Context.Stadion.Include(p=>p.Utakmice);
            var prosek = stadion.Select(p=> new
            {
                p.ID,
                p.Naziv,
                p.Kapacitet,
                p.Lokacija,
                ProsecnaPosecenost=(int)p.Utakmice!.ToList().Average(p=>p.BrojPosetilaca)
            });

            return Ok(await prosek.ToListAsync());
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    


}
