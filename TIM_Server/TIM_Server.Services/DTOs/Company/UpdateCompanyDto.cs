using System;
using System.Collections.Generic;

namespace TIM_Server.Services.DTOs.Company
{
    public class UpdateCompanyDto
    {
        public string Name { get; set; }
        public string CommanderId { get; set; }
        public IEnumerable<Guid> SoldiersId { get; set; }
        public Guid CompanyId { get; set; }
    }
}