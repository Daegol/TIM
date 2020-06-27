using System;

namespace TIM_Server.Services.DTOs.OutgoingBook
{
    public class LeaveToAddDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Where { get; set; }
        public string Type { get; set; }
        public Guid SoldierId { get; set; }
    }
}