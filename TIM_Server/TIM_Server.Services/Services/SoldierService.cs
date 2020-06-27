using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIM_Server.Core.IRepositories;
using TIM_Server.Services.DTOs.Soldier;
using TIM_Server.Services.IServices;
using TIM_Server.Services.Mappers;

namespace TIM_Server.Services.Services
{
    public class SoldierService : ISoldierService
    {
        private readonly ISoldierRepository _soldierRepository;

        public SoldierService(ISoldierRepository soldierRepository)
        {
            _soldierRepository = soldierRepository;
        }

        public async Task<IEnumerable<SoldierToSendDto>> GetSoldiersToSettlement(Guid soldierOnDutyId)
        {
            var companyId = (Guid) _soldierRepository.GetById(soldierOnDutyId).Result.CompanyId;

            var soldiers = await _soldierRepository.GetAllFromCompany(companyId);

            return soldiers.Select(SoldierMapper.SoldierToSendMap);
        }
    }
}