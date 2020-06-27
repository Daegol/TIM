using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIM_Server.Core.Model;

namespace TIM_Server.Core.IRepositories
{
    public interface ISoldierRepository
    {
        Task<IEnumerable<Soldier>> Get();
        Task<IEnumerable<Soldier>> GetNotOutgoing(Guid companyId);
        Task<IEnumerable<Soldier>> GetAllFromCompany(Guid companyId);
        Task<Soldier> GetById(Guid id);
        Task<Soldier> GetByEmail(string email);
        Task<Soldier> GetByPesel(string pesel);
        Task AddSoldier(Soldier soldier);
        Task DeleteSoldier(string pesel);
        Task UpdateSoldier(Soldier soldier);
    }
}