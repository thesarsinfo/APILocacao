using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APILocacao.Models
{

    public class Client
    {
        [Key]
        [DisplayName("CPF")]
        public ulong CPF { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }


        [DisplayName("Lastname")]
        public string Lastname { get; set; }


        [DisplayName("Telephone")]
        public string Telephone { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("DateOfBirth")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Status")]
        public bool Status { get; set; }

    }
}