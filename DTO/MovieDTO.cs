
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;

namespace APILocacao.DTO
{
    public class MovieDTO
    {

        [JsonIgnore]
        public int Id { get; set; }
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
        [JsonIgnore]
        public bool Status { get; set; } = true;
    }
}