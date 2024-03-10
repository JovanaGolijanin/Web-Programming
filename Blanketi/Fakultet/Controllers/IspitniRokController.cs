namespace WebTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class IspitniRokController : ControllerBase
{
    public FakultetContext Context { get; set; }

    public IspitniRokController(FakultetContext context)
    {
        Context = context;
    }

    [Route("PreuzmiRokove")]
    [HttpGet]
    public async Task<ActionResult> PreuzmiRokove(){
        return Ok(await Context.IspitniRok
            .Select(p => new 
            {
                p.ID, 
                p.Naziv
            }).ToListAsync());
    }

  
    [Route("DodajIspitniRok")]
    [HttpPost]

    public async Task<ActionResult> DodajIspitniRok([FromBody] IspitniRok ispitniRok){

        if(ispitniRok.Naziv.Length > 50 || string.IsNullOrWhiteSpace(ispitniRok.Naziv))
        {
            return BadRequest("Pogresan naziv");
        }

        try
        {
            Context.IspitniRok.Add(ispitniRok);
            await Context.SaveChangesAsync();
            return Ok($"Uspesno je dodat ispitni rok sa ID-jem: {ispitniRok.ID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
