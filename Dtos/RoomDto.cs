namespace JWTApi.Dtos
{
    public class RoomDto
    {
        
        public int Room_Id { get; set; }
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public string Building { get; set; }
        public string StudentPhoneNo { get; set; }
        public string AdmitDate { get; set; }
        public string LeftDate { get; set; }
        public string HallFee { get; set; }
        public string FeeYear { get; set; }
        public string HallRoll { get; set; }
    }
}