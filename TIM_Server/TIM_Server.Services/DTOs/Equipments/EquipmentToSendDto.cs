using System;

namespace TIM_Server.Services.DTOs.Equipments
{
    public class EquipmentToSendDto
    {
        public Guid EquipmentId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime StatusDate { get; set; }
        public Guid SoldierId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MilitaryRank { get; set; }
    }
}