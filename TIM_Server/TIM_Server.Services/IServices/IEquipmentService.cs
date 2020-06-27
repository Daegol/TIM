using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIM_Server.Services.DTOs.Equipments;

namespace TIM_Server.Services.IServices
{
    public interface IEquipmentService
    {
        Task AddEquipment(EquipmentToAddDto equipmentToAdd);
        Task DeleteEquipment(Guid id);
        Task UpdateEquipment(EquipmentToUpdateDto equipmentToUpdate);
        Task<IEnumerable<EquipmentToSendDto>> GetEquipments(Guid soldierOnDutyId);
    }
}