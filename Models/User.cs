using System.ComponentModel.DataAnnotations.Schema;

namespace JWTApi.Models
{
    public class User
    {

        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname {get; set; }
        public string Contrct {get; set; }
        public string Password  { get; set; }

        
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public Usertype Usertype { get; set; }

        public int? TransactionId { get; set; }
        [ForeignKey("TransactionId")]
        public Transaction Transaction { get; set; }

        public int? InventoryId { get; set; }
        [ForeignKey("InventoryId")]
        public Invertory Invertory { get; set; }
        public int Student_Id { get; set; }
        [ForeignKey("Student_Id")]
        public Student Student { get; set; }

    }
}