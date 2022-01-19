using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTApi.Models
{
    public class Invertory
    {   [Key]
        public int InventoryId { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }

         public ICollection<User> User { get; set; }

        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}