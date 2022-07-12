namespace APILocacao.Models.DTO
{
    public class ClientAddDTO
    {

        public ulong CPF { get; set; }
        
        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Telephone { get; set; }

        public string Address { get; set; }

        public System.DateTime DateOfBirth { get; set; }

        public bool Status { get; set; }
    }
}