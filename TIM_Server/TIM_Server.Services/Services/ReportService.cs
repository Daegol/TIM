using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIM_Server.Core.IRepositories;
using TIM_Server.Services.DTOs.Reports;
using TIM_Server.Services.IServices;
using TIM_Server.Services.Mappers;

namespace TIM_Server.Services.Services
{
    public class ReportService : IReportService
    {
        private readonly ISoldierRepository _soldierRepository;
        private readonly IReportRepository _reportRepository;
        private readonly ICommanderRepository _commanderRepository;

        public ReportService(ISoldierRepository soldierRepository, IReportRepository reportRepository, ICommanderRepository commanderRepository)
        {
            _soldierRepository = soldierRepository;
            _reportRepository = reportRepository;
            _commanderRepository = commanderRepository;
        }

        public async Task AddReport(ReportToAddDto reportToAdd)
        {
            var companyId = (Guid) _soldierRepository.GetById(reportToAdd.SoldierId).Result.CompanyId;
            var report = ReportMapper.AddReportMap(reportToAdd,companyId);
            await _reportRepository.AddReport(report);
        }

        public async Task DeleteReport(Guid id)
        {
            await _reportRepository.DeleteReport(id);
        }

        public async Task UpdateReport(ReportToUpdateDto reportToUpdate)
        {
            var report = await _reportRepository.GetById(reportToUpdate.ReportId);
            var update = ReportMapper.UpdateReportMap(reportToUpdate, report);
            await _reportRepository.UpdateReport(update);
        }

        public async Task<IEnumerable<ReportToSendDto>> GetReports(Guid soldierOnDutyId)
        {
            var companyId = (Guid)_commanderRepository.GetById(soldierOnDutyId).Result.CompanyId;
            var reports = await _reportRepository.GetAll(companyId);
            return reports.Select(x => ReportMapper.ReportToSendMap(x, _soldierRepository));
        }

        public async Task<IEnumerable<ReportToSendDto>> GetTodayReports(Guid soldierOnDutyId)
        {
            var companyId = (Guid)_soldierRepository.GetById(soldierOnDutyId).Result.CompanyId;
            var reports = await _reportRepository.GetAll(companyId);
            var todayReports = reports.Where(x => x.Date.Date == DateTime.Today.Date);
            return todayReports.Select(x => ReportMapper.ReportToSendMap(x, _soldierRepository));
        }
    }
}