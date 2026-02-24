namespace WebTemplate.Models;

public class IspitContext : DbContext
{
    // DbSet kolekcije!

    public IspitContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Stan>Stans{get;set;}
    public DbSet<Racun>Racuns{get;set;}
}
