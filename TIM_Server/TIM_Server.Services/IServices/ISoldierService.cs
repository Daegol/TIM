using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIM_Server.Services.DTOs.Company;
using TIM_Server.Services.DTOs.Soldier;
using TIM_Server.Services.DTOs.Users;

namespace TIM_Server.Services.IServices
{
    public interface ISoldierService
    {
        Task<IEnumerable<SoldierToSendDto>> GetSoldiersToSettlement(Guid soldierOnDutyId);

        Task<IEnumerable<SoldierDto>> GetSoldiers();
        Task DeleteSoldier(string pesel);
        Task UpdateSoldier(UpdateSoldierDto studentDto);
        Task<IEnumerable<SoldierInCompanyDto>> GetSoldiersToCompany();
        Task<IEnumerable<SoldierInCompanyDto>> GetSoldiersToCompanyEdit(Guid companyId);
    }
}