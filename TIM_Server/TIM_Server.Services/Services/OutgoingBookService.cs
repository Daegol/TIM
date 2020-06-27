using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIM_Server.Core.IRepositories;
using TIM_Server.Services.DTOs;
using TIM_Server.Services.DTOs.OutgoingBook;
using TIM_Server.Services.IServices;
using TIM_Server.Services.Mappers;

namespace TIM_Server.Services.Services
{
    public class OutgoingBookService : IOutgoingBookService
    {

        private readonly ILeaveRepository _leaveRepository;
        private readonly ISoldierRepository _soldierRepository;

        public OutgoingBookService(ILeaveRepository leaveRepository, ISoldierRepository soldierRepository)
        {
            _leaveRepository = leaveRepository;
            _soldierRepository = soldierRepository;
        }

        public async Task AddLeave(LeaveToAddDto leaveToAdd)
        {
            var leave = OutgoingMapper.AddLeaveMap(leaveToAdd);
            var soldier = await _soldierRepository.GetById(leaveToAdd.SoldierId);
            soldier.Status = leaveToAdd.Type;
            await _soldierRepository.UpdateSoldier(soldier);
            await _leaveRepository.AddLeave(leave);
        }

        public async Task DeleteLeave(Guid id)
        {
            var leave = await _leaveRepository.GetById(id);
            var soldier = await _soldierRepository.GetById((Guid)leave.SoldierId);
            soldier.Status = "X";
            await _soldierRepository.UpdateSoldier(soldier);
            await _leaveRepository.DeleteLeave(id);
        }

        public async Task UpdateLeave(LeaveToUpdateDto leaveToUpdate)
        {
            var leave = await _leaveRepository.GetById(leaveToUpdate.LeaveId);
            leave = OutgoingMapper.UpdateLeaveMap(leaveToUpdate, leave);
            var soldier = await _soldierRepository.GetById((Guid)leave.SoldierId);
            soldier.Status = leaveToUpdate.Type;
            await _soldierRepository.UpdateSoldier(soldier);
            await _leaveRepository.UpdateLeave(leave);
        }

        public async Task<IEnumerable<OutgoingSoldierDto>> GetOutgoingSoldiers(Guid soldierOnDutyId)
        {
            var companyId = (Guid) _soldierRepository.GetById(soldierOnDutyId).Result.CompanyId;

            var leaves = await _leaveRepository.GetAllFromCompany(companyId);
            var outgoingSoldiers = leaves.Select(OutgoingMapper.OutgoingSoldierMap);
            return outgoingSoldiers;
        }

        public async Task<IEnumerable<NotOutgoingSoldierDto>> GetNotOutgoingSoldiers(Guid soldierOnDutyId)
        {
            var companyId = (Guid)_soldierRepository.GetById(soldierOnDutyId).Result.CompanyId;

            var soldiers = await _soldierRepository.GetNotOutgoing(companyId);

            var notOutgoingSoldiers = soldiers.Select(OutgoingMapper.NotOutgoingSoldierMap);

            return notOutgoingSoldiers;
        }
    }
}