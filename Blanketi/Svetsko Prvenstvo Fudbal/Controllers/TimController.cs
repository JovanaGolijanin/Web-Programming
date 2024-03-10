namespace WebTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class TimController : ControllerBase
{
    public IspitContext Context { get; set; }

    public TimController(IspitContext context)
    {
        Context = context;
    }

   
[Route("VratiTim")]
[HttpGet]

public async Task<ActionResult> VratiTim()
{
    try
    {
        return Ok(await 
            Context.Tim
            .ToListAsync()

        );

    }
    catch(Exception e)
    {
        return BadRequest(e.Message);
    }
}

    [Route("DodajTim")]
    [HttpPost]

    public async Task<ActionResult> DodajTim([FromBody] Tim tim)
    {
        if(tim.Naziv.Length < 0 || tim.Naziv.Length>50)
        {
            return BadRequest("Pogresan naziv!");
        }

        try
        {
            await Context.Tim.AddAsync(tim);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno dodat tim sa ID-jem: {tim.ID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [Route("IzmeniTim/{timID}")]
    [HttpPut]

    public async Task<ActionResult> IzmeniTim([FromBody] Tim tim, int timID)
    {
        if(await Context.Tim.FindAsync(timID) == null)
        {
            return BadRequest("Tim sa naveden ID-jem ne postoji!");
        }
        
        try
        {
            var stariTim = await Context.Tim.FindAsync(timID);

            stariTim.Naziv = tim.Naziv;
            stariTim.URLSlike = tim.URLSlike;
            stariTim.UtakmicePrvogTima = tim.UtakmicePrvogTima;
            stariTim.UtakmiceDrugogTima = tim.UtakmiceDrugogTima;

            Context.Tim.Update(stariTim);
            await Context.SaveChangesAsync();

            return Ok($"Uspresno je izmenjen tim sa ID-jem: {timID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("IzbrisiTim/{timID}")]
    [HttpDelete]

    public async Task<ActionResult> ObrisiTim(int timID)
    {
        if (await Context.Tim.FindAsync(timID)==null)
        {
            return BadRequest("Nije pronadjen tim sa navedenim ID-jem!");
        }

        try
        {
            var stariTim = await Context.Tim.FindAsync(timID);

            Context.Tim.Remove(stariTim);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno je izbrisan tim sa ID-jem: {timID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
