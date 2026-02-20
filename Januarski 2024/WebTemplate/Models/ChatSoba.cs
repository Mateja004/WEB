namespace WebTemplate.Models
{
    [Table("ChatSoba")]

    public class ChatSoba
    {
        [Key]
        public int ID{get;set;}
        
        [Required]
        public string?imeSobe{get;set;}

        [Required]
        public int maksBrojClanova{get;set;}
    }
}