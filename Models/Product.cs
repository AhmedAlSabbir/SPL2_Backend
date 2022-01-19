using System.Collections.Generic;

namespace JWTApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string date { get; set; }
        public int RejectedProduct { get; set; }
        public int PurchaseProduct { get; set; }
        public int Rate { get; set; }
        public int AvailableProduct { get; set; }

        public ICollection<Invertory> Invertory { get; set; }


    }
}