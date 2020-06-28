namespace TIM_Server.Services.DTOs.Users
{
    public class UpdateSoldierDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Pesel { get; set; }
        public string Address { get; set; }
        public string MilitaryRank { get; set; }
    }
}