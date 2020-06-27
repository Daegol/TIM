using System;
using TIM_Server.Core.Model;

namespace TIM_Server.Services.DTOs.Equipments
{
    public class EquipmentToAddDto
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public Guid SoldierId { get; set; }
    }
}