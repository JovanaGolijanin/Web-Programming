using Merac.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TemperaturaServer.Controllers;

[ApiController]
[Route("[controller]")]
public class MeracController : ControllerBase
{
    public MeracContext Context { get; set; }

    public MeracController(MeracContext context)
    {
        Context = context;
    }

    [Route("PreuzmiSveMerace")]
    [HttpGet]
    public async Task<List<Merac.Models.Merac>> PreuzmiSveMerace()
    {
        return await Context.Meraci.ToListAsync();
    }

    [Route("DodajMerac")]
    [HttpPost]
    public async Task<IActionResult> DodajMerac([FromBody] Merac.Models.Merac merac)
    {

        try
        {
            Context.Meraci.Add(merac);
            await Context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("IzmeniMerac/{id}/{vrednost}")]
    [HttpPut]
    public async Task<IActionResult> IzmeniMerac(int id, double vrednost)
    {
        var merac = await Context.Meraci.FindAsync(id);

        if (merac != null)
        {
            if (merac.GranicaOd > vrednost || merac.GranicaDo < vrednost)
            {
                return BadRequest(new JsonResult("Vrednost nije u granicama."));
            }

            merac.TrenutnaVrednost = vrednost;
            merac.ProsecnaIzmerenaVrednost = ((merac.ProsecnaIzmerenaVrednost * merac.BrojMerenja + vrednost) / ++merac.BrojMerenja);

            if (merac.MinimalnaIzmerenaVrednost > vrednost)
            {
                merac.MinimalnaIzmerenaVrednost = vrednost;
            }
            else if (merac.MaksimalnaIzmerenaVrednost < vrednost)
            {
                merac.MaksimalnaIzmerenaVrednost = vrednost;
            }

            try
            {
                Context.Update(merac);
                await Context.SaveChangesAsync();
                return Ok(new
                {
                    merac.MinimalnaIzmerenaVrednost,
                    merac.MaksimalnaIzmerenaVrednost,
                    merac.ProsecnaIzmerenaVrednost
                });
            }
            catch (Exception e)
            {
                return BadRequest(new JsonResult(e.Message));
            }
        }
        else
        {
            return BadRequest(new JsonResult("Merač nije pronađen."));
        }
    }

    [Route("IzbrisiMerac/{id}")]
    [HttpDelete]
    public async Task<IActionResult> IzbrisiMerac(int id)
    {
        var merac = await Context.Meraci.FindAsync(id);

        if (merac != null)
        {
            try
            {
                Context.Remove(merac);
                await Context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        else
        {
            return BadRequest("Merač nije pronađen.");
        }
    }
}
