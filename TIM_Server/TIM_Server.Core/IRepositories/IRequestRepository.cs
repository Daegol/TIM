using System;
using System.Threading.Tasks;
using TIM_Server.Core.Model;

namespace TIM_Server.Core.IRepositories
{
    public interface IRequestRepository
    {
        Task<Request> GetById(Guid id);
        Task AddRequest(Request request);
        Task DeleteRequest(Guid id);
        Task UpdateRequest(Request request);
    }
}