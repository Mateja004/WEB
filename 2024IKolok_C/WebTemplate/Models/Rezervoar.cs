namespace WebTemplate.Models
{
   public class Rezervoar
    {
        [Key]
        public int ID {get;set;}

        [StringLength (6, MinimumLength =6, ErrorMessage ="sifra mora imati 6 karakera")]
        [Required]
        public string? Sifra{get;set;}

        [Required]
        public int Zapremina{get;set;}

        [Required]
        public int temperatura{get;set;}

        [Required]
        public DateTime PoslednjeCiscenje{get;set;}

        [Required]
        public int FrekvencijaCiscenja{get;set;}

        [Required]
        public int Kapacitet{get;set;}

        public int BrojRiba{get;set;}=0;

    }
}
