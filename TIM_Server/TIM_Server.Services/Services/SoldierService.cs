using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIM_Server.Core.IRepositories;
using TIM_Server.Services.DTOs.Company;
using TIM_Server.Services.DTOs.Soldier;
using TIM_Server.Services.DTOs.Users;
using TIM_Server.Services.IServices;
using TIM_Server.Services.Mappers;

namespace TIM_Server.Services.Services
{
    public class SoldierService : ISoldierService
    {
        private readonly ISoldierRepository _soldierRepository;
        private readonly ICompanyRepository _companyRepository;

        public SoldierService(ISoldierRepository soldierRepository, ICompanyRepository companyRepository)
        {
            _soldierRepository = soldierRepository;
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<SoldierToSendDto>> GetSoldiersToSettlement(Guid soldierOnDutyId)
        {
            var companyId = (Guid) _soldierRepository.GetById(soldierOnDutyId).Result.CompanyId;

            var soldiers = await _soldierRepository.GetAllFromCompany(companyId);

            return soldiers.Select(SoldierMapper.SoldierToSendMap);
        }

        public async Task<IEnumerable<SoldierDto>> GetSoldiers()
        {
            var soldiers = await _soldierRepository.Get();
            var soldierDtos = soldiers.Select(SoldierMapper.SoldierMap).ToList();
            for (int i = 0; i < soldierDtos.Count(); i++)
            {
                soldierDtos.ElementAt(i).Id = i + 1;
            }

            return soldierDtos;
        }

        public async Task DeleteSoldier(string pesel)
        {
            await _soldierRepository.DeleteSoldier(pesel);
        }

        public async Task UpdateSoldier(UpdateSoldierDto soldierDto)
        {
            var soldier = await _soldierRepository.GetByPesel(soldierDto.Pesel);
            soldier = SoldierMapper.UpdateSoldierMap(soldierDto, soldier);
            await _soldierRepository.UpdateSoldier(soldier);
        }

        public async Task<IEnumerable<SoldierInCompanyDto>> GetSoldiersToCompany()
        {
            var soldiers = await _soldierRepository.Get();
            var soldiersToCompany = soldiers.Select(x => SoldierMapper.SoldierInCompanyMap(x, _companyRepository)).ToList();
            return soldiersToCompany;
        }

        public async Task<IEnumerable<SoldierInCompanyDto>> GetSoldiersToCompanyEdit(Guid companyId)
        {
            var soldiers = await _soldierRepository.Get();
            var soldiersToCompany = soldiers.Select(x => SoldierMapper.SoldierToCompanyEdit(x, _companyRepository, companyId)).ToList();
            return soldiersToCompany;
        }
    }
}