namespace APILocacao.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Synopsis { get; set; }
        public int Amount { get; set; }
        public bool Status { get; set; }
    }
}