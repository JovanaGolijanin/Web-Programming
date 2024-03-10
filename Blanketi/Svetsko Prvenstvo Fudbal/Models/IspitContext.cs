namespace Models;

public class IspitContext : DbContext
{

    public DbSet<Stadion> Stadion { get; set; } 

    public DbSet<Tim> Tim { get; set; }

    public DbSet<Utakmica> Utakmica { get; set; }
    
    public IspitContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Tim>()
            .HasMany(p => p.UtakmicePrvogTima)
            .WithOne(p => p.PrviTim);

        modelBuilder.Entity<Tim>()
            .HasMany(p => p.UtakmiceDrugogTima)
            .WithOne(p => p.DrugiTim);
    }
}
