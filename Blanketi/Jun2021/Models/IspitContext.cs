namespace Models;

public class IspitContext : DbContext
{
    public IspitContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Proizvod> Proizvodi { get; set; }

    public DbSet<Sastojak> Sastojci { get; set; }

    public DbSet<Zalihe> Zalihe { get; set; }

    public DbSet<Prodavnica> Prodavnice { get; set; }

    public DbSet<Meni> Menii { get; set; }
}
