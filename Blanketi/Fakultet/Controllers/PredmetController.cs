namespace WebTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class PredmetController : ControllerBase
{
    public FakultetContext Context { get; set; }

    public PredmetController(FakultetContext context)
    {
        Context = context;
    }

    [Route("PreuzmiPredmete")]
    [HttpGet]
    public async Task<ActionResult> PreuzmiPredmete(){
        return Ok(await Context.Predmet
            .Select(p => new 
            {
                p.ID, 
                p.Naziv
            }).ToListAsync());
    }

    [Route("DodajPredmet")]
    [HttpPost]

    public async Task<ActionResult> DodajPredmet([FromBody] Predmet predmet){

        if(predmet.Naziv.Length > 50 || string.IsNullOrWhiteSpace(predmet.Naziv))
        {
            return BadRequest("Pogresan naziv!");
        }

        try
        {
            Context.Predmet.Add(predmet);
            await Context.SaveChangesAsync();
            return Ok($"Uspesno je dodat predmet sa ID-jem: {predmet.ID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
