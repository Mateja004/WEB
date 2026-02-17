using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace asp.net_Proj.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? LastName { get; set; }

    }
}