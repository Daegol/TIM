using System;

namespace TIM_Server.Core.Model
{
    public class Report
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public virtual Company Company { get; set; }
        public Guid? CompanyId { get; set; }
    }
}