using System;
using System.ComponentModel.DataAnnotations;

namespace APILocacao.Models.DTO
{
    public class ClientDTO
    {
        [Required(ErrorMessage = "Campo clientId requerido")]     
        [Range(9999999999,100000000000,ErrorMessage = "Cpf Invalido")]
        public ulong CPF { get; set; }
        
        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Telephone { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool Status { get; set; }
    }
}