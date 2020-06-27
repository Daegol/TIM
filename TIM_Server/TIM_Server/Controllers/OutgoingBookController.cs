using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIM_Server.Services.DTOs;
using TIM_Server.Services.DTOs.OutgoingBook;
using TIM_Server.Services.IServices;

namespace TIM_Server.Application.Controllers
{
    public class OutgoingBookController : ApiBaseController
    {
        private readonly IOutgoingBookService _outgoingBookService;

        public OutgoingBookController(IOutgoingBookService outgoingBookService)
        {
            _outgoingBookService = outgoingBookService;
        }

        [HttpGet("outgoingSoldiers/{soldierOnDutyId}")]
        public async Task<ActionResult<IEnumerable<OutgoingSoldierDto>>> GetOutgoingSoldiersList(Guid soldierOnDutyId)
        {
            var soldiers = await _outgoingBookService.GetOutgoingSoldiers(soldierOnDutyId);
            return Json(soldiers);
        }

        [HttpGet("notOutgoingSoldiers/{soldierOnDutyId}")]
        public async Task<ActionResult<IEnumerable<OutgoingSoldierDto>>> GetNotOutgoingSoldiersList(Guid soldierOnDutyId)
        {
            var soldiers = await _outgoingBookService.GetNotOutgoingSoldiers(soldierOnDutyId);
            return Json(soldiers);
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateLeave([FromBody] LeaveToUpdateDto leaveToUpdate)
        {
            await _outgoingBookService.UpdateLeave(leaveToUpdate);
            return Ok();
        }

        [HttpDelete("delete/{leaveId}")]
        public async Task<ActionResult> DeleteLeave(Guid leaveId)
        {
            await _outgoingBookService.DeleteLeave(leaveId);
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddLeave([FromBody] LeaveToAddDto leaveToAdd)
        {
            await _outgoingBookService.AddLeave(leaveToAdd);
            return Ok();
        }
    }
}