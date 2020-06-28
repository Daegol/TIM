using System;

namespace TIM_Server.Services.DTOs.Company
{
    public class SoldierInCompanyDto
    {
        public Guid Id { get; set; }
        public bool IsAssigned { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string Company { get; set; }
    }
}