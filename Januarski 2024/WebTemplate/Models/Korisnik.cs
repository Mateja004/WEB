namespace WebTemplate.Models
{
    [Table("Korisnik")]
    public class Korisnik
    {
        [Key]
        public int ID{get;set;}

        [Required]
        public string?korisnickoime{get;set;}

        [Required]
        public string?ime{get;set;}

        [Required]
        public string?prezime{get;set;}

        [Required]
        public string?Email{get;set;}

        [Required]
        public string?lozinka{get;set;}
    }
}
