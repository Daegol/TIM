using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIM_Server.Services.DTOs.Equipments;
using TIM_Server.Services.IServices;

namespace TIM_Server.Application.Controllers
{
    public class EquipmentController : ApiBaseController
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet("equipments/{soldierOnDutyId}")]
        public async Task<ActionResult<IEnumerable<EquipmentToSendDto>>> GetAllEquipments(Guid soldierOnDutyId)
        {
            var equipments = await _equipmentService.GetEquipments(soldierOnDutyId);
            return Json(equipments);
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateEquipment([FromBody] EquipmentToUpdateDto equipmentToUpdate)
        {
            await _equipmentService.UpdateEquipment(equipmentToUpdate);
            return Ok();
        }

        [HttpDelete("delete/{equipmentId}")]
        public async Task<ActionResult> DeleteEquipment(Guid equipmentId)
        {
            await _equipmentService.DeleteEquipment(equipmentId);
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEquipment([FromBody] EquipmentToAddDto equipmentToAdd)
        {
            await _equipmentService.AddEquipment(equipmentToAdd);
            return Ok();
        }
    }
}