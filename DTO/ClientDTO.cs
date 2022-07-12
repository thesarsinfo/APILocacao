using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILocacao.Models.DTO
{
    public class ClientDTO
    {
        public ulong CPF { get; set; }
        
        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Telephone { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool Status { get; set; }
    }
}