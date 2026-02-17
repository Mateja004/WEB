namespace WebTemplate.Models;

public class IspitContext : DbContext
{
    // DbSet kolekcije!

    public IspitContext(DbContextOptions<IspitContext> options) : base(options){}

    public DbSet<Automobil> Automobili { get; set; }
}

