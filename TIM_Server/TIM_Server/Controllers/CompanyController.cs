using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIM_Server.Services.DTOs.Company;
using TIM_Server.Services.IServices;

namespace TIM_Server.Application.Controllers
{
    public class CompanyController : ApiBaseController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyes()
        {
            var companyesDto = await _companyService.GetCompanyes();
            return Json(companyesDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCompany([FromBody] CompanyToAddDto companyTo)
        {
            await _companyService.AddCompany(companyTo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _companyService.DeleteCompany(id);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyDto updateCompany)
        {
            await _companyService.UpdateCompany(updateCompany);
            return Ok();
        }
    }
}