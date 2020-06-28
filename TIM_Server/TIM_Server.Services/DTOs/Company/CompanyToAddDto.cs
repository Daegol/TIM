using System;
using System.Collections.Generic;

namespace TIM_Server.Services.DTOs.Company
{
    public class CompanyToAddDto
    {
        public string Name { get; set; }
        public Guid CommanderId { get; set; }
        public IEnumerable<Guid> SoldiersId { get; set; }
    }
}