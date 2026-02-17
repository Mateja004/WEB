namespace WebTemplate.Models;

public class IspitContext : DbContext
{
    // DbSet kolekcije!

    public IspitContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Rezervoar>Rezervoars {get;set;}
    public DbSet<Riba>Ribas{get;set;}
    public DbSet<Akvarijum>Akvarijums{get;set;}
}
