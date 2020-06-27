namespace TIM_Server.Services.DTOs.Users
{
    public class UserForRegisterDto
    {
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Pesel { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Password { get; set; }
        public string MilitaryRank { get; set; }
    }
}