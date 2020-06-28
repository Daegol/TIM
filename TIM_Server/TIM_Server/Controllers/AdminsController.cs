using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIM_Server.Services.DTOs.Users;
using TIM_Server.Services.IServices;

namespace TIM_Server.Application.Controllers
{
    public class AdminsController : ApiBaseController
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<AdminDto>>> GetAdminsList()
        {
            var admins = await _adminService.GetAdmins();
            return Json(admins);
        }

        [HttpDelete("{pesel}")]
        public async Task<ActionResult> DeleteAdmin(string pesel)
        {
            await _adminService.DeleteAdmin(pesel);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateAdmin([FromBody] UpdateAdminDto adminDto)
        {
            await _adminService.UpdateAdmin(adminDto);
            return Ok();
        }
    }
}