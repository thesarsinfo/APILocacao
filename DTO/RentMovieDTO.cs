using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APILocacao.DTO
{
    public class RentMovieDTO
    {
        [Required(ErrorMessage = "Campo Id requerido")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo clientId requerido")]        
        public ulong ClientId { get; set; } 
        [Required(ErrorMessage = "Campo MovieId requerido")]
        public int MovieId { get; set; }   
        [Required(ErrorMessage = "Campo Data de revolução requerido")]
        public DateTime FinalDeliveryDate { get; set; }

        [Required(ErrorMessage = "Campo total do aluguel requerido")]
        public decimal TotalRent { get; set; }
    }
}