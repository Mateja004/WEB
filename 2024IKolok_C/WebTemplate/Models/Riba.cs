namespace WebTemplate.Models
{
    
    public class Riba
    {
        [Key]
        public int ID{get;set;}

        [Required]
        public string? NazivVrste{get;set;}

        [Required]
        public int masa{get;set;}

        [Required]
        public int godinestarosti{get;set;}

        
    }
}