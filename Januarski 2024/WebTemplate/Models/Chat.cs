
namespace WebTemplate.Models
{
    [Table("Chat")]

    public class Chat
    {
        [Key]
        public int ID{get;set;}
        public Korisnik? A_Korisnik{get;set;}
        public ChatSoba? A_ChatSoba{get;set;}
        public string?Nadimak{get;set;}
        public string? Boja{get;set;}
    }
    
}