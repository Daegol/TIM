using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIM_Server.Services.DTOs;
using TIM_Server.Services.DTOs.OutgoingBook;
using TIM_Server.Services.DTOs.Reports;

namespace TIM_Server.Services.IServices
{
    public interface IReportService
    {
        Task AddReport(ReportToAddDto reportToAdd);
        Task DeleteReport(Guid id);
        Task UpdateReport(ReportToUpdateDto reportToUpdate);
        Task<IEnumerable<ReportToSendDto>> GetReports(Guid soldierOnDutyId);
        Task<IEnumerable<ReportToSendDto>> GetTodayReports(Guid soldierOnDutyId);
    }
}