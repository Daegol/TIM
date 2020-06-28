using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIM_Server.Services.DTOs.Company;
using TIM_Server.Services.DTOs.Users;
using TIM_Server.Services.IServices;

namespace TIM_Server.Application.Controllers
{
    public class CommandersController : ApiBaseController
    {
        private readonly ICommanderService _commanderService;

        public CommandersController(ICommanderService commanderService)
        {
            _commanderService = commanderService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CommanderDto>>> GetCommandersList()
        {
            var commanders = await _commanderService.GetCommanders();
            return Json(commanders);
        }

        [HttpDelete("{pesel}")]
        public async Task<ActionResult> DeleteCommander(string pesel)
        {
            await _commanderService.DeleteCommander(pesel);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateCommander([FromBody] UpdateCommanderDto commanderDto)
        {
            await _commanderService.UpdateCommander(commanderDto);
            return Ok();
        }

        [HttpGet("tig")]
        public async Task<ActionResult<IEnumerable<CommanderToCompanyDto>>> GetTeachersToGroup()
        {
            var commandersToCompany = await _commanderService.GetCommandersToCompany();
            return Json(commandersToCompany);
        }
    }
}