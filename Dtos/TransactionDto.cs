namespace JWTApi.Dtos
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public int Debit { get; set; }
        public int Credit { get; set; }
        public string Date { get; set; }
        public string AccountTitle { get; set; }
        public string Description { get; set; }
        public string StaffName { get; set; }
    }
}