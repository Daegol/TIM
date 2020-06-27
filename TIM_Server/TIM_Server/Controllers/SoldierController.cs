using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIM_Server.Services.DTOs.Reports;
using TIM_Server.Services.DTOs.Soldier;
using TIM_Server.Services.IServices;

namespace TIM_Server.Application.Controllers
{
    public class SoldierController : ApiBaseController
    {
        private readonly ISoldierService _soldierService;

        public SoldierController(ISoldierService soldierService)
        {
            _soldierService = soldierService;
        }

        [HttpGet("soldiers/{soldierOnDutyId}")]
        public async Task<ActionResult<IEnumerable<SoldierToSendDto>>> GetSoldiersToSettlement(Guid soldierOnDutyId)
        {
            var soldiers = _soldierService.GetSoldiersToSettlement(soldierOnDutyId);
            return Json(soldiers);
        }
    }
}