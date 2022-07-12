using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APILocacao.DTO
{
    public class MovieDTO
    {
        [Required(ErrorMessage = "Campo Id requerido")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Nome requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo Diretor requerido")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Campo Sinopse requerido")]
        public string Synopsis { get; set; }
        [Required(ErrorMessage = "Campo Quantidade requerido")]
        public int Amount { get; set; }
        public bool Status { get; set; }
    }
}