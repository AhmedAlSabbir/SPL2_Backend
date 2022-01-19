using System.Collections.Generic;

namespace JWTApi.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int Debit { get; set; }
        public int Credit { get; set; }
        public string Date { get; set; }
        public string AccountTitle { get; set; }
        public string Description { get; set; }
        public string StaffName { get; set; }

        public ICollection<User> User { get; set; }
    }
}