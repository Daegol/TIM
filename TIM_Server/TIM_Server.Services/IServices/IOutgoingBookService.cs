using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIM_Server.Services.DTOs;
using TIM_Server.Services.DTOs.OutgoingBook;

namespace TIM_Server.Services.IServices
{
    public interface IOutgoingBookService
    {
        Task AddLeave(LeaveToAddDto leaveToAdd);
        Task DeleteLeave(Guid id);
        Task UpdateLeave(LeaveToUpdateDto leaveToUpdate);
        Task<IEnumerable<OutgoingSoldierDto>> GetOutgoingSoldiers(Guid soldierOnDutyId);
        Task<IEnumerable<NotOutgoingSoldierDto>> GetNotOutgoingSoldiers(Guid soldierOnDutyId);
    }
}