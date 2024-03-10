using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace vezbe3.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    
    public FakultetContext Context {get;set;}

    public StudentController(FakultetContext context)
    {
       Context = context;
    }

    [Route("Preuzmi")]
    [HttpGet]
    public async Task<ActionResult> Preuzmi([FromQuery] int [] rokIDs)
    {
        var studenti = Context.Studenti
          .Include(p => p.StudentPredmet)
            .ThenInclude(p => p.Predmet)
            .Include(p => p.StudentPredmet)
            .ThenInclude(p => p.IspitniRok);

        /* var student = studenti.Where(p =>p.Indeks == 19875).FirstOrDefault();
        await Context.Entry(student).Collection(p => p.StudentPredmet).LoadAsync();

        foreach (var s in student.StudentPredmet)
        {
            await Context.Entry(s).Reference(q => q.IspitniRok).LoadAsync();
            await Context.Entry(s).Reference(q => q.Predmet).LoadAsync();
            
        } */

        var student = await studenti.ToListAsync();

        return Ok
        (
            student.Select(p =>
            new
            {
                Indeks =p.Indeks,
                Ime = p.Ime,
                Prezime = p.Prezime,
                Predmeti = p.StudentPredmet
                    .Where(q => rokIDs.Contains(q.IspitniRok.ID))
                    .Select(q =>
                    new
                    {
                        Predmet = q.Predmet.Naziv,
                        GodinaPredmeta = q.Predmet.Godina,
                        IspitniRok = q.IspitniRok.Naziv,
                        Ocena = q.Ocena
                    })
            }).ToList()
        );
    }


    ////
    [Route("StudentiPretraga/{rokovi}/{predmetID}")]
    [HttpGet]
    public async Task<ActionResult> StudentiPretraga(string rokovi, int predmetID)
    {

        var rokIds = rokovi.Split('a')
        .Where(x=> int.TryParse(x, out _))
        .Select(int.Parse)
        .ToList();

        var studentiPoPredmetu = Context.StudentPredmeti
            .Include(p => p.Student)
            .Include(p => p.IspitniRok)
            .Include(p => p.Predmet)
            .Where(p=>p.Predmet.ID==predmetID
            && rokIds.Contains(p.IspitniRok.ID));

        

        var student = await studentiPoPredmetu.ToListAsync();

        return Ok
        (
            student.Select(p =>
            new
            {
                Index=p.Student.Indeks,
                Ime = p.Student.Ime,
                Prezime = p.Student.Prezime,
                Predmet = p.Predmet.Naziv,
                Rok = p.IspitniRok.Naziv,
                Ocena = p.Ocena
            }).ToList()
        );
    }

    ////

    [Route("StudentiPretragaFromBody/{predmetID}")]
    [HttpPut]
    public async Task<ActionResult> StudentiPretragaFromBody([FromRoute]int predmetID, [FromBody]int[] rokIds)
    {

       
        var studentiPoPredmetu = Context.StudentPredmeti
            .Include(p => p.Student)
            .Include(p => p.IspitniRok)
            .Include(p => p.Predmet)
            .Where(p=>p.Predmet.ID==predmetID
            && rokIds.Contains(p.IspitniRok.ID));

        

        var student = await studentiPoPredmetu.ToListAsync();

        return Ok
        (
            student.Select(p =>
            new
            {
                Index=p.Student.Indeks,
                Ime = p.Student.Ime,
                Prezime = p.Student.Prezime,
                Predmet = p.Predmet.Naziv,
                Rok = p.IspitniRok.Naziv,
                Ocena = p.Ocena
            }).ToList()
        );
    }

    ////


    [EnableCors("CORS")]
    [Route("DodajStudenta")]
    [HttpPost]
    public async Task<ActionResult> DodajStudenta([FromBody] Student student)
    {
        if (student.Indeks <10000 || student.Indeks >20000)
        {
            return BadRequest("Pogresan Indeks");
        }

        if (string.IsNullOrWhiteSpace(student.Ime) || student.Ime.Length > 50)
        {
            return BadRequest("Pogresno ime!");
        }

        if (string.IsNullOrWhiteSpace(student.Prezime) || student.Prezime.Length > 50)
        {
            return BadRequest("Pogresno prezime!");
        }

        try
        {
            Context.Studenti.Add(student);
            await Context.SaveChangesAsync();
            return Ok($"Student je dodat! ID je: {student.ID}");

        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }

        
    }

    [Route("PromeniStudenta/{indeks}/{ime}/{prezime}")]
    [HttpPut]
    public async Task<ActionResult> Promeni(int indeks, string ime, string prezime)
    {
        if(indeks < 10000 || indeks > 20000)
        {
            return BadRequest("Pogresan indeks!");
        }

        try
        {
            var student = Context.Studenti.Where(p => p.Indeks == indeks).FirstOrDefault();
            
            if(student != null)
            {
                student.Ime = ime;
                student.Prezime = prezime;

                await Context.SaveChangesAsync();
                return Ok($"Uspesno promenjem student! ID {student.ID}");
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

    [Route("ProenaFromBody")]
    [HttpPut]
    public async Task<ActionResult> PromeniBody([FromBody] Student student)
    {
        if(student.ID <= 0)
        {
            return BadRequest("Pogresan Id!");
        }

        // ... ostale provere, indeks, ime , prezime

        try
        {
            /* var studentZaPromenu = await Context.Studenti.FindAsync(student.ID);
            studentZaPromenu.Indeks = student.Indeks;
            studentZaPromenu.Ime = student.Ime;
            studentZaPromenu.Prezime = student.Prezime; */

            Context.Studenti.Update(student);

            await Context.SaveChangesAsync();
            return Ok($"Student sa Id-jem: {student.ID} je uspesno izemenjen!");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("izbrisatiStudenta/{id}")]
    [HttpDelete]
    public async Task<ActionResult> Izbrisati(int id)
    {
        if(id <= 0)
        {
            return BadRequest("Pogresan ID!");
        }

        try
        {
            var student = await Context.Studenti.FindAsync(id);
            int indeks = student.Indeks;
            Context.Studenti.Remove(student);
            await Context.SaveChangesAsync();
            return Ok($"Uspesno izbrisan student sa indeksom: {indeks}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
   
}
