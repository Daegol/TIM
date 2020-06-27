using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIM_Server.Core.Model;

namespace TIM_Server.Core.IRepositories
{
    public interface ILeaveRepository
    {
        Task<Leave> GetById(Guid id);
        Task AddLeave(Leave leave);
        Task DeleteLeave(Guid id);
        Task UpdateLeave(Leave leave);
        Task<IEnumerable<Leave>> GetAllFromCompany(Guid companyId);
    }
}