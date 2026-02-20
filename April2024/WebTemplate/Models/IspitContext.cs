namespace WebTemplate.Models;

public class IspitContext : DbContext
{
    // DbSet kolekcije!

    public IspitContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Karta>Kartas{get;set;}
    public DbSet<Projekcija>Projekcijas{get;set;}
    public DbSet<Sala>Salas{get;set;}
}
