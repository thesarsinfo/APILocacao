using System.ComponentModel.DataAnnotations;
namespace APILocacao.Models
{
    public class Movie
    {
        public int Id { get; set; }
        // [Required]
        // [StringLength(100)]
        public string Name { get; set; }
        // [Required]
        // [StringLength(100)]
        public string Director { get; set; }
        // [Required]
        // [StringLength(500)]
        public string Synopsis { get; set; }
        public int Amount { get; set; }
        public bool Status { get; set; }
    }
}