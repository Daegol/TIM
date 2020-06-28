using System.Collections.Generic;
using System.Threading.Tasks;
using TIM_Server.Services.DTOs.Company;
using TIM_Server.Services.DTOs.Users;

namespace TIM_Server.Services.IServices
{
    public interface ICommanderService
    {
        Task<IEnumerable<CommanderDto>> GetCommanders();

        Task DeleteCommander(string pesel);
        Task UpdateCommander(UpdateCommanderDto commanderDto);
        Task<IEnumerable<CommanderToCompanyDto>> GetCommandersToCompany();
    }
}