namespace WebTemplate.Models;

public class IspitContext : DbContext
{
    // DbSet kolekcije!

    public IspitContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Vozilo>Vozilos{get;set;}
    public DbSet<Iznajmljivanje>Iznajmljivanjes{get;set;}
    public DbSet<Korisnik>Korisniks{get;set;}
}
