using System;
using System.ComponentModel.DataAnnotations;

namespace APILocacao.DTO
{
    public class RentMovieDTO
    {
        [Required(ErrorMessage = "Campo Id requerido")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo clientId requerido")]     
        [Range(9999999999,100000000000,ErrorMessage = "Cpf Invalido")]
        public ulong ClientId { get; set; } 
        [Required(ErrorMessage = "Campo MovieId requerido")]
        public int MovieId { get; set; }   
        [Required(ErrorMessage = "Campo Data de revolução requerido")]
        public DateTime FinalDeliveryDate { get; set; }
        public bool ReturnMovie { get; set; }

        [Required(ErrorMessage = "Campo total do aluguel requerido")]
        public decimal TotalRent { get; set; }
    }
}