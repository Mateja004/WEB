namespace WebTemplate.Models
{
    [Table("Sala")]

    public class Sala
    {
        [Key]
        public int ID{get;set;}
        [Required]
        public int BrojSedista{get;set;}
        [Required]
        public int BrojRedova{get;set;}

        [Required]
        public string? NazivSale{get;set;}

    }
}