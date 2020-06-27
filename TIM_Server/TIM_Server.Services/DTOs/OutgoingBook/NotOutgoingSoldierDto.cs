using System;

namespace TIM_Server.Services.DTOs.OutgoingBook
{
    public class NotOutgoingSoldierDto
    {
        public Guid SoldierId { get; set; }
        public string MilitaryRank { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}