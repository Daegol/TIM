using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIM_Server.Core.IRepositories;
using TIM_Server.Services.DTOs.Reports;
using TIM_Server.Services.IServices;

namespace TIM_Server.Application.Controllers
{
    public class ReportController : ApiBaseController
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("reports/{soldierOnDutyId}")]
        public async Task<ActionResult<IEnumerable<ReportToSendDto>>> GetAllReports(Guid soldierOnDutyId)
        {
            var reports = await _reportService.GetReports(soldierOnDutyId);
            return Json(reports);
        }

        [HttpGet("todayReports/{soldierOnDutyId}")]
        public async Task<ActionResult<IEnumerable<ReportToSendDto>>> GetTodayReports(Guid soldierOnDutyId)
        {
            var reports = await _reportService.GetTodayReports(soldierOnDutyId);
            return Json(reports);
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateReport([FromBody] ReportToUpdateDto reportToUpdate)
        {
            await _reportService.UpdateReport(reportToUpdate);
            return Ok();
        }

        [HttpDelete("delete/{reportId}")]
        public async Task<ActionResult> DeleteReport(Guid reportId)
        {
            await _reportService.DeleteReport(reportId);
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddReport([FromBody] ReportToAddDto reportToAdd)
        {
            await _reportService.AddReport(reportToAdd);
            return Ok();
        }
    }
}