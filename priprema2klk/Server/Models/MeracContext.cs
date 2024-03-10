using Microsoft.EntityFrameworkCore;

namespace Merac.Models;

public class MeracContext : DbContext
{
    public required DbSet<Merac> Meraci { get; set; }

    public MeracContext(DbContextOptions options) : base(options)
    {

    }
}
