using System;

namespace TIM_Server.Services.DTOs.Reports
{
    public class ReportToAddDto
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public Guid SoldierId { get; set; }
    }
}