using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace WebTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    public FakultetContext Context { get; set; }

    public StudentController(FakultetContext context)
    {
        Context = context;
    }

   [Route("PreuzmiStudente")]
   [HttpGet]
   public async Task<ActionResult> PreuzmiStudente([FromQuery] int [] rokIDs, [FromQuery] int predmetID)
   {

        var studentiPoPredmetu = Context.Spoj
            .Include(p => p.Studenti)
            .Include(p => p.IspitniRokovi)
            .Include(p => p.Predmeti)
            .Where(p=>p.Predmeti.ID==predmetID
            && rokIDs.Contains(p.IspitniRokovi.ID));

        var student = await studentiPoPredmetu.ToListAsync();

        return Ok
        (
            student.Select(p =>
            new
            {
                Index=p.Studenti.Index,
                Ime = p.Studenti.Ime,
                Prezime = p.Studenti.Prezime,
                Predmet = p.Predmeti.Naziv,
                Rok = p.IspitniRokovi.Naziv,
                Ocena = p.Ocena
            }).ToList()
        );
   }


   [Route("DodajStudenta")]
   [HttpPost]

   public async Task<ActionResult> DodajStudenta([FromBody] Student student)
   {
        if(student.Index < 14000 || student.Index > 19000)
        {
            return BadRequest("Pogresan opseg indeksa!");
        }

        if(string.IsNullOrWhiteSpace(student.Ime) || student.Ime.Length > 50 )
        {
            return BadRequest("Pogresno ime");
        }

        if(string.IsNullOrWhiteSpace(student.Prezime) || student.Prezime.Length > 50 )
        {
            return BadRequest("Pogresno prezime");
        }

        try
        {
            Context.Student.Add(student);
            await Context.SaveChangesAsync();   
            return Ok($"Uspresno je dodat student sa ID-jem:{student.ID}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
   }
    
    [Route("PromeniStudenta/{indeks}/{ime}/{prezime}")]
    [HttpPut]

    public async Task<ActionResult> PromeniStudenta(int indeks, string ime, string prezime)
    {
        if(indeks < 14000 || indeks > 19000)
        {
            return BadRequest("Pogresan indeks");
        }

        try
        {
            var student = Context.Student
                .Where(p => p.Index == indeks).FirstOrDefault();

            if(student != null)
            {
                student.Ime = ime;
                student.Prezime = prezime;

                await Context.SaveChangesAsync();
                return Ok($"Izmenjen je student sa ID-jem: {student.ID}");
            }
            else
            {
                return BadRequest("Student nije pronadjen!");
            }

            
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
[Route("PromenaFromBody")]
[HttpPut]

public async Task<ActionResult> PromeniStudenta([FromBody] Student student)
{
    if(student.ID <0)
    {
        return BadRequest("Pogresan indeks!");
    }

    try
    {
        var studentZaPromenu = await Context.Student.FindAsync(student.ID);
        studentZaPromenu.Index = student.Index;
        studentZaPromenu.Ime = student.Ime;
        studentZaPromenu.Prezime = student.Prezime;

        /* Context.Student.Update(student);*/
        await Context.SaveChangesAsync(); 
        return Ok($"Student sa ID-jem: {studentZaPromenu.ID} je uspesno promenjen");

    }
    catch(Exception e)
    {
        return BadRequest(e.Message);
    }
}

[Route("IzbrisiStudenta/{id}")]
[HttpDelete]

public async Task<ActionResult> IzbrisiStudenta(int id)
{
    if(id <= 0)
    {
        return BadRequest("Pogresan ID!");
    }

    try
    {
        var studentZaBrisanje = await Context.Student.FindAsync(id);
        int indeks = studentZaBrisanje.Index;
        Context.Student.Remove(studentZaBrisanje);
        await Context.SaveChangesAsync();
        return Ok($"Uspesno je izbrisan student sa indeksom {indeks}");

    }
    catch(Exception e)
    {
        return BadRequest(e.Message);
    }
}

}
