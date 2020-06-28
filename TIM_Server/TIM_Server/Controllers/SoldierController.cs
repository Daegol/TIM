using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIM_Server.Services.DTOs.Company;
using TIM_Server.Services.DTOs.Soldier;
using TIM_Server.Services.DTOs.Users;
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
            var soldiers = await _soldierService.GetSoldiersToSettlement(soldierOnDutyId);
            return Json(soldiers);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<SoldierDto>>> GetSoldiersList()
        {
            var soldiers = await _soldierService.GetSoldiers();
            return Json(soldiers);
        }

        [HttpDelete("{pesel}")]
        public async Task<ActionResult> DeleteSoldier(string pesel)
        {
            await _soldierService.DeleteSoldier(pesel);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateSoldier([FromBody] UpdateSoldierDto soldierDto)
        {
            await _soldierService.UpdateSoldier(soldierDto);
            return Ok();
        }

        [HttpGet("stg")]
        public async Task<ActionResult<IEnumerable<SoldierInCompanyDto>>> GetSoldiersToCompany()
        {
            var soldiers = await _soldierService.GetSoldiersToCompany();
            return Json(soldiers);
        }

        [HttpGet("stg/{id}")]
        public async Task<ActionResult<IEnumerable<SoldierInCompanyDto>>> GetSoldiersToCompany(Guid id)
        {
            var soldiers = await _soldierService.GetSoldiersToCompanyEdit(id);
            return Json(soldiers);
        }
    }
}