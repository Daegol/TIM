using System;

namespace TIM_Server.Services.DTOs.Company
{
    public class CompanyesDto
    {
        public string Name { get; set; }
        public string Commander { get; set; }
        public string CommanderPesel { get; set; }
        public int SoldiersNumber { get; set; }
        public Guid DatabaseId { get; set; }
    }
}