namespace WebTemplate.Models
{
    [Table("Stan")]

    public class Stan
    {
        [Key]
        public int ID{get;set;}

        public string?imevlasnika{get;set;}

        public int povrsina{get;set;}

        public int brojClanova{get;set;}

        public List<Racun>? racuni{get;set;}

    }
}