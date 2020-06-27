using System;

namespace TIM_Server.Services.DTOs.OutgoingBook
{
    public class LeaveToUpdateDto
    {
        public Guid LeaveId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Where { get; set; }
        public string Type { get; set; }
    }
}