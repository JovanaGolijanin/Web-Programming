using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class Context : DbContext
{
    public DbSet<Osobine> Osobine { get; set; }

    public DbSet<Podrucje> Podrucja { get; set; }

    public DbSet<Ptica> Ptice { get; set; }

    public DbSet<Vidjena> Vidjenja { get; set; }

    public DbSet<NepoznataPtica> NepoznataPtica { get; set; }

    public Context(DbContextOptions options) : base(options)
    {

    }

}

