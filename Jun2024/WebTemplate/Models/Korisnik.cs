namespace WebTemplate.Models
{
    public class Korisnik
    {
        [Key]
        public int ID{get;set;}

        public string? ime{get;set;}
        public string?prezime{get;set;}

        [MaxLength(13)]
        public string? JMBG{get;set;}

        [MaxLength(9)]
        public int brojDozvole{get;set;}

        public List<Iznajmljivanje>?UgovorIznajmljivanja{get;set;}
    }
}