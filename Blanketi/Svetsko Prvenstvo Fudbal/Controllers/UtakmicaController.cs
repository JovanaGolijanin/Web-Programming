namespace WebTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class UtakmicaController : ControllerBase
{
    public IspitContext Context { get; set; }

    public UtakmicaController(IspitContext context)
    {
        Context = context;
    }


    [Route("VratiUtakmice")]
    [HttpGet]
    
    public async Task<ActionResult> VratiUtakmice()
    {
        try
        {
            return Ok(await
                Context.Utakmica
                .Select(p=> new
                {
                    p.ID,
                    p.BrojPosetilaca,
                    p.PrviTim,
                    p.PrviRezultat,
                    p.DrugiTim,
                    p.DrugiRezultat
                }).ToListAsync()
            );

        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    
    [Route("DodajUtakmicu/{prviTimID}/{drugiTimID}"
    + "/{stadionID}/{prviRezultat}/{drugiRezultat}/{posecenost}")]
    [HttpPost]

    public async Task<ActionResult> DodajUtakmicu(
        int prviTimID,
        int drugiTimID,
        int stadionID,
        int prviRezultat,
        int drugiRezultat,
        int posecenost
    )
    {
       var utakmica = new Utakmica
       {
            BrojPosetilaca = posecenost,
            PrviRezultat= prviRezultat,
            DrugiRezultat = drugiRezultat
       };

        var prviTim = await Context.Tim.FindAsync(prviTimID);
        var drugiTim = await Context.Tim.FindAsync(drugiTimID);
        var stadion = await Context.Stadion.FindAsync(stadionID);

        if(prviTim != null && drugiTim !=null && stadion != null 
                && utakmica.BrojPosetilaca <= stadion.Kapacitet)
        {
            utakmica.PrviTim = prviTim;
            utakmica.DrugiTim = drugiTim;
            utakmica.Stadion=stadion;

        }

        try
        {
            await Context.Utakmica.AddAsync(utakmica);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno dodata utakmica sa ID-jem: {utakmica.ID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [Route("IzmeniUtakmicu/{utakmicaID}")]
    [HttpPut]

    public async Task<ActionResult> IzmeniUtakmicu([FromBody] Utakmica utakmica, int utakmicaID)
    {

        if( await Context.Utakmica.FindAsync(utakmicaID) == null)
        {
            return BadRequest("Nije pronadjena utakmica sa navedeim ID-jem!");
        }

        try
        {

            var staraUtakmica = await Context.Utakmica.FindAsync(utakmicaID);

            staraUtakmica.BrojPosetilaca = utakmica.BrojPosetilaca;
            staraUtakmica.PrviTim = utakmica.PrviTim;
            staraUtakmica.PrviRezultat = utakmica.PrviRezultat;
            staraUtakmica.DrugiTim = utakmica.DrugiTim;
            staraUtakmica.DrugiRezultat = utakmica.DrugiRezultat;

            Context.Utakmica.Update(staraUtakmica);
            await Context.SaveChangesAsync();


            return Ok($"Uspesno je izmenjena utakmica sa ID-jem: {utakmicaID}");

        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("IzbrisiUtakmicu/{utakmicaID}")]
    [HttpDelete]

    public async Task<ActionResult> ObrisiUtakmicu(int utakmicaID)
    {
        if (await Context.Utakmica.FindAsync(utakmicaID)==null)
        {
            return BadRequest("Nije pronadjena utakmica sa navedenim ID-jem!");
        }

        try
        {
            var staraUtakmica = await Context.Utakmica.FindAsync(utakmicaID);

            Context.Utakmica.Remove(staraUtakmica);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno je izbrisana utakmica sa ID-jem: {utakmicaID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
