using System;

namespace TIM_Server.Core.Model
{
    public class Equipment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime StatusDate { get; set; }
        public Guid? SoldierId { get; set; }
        public virtual Company Company { get; set; }
        public Guid? CompanyId { get; set; }
    }
}