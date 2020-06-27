using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIM_Server.Core.IRepositories;
using TIM_Server.Services.DTOs.Equipments;
using TIM_Server.Services.IServices;
using TIM_Server.Services.Mappers;

namespace TIM_Server.Services.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly ISoldierRepository _soldierRepository;
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(ISoldierRepository soldierRepository, IEquipmentRepository equipmentRepository)
        {
            _soldierRepository = soldierRepository;
            _equipmentRepository = equipmentRepository;
        }

        public async Task AddEquipment(EquipmentToAddDto equipmentToAdd)
        {
            var companyId = (Guid)_soldierRepository.GetById(equipmentToAdd.SoldierId).Result.CompanyId;
            await _equipmentRepository.AddEquipment(EquipmentMapper.AddEquipmentMap(equipmentToAdd,companyId));
        }

        public async Task DeleteEquipment(Guid id)
        {
            await _equipmentRepository.DeleteEquipment(id);
        }

        public async Task UpdateEquipment(EquipmentToUpdateDto equipmentToUpdate)
        {
            var companyId = (Guid)_soldierRepository.GetById(equipmentToUpdate.SoldierId).Result.CompanyId;
            await _equipmentRepository.UpdateEquipment(
                EquipmentMapper.UpdateEquipmentMap(equipmentToUpdate, companyId));
        }

        public async Task<IEnumerable<EquipmentToSendDto>> GetEquipments(Guid soldierOnDutyId)
        {
            var companyId = (Guid)_soldierRepository.GetById(soldierOnDutyId).Result.CompanyId;
            var equipments = await _equipmentRepository.GetAll(companyId);
            return equipments.Select(x => EquipmentMapper.EquipmentToSendMap(x, _soldierRepository));
        }
    }
}