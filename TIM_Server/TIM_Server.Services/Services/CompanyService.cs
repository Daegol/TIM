using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIM_Server.Core.IRepositories;
using TIM_Server.Core.Model;
using TIM_Server.Services.DTOs.Company;
using TIM_Server.Services.IServices;
using TIM_Server.Services.Mappers;

namespace TIM_Server.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ISoldierRepository _soldierRepository;
        private readonly ICommanderRepository _commanderRepository;

        public CompanyService(ICompanyRepository companyRepository, ISoldierRepository soldierRepository, ICommanderRepository commanderRepository)
        {
            _companyRepository = companyRepository;
            _soldierRepository = soldierRepository;
            _commanderRepository = commanderRepository;
        }

        public async Task AddCompany(CompanyToAddDto @company)
        {
            var newCompany = new Company();
            var cl = CompanyMapper.AddCompanyMap(company, newCompany);
            await _companyRepository.AddCompany(cl);
            await _soldierRepository.AddCompanyes(company.SoldiersId, cl.Id);
        }

        public async Task<IEnumerable<CompanyesDto>> GetCompanyes()
        {
            var companyes = await _companyRepository.GetAll();
            return companyes.Select(x => CompanyMapper.CompanyesToSend(x, _commanderRepository));
        }

        public async Task DeleteCompany(Guid id)
        {
            await _companyRepository.DeleteCompany(id);
        }

        public async Task UpdateCompany(UpdateCompanyDto updateCompany)
        {
            var cl = await _companyRepository.GetById(updateCompany.CompanyId);
            cl = CompanyMapper.UpdateCompanyMap(updateCompany, cl, _commanderRepository);
            await _soldierRepository.AddCompanyes(updateCompany.SoldiersId, updateCompany.CompanyId);
            await _companyRepository.UpdateCompany(cl);
        }
    }
}