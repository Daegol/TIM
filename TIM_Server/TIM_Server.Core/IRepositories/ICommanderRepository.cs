using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIM_Server.Core.Model;

namespace TIM_Server.Core.IRepositories
{
    public interface ICommanderRepository
    {
        Task<IEnumerable<Commander>> Get();
        Task<Commander> GetById(Guid id);
        Task<Commander> GetByEmail(string email);
        Task<Commander> GetByPesel(string pesel);
        Task AddCommander(Commander commander);
        Task DeleteCommander(string pesel);
        Task UpdateCommander(Commander commander);
    }
}