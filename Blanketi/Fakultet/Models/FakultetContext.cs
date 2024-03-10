namespace Models;

public class FakultetContext : DbContext
{

    public DbSet<Student> Student { get; set; }

    public DbSet<Predmet> Predmet { get; set; }

    public DbSet<IspitniRok> IspitniRok { get; set; }

    public DbSet<Spoj> Spoj { get; set; }
    public FakultetContext(DbContextOptions options) : base(options)
    {
        
    }
}
