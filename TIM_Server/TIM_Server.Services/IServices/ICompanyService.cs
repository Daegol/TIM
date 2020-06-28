using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIM_Server.Services.DTOs.Company;

namespace TIM_Server.Services.IServices
{
    public interface ICompanyService
    {
        Task AddCompany(CompanyToAddDto company);
        Task<IEnumerable<CompanyesDto>> GetCompanyes();
        Task DeleteCompany(Guid id);
        Task UpdateCompany(UpdateCompanyDto updateCompany);
    }
}