namespace JWTApi.Dtos
{
    public class transaction
    {
        public int Debit { get; set; }
        public int Credit { get; set; }
        public System.DateTime Date { get; set; }
        public string AccountTitle { get; set; }
    }
}