using System;

namespace TIM_Server.Services.DTOs.Company
{
    public class CommanderToCompanyDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
    }
}