using System;

namespace TIM_Server.Services.DTOs.OutgoingBook
{
    public class OutgoingSoldierDto
    {
        public Guid SoldierId { get; set; }
        public Guid LeaveId { get; set; }
        public string MilitaryRank { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}