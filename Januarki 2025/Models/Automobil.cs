namespace WebTemplate.Models;
[Table("Automobil")]
public class Automobil
{
    [Key]
    public int ID {get;set;}

    [Required]
    public string? model{get;set;}

    [Required]
    public int kilometraza{get;set;}

    [Required]
    public DateTime godiste{get;set;}

    [Required]
    public int brojsedista{get;set;}

    [Required]
    public int cenapodanu{get;set;}

    [Required]

    public bool Iznajmljen{get;set;}
}