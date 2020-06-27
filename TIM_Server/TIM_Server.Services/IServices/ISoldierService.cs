using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIM_Server.Services.DTOs.Soldier;

namespace TIM_Server.Services.IServices
{
    public interface ISoldierService
    {
        Task<IEnumerable<SoldierToSendDto>> GetSoldiersToSettlement(Guid soldierOnDutyId);
    }
}