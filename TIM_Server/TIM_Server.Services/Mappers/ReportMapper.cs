using System;
using TIM_Server.Core.IRepositories;
using TIM_Server.Core.Model;
using TIM_Server.Services.DTOs.Reports;

namespace TIM_Server.Services.Mappers
{
    public static class ReportMapper
    {
        public static Report AddReportMap(ReportToAddDto reportToAdd, Guid companyId)
        {
            return new Report
            {
                Id = Guid.NewGuid(),
                Text = reportToAdd.Text,
                Date = reportToAdd.Date,
                SoldierId = reportToAdd.SoldierId,
                CompanyId = companyId
            };
        }

        public static Report UpdateReportMap(ReportToUpdateDto reportToUpdate, Report report)
        {
            report.Date = reportToUpdate.Date;
            report.Text = reportToUpdate.Text;
            return report;
        }

        public static ReportToSendDto ReportToSendMap(Report report, ISoldierRepository soldierRepository)
        {
            return new ReportToSendDto
            {
                Id = report.Id,
                Text = report.Text,
                Date = report.Date,
                FirstName = soldierRepository.GetById(report.SoldierId).Result.FirstName,
                LastName = soldierRepository.GetById(report.SoldierId).Result.LastName,
                MilitaryRank = soldierRepository.GetById(report.SoldierId).Result.MilitaryRank
            };

        }
    }
}