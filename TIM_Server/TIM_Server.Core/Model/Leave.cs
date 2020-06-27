using System;

namespace TIM_Server.Core.Model
{
    public class Leave
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Where { get; set; }
        public string Type { get; set; }
        public bool Returned { get; set; }
        public virtual Soldier Soldier { get; set; }
        public Guid? SoldierId { get; set; }
    }
}