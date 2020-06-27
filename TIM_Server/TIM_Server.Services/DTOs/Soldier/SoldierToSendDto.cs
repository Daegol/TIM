using System;

namespace TIM_Server.Services.DTOs.Soldier
{
    public class SoldierToSendDto
    {
        public Guid SoldierId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MilitaryRank { get; set; }
        public string Status { get; set; }
    }
}