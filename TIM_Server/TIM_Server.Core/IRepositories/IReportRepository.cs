using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIM_Server.Core.Model;

namespace TIM_Server.Core.IRepositories
{
    public interface IReportRepository
    {
        Task<Report> GetById(Guid id);
        Task<IEnumerable<Report>> GetAll(Guid companyId);
        Task AddReport(Report report);
        Task DeleteReport(Guid id);
        Task UpdateReport(Report report);
    }
}