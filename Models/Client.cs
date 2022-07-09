using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APILocacao.Models
{   

    public class Client
    {   [Key]
        [DisplayName("CPF")]
        // [MinLength(11)]
        // [Required(ErrorMessage = "Please fill in the field {0} with a valid number of {0}")]
        public ulong CPF {get;set;}

        [DisplayName("Name")]
        // [StringLength(60, MinimumLength = 3, ErrorMessage = "The field {0} must contain at least {1} and at most {2}")]
        // [Required(ErrorMessage = "Please fill in the field {0}")]
        public string Name {get;set;}


        [DisplayName("Lastname")]
        // [StringLength(30, MinimumLength = 5, ErrorMessage = "The field {0} must contain at least {1} and at most {2}")]
        // [Required(ErrorMessage = "Please fill in the field {0}")]
        public string Lastname {get;set;}


        [DisplayName("Telephone")]
        // [StringLength(12, MinimumLength = 9, ErrorMessage = "The field {0} must contain at least {1} and at most {2}")]
        // [Required(ErrorMessage = "Please fill in the field {0}")]
        public string Telephone {get;set;}

        [DisplayName("Address")]
        // [StringLength(60, MinimumLength = 6, ErrorMessage = "The field {0} must contain at least {1} and at most {2}")]
        // [Required(ErrorMessage = "Please fill in the field {0}")]
        public string Address {get;set;}

        [DisplayName("DateOfBirth")]
        // [StringLength(40, MinimumLength = 8, ErrorMessage = "The field {0} must contain at least {1} and at most {2}")]
         [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DateOfBirth {get;set;}        

        [DisplayName("Status")]
        // [Required(ErrorMessage = "Please fill in the field {0}")]
        public bool Status {get;set;}        

    }
}