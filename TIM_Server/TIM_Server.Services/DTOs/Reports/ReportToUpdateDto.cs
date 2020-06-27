using System;

namespace TIM_Server.Services.DTOs.Reports
{
    public class ReportToUpdateDto
    {
        public Guid ReportId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}