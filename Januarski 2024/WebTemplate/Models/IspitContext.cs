namespace WebTemplate.Models;

public class IspitContext : DbContext
{
    // DbSet kolekcije!

    public IspitContext(DbContextOptions options) : base(options)
    {} 

    public DbSet<Korisnik>Korisniks{get;set;}
    public DbSet<ChatSoba>ChatSobas{get;set;}
    public DbSet<Chat>Chats{get;set;}
}
