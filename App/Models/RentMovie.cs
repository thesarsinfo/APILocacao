using System;

namespace APILocacao.Models
{
    public class RentMovie
    {
        public int Id { get; set; }
        public Client Clients { get; set; }    
        public Movie Movies { get; set; }    
        public DateTime FinalDeliveryDate { get; set; }        
        public bool ReturnMovie { get; set; }
        public decimal TotalRent { get; set; }
        
        
    }
}