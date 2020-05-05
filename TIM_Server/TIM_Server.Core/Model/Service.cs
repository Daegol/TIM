using System;

namespace TIM_Server.Core.Model
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid SoldierId { get; set; }
        public virtual Company Company { get; set; }
        public Guid? CompanyId { get; set; }
    }
}