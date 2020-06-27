using System;

namespace TIM_Server.Services.DTOs.Reports
{
    public class ReportToSendDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MilitaryRank { get; set; }
    }
}