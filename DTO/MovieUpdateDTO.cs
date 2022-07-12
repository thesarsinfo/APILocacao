
using System.ComponentModel.DataAnnotations;


namespace APILocacao.DTO
{
    public class MovieUpdateDTO
    {
        [Required(ErrorMessage = "Campo Nome requerido")]
        [StringLength(80)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo Diretor requerido")]
        [StringLength(80)]
        public string Director { get; set; }
        [Required(ErrorMessage = "Campo Sinopse requerido")]
        [StringLength(300)]
        public string Synopsis { get; set; }
        [Required(ErrorMessage = "Campo Quantidade requerido")]
        public int Amount { get; set; }
    }
}