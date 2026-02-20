namespace WebTemplate.Models
{
    [Table("Projekcija")]

    public class Projekcija
    {
        [Key]
        public int ID{get;set;}

        [Required]
        public string?NazivProjekcije{get;set;}

        [Required]
        public DateTime VremePikaza{get;set;}

        public Sala? Sala{get;set;}

        public int sifra{get;set;}

        public List<Karta>?Karte{get;set;}

    }
}
    

    
