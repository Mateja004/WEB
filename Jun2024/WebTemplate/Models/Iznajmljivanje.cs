namespace WebTemplate.Models
{
    public class Iznajmljivanje
    {
        [Key]
        public int ID{get;set;}

        public int brojDana{get;set;}

        public Korisnik?Korisnik{get;set;}

        public Vozilo?Vozilo{get;set;}
    }
}