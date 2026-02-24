namespace WebTemplate.Models
{
    [Table("Racun")]

    public class Racun
    {

        private const int Osnovicazasruju=150;
        private const int OsnovicazaKomunalije=100;

        [Key]

        public int ID{get;set;}

        [Required]
        public Stan Stan{get;set;}

        [Range(1,12)]
        public int MesecIzdavanja{get;set;}

        public int CenaStruje
        {
            get=>Stan.brojClanova*Osnovicazasruju;
                
        }

        public int CenaVode{get;set;}

        public int KomUsluge
        {
            get=>Stan.brojClanova*OsnovicazaKomunalije;
        }

        public bool Placen{get;set;}
    }
}