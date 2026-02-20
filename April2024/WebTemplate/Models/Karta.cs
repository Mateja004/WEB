namespace WebTemplate.Models
{
    [Table("Karta")]

    public class Karta
    {
        [Key]
        public int ID{get;set;}
        
        [Required]
        public int CenaKarte{get;set;}

        public Projekcija?Projekcija{get;set;}

        public int RedNaKarti{get;set;}
        public int SedisteNaKarti{get;set;}
    }
}