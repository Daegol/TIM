using System;
using TIM_Server.Core.IRepositories;
using TIM_Server.Core.Model;
using TIM_Server.Services.DTOs.Equipments;

namespace TIM_Server.Services.Mappers
{
    public static class EquipmentMapper
    {
        public static Equipment AddEquipmentMap(EquipmentToAddDto equipmentToAdd, Guid companyId)
        {
            return new Equipment
            {
                Id = Guid.NewGuid(),
                Name = equipmentToAdd.Name,
                Status = equipmentToAdd.Status,
                StatusDate = DateTime.MaxValue,
                SoldierId = equipmentToAdd.SoldierId,
                CompanyId = companyId
            };
        }

        public static Equipment UpdateEquipmentMap(EquipmentToUpdateDto equipmentToUpdate, Guid companyId)
        {
            return new Equipment
            {
                Id = equipmentToUpdate.EquipmentId,
                Name = equipmentToUpdate.Name,
                Status = equipmentToUpdate.Status,
                StatusDate = equipmentToUpdate.StatusDate,
                SoldierId = equipmentToUpdate.SoldierId,
                CompanyId = companyId
            };
        }

        public static EquipmentToSendDto EquipmentToSendMap(Equipment equipment, ISoldierRepository soldierRepository)
        {
            return new EquipmentToSendDto
            {
                EquipmentId = equipment.Id,
                Name = equipment.Name,
                Status = equipment.Status,
                StatusDate = equipment.StatusDate,
                SoldierId = (Guid) equipment.SoldierId,
                FirstName = soldierRepository.GetById((Guid) equipment.SoldierId).Result.FirstName,
                LastName = soldierRepository.GetById((Guid) equipment.SoldierId).Result.LastName,
                MilitaryRank = soldierRepository.GetById((Guid) equipment.SoldierId).Result.MilitaryRank,
            };
        }
    }
}