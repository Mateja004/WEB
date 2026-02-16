namespace WebTemplate.Models;

[Table("Korisnik")]

public class Korisnik
{
    [Key]
    [StringLength(13)] // Dobro je ograničiti dužinu ključa zbog performansi
    [DatabaseGenerated(DatabaseGeneratedOption.None)] // Ovo kaže bazi: "Ja ću ručno uneti vrednost, nemoj ti da generišeš"
    public string? JMBG { get; set; }
}

