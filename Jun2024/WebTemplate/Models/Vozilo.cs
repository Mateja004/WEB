namespace WebTemplate.Models
{
    public class Vozilo
    {
        [Key]
        public int ID{get;set;}

        public string?Model{get;set;}

        public int PredjenaKilometraza{get;set;}

        public int godiste{get;set;}

        public int brojSedista{get;set;}

        public int cenapodanu{get;set;}

        public bool iznajmljen{get;set;}

        public List<Iznajmljivanje>?UgovorIznajmljivanja{get;set;}
    }
}