namespace WebTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class IspitController : ControllerBase
{
    public IspitContext Context { get; set; }

    public IspitController(IspitContext context)
    {
        Context = context;
    }

    [Route("DodajSastojak")]
    [HttpPut]
    public async Task<ActionResult> DodajSastojak([FromBody] Sastojak sastojak)
    {
        try{

           Context.Sastojci.Add(sastojak);
           await Context.SaveChangesAsync();
            return Ok($"Uspesno je dodat sastojak sa id-jem: {sastojak.ID}");

        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }

    [Route("PreuzmiSastojke")]
    [HttpGet]
    public async Task<ActionResult> PreuzmiSastojke()
    {

        try
        {
            return Ok(await Context.Sastojci
            .Select(p=> new{
                p.ID, 
                p.Naziv
            }).ToListAsync());

        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("IzmeniSastojak/{naziv}")]
    [HttpPut]
    public async Task<ActionResult> IzmeniSastojak(string naziv)
    {
        try
        {
            var s = Context.Sastojci.Where(p => p.Naziv==naziv).FirstOrDefault();

            if(s != null){
                s.Naziv=naziv;
            }
            else{
                return BadRequest("Nije pronadjen sastojak sa navedenim nazivom!");
            }

            await Context.SaveChangesAsync();
            return Ok("Uspesno je izmenjem Sastojak");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }

    }
}
