namespace WebTemplate.Models
{
    public class Akvarijum
    {
        [Key]
        public int ID{get;set;}
        public DateTime DatumDodavanja{get;set;}
        [Required]
        public int brojjediniki{get;set;}

        public Rezervoar?P_Rezervoar{get;set;}
        public Riba?P_Riba{get;set;}
    }
}