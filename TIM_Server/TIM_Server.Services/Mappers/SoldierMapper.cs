using System;
using TIM_Server.Core.IRepositories;
using TIM_Server.Core.Model;
using TIM_Server.Services.DTOs.Company;
using TIM_Server.Services.DTOs.Soldier;
using TIM_Server.Services.DTOs.Users;

namespace TIM_Server.Services.Mappers
{
    public static class SoldierMapper
    {
        public static SoldierToSendDto SoldierToSendMap(Soldier soldier)
        {
            return new SoldierToSendDto
            {
                SoldierId = soldier.Id,
                FirstName = soldier.FirstName,
                LastName = soldier.LastName,
                MilitaryRank = soldier.MilitaryRank,
                Status = soldier.Status
            };
        }

        public static SoldierDto SoldierMap(Soldier soldier)
        {
            return new SoldierDto
            {
                Id = 0,
                FirstName = soldier.FirstName,
                LastName = soldier.LastName,
                Email = soldier.Email,
                PhoneNumber = soldier.PhoneNumber,
                Pesel = soldier.Pesel,
                Address = soldier.Street + ' ' + soldier.HouseNumber + '\n' + soldier.PostCode + ' ' + soldier.City,
                MilitaryRank = soldier.MilitaryRank
            };

        }

        public static Soldier UpdateSoldierMap(UpdateSoldierDto soldierDto, Soldier soldier)
        {
            soldier.FirstName = soldierDto.FirstName;
            soldier.LastName = soldierDto.LastName;
            soldier.Email = soldierDto.Email;
            soldier.Pesel = soldierDto.Pesel;
            soldier.PhoneNumber = soldierDto.PhoneNumber;
            soldier.Street = soldierDto.Address.Substring(0, soldierDto.Address.IndexOf(' '));
            soldierDto.Address = soldierDto.Address.Remove(0, soldierDto.Address.IndexOf(' ') + 1);
            soldier.HouseNumber = soldierDto.Address.Substring(0, soldierDto.Address.IndexOf(' '));
            soldierDto.Address = soldierDto.Address.Remove(0, soldierDto.Address.IndexOf(' ') + 1);
            soldier.PostCode = soldierDto.Address.Substring(0, soldierDto.Address.IndexOf(' '));
            soldierDto.Address = soldierDto.Address.Remove(0, soldierDto.Address.IndexOf(' ') + 1);
            soldier.City = soldierDto.Address.Substring(0, soldierDto.Address.Length);
            soldier.MilitaryRank = soldierDto.MilitaryRank;
            return soldier;
        }

        public static SoldierInCompanyDto SoldierInCompanyMap(Soldier soldier, ICompanyRepository companyRepository)
        {
            var soldierToCompanyDto = new SoldierInCompanyDto();
            soldierToCompanyDto.FirstName = soldier.FirstName;
            soldierToCompanyDto.LastName = soldier.LastName;
            soldierToCompanyDto.Pesel = soldier.Pesel;
            soldierToCompanyDto.IsAssigned = false;
            soldierToCompanyDto.Company =
                soldier.CompanyId != null ? companyRepository.GetById(soldier.CompanyId).Result.Name : "Brak przydziału";
            soldierToCompanyDto.Id = soldier.Id;
            return soldierToCompanyDto;
        }

        public static SoldierInCompanyDto SoldierToCompanyEdit(Soldier soldier, ICompanyRepository classRepository, Guid classId)
        {
            var soldierToCompanyDto = new SoldierInCompanyDto();
            soldierToCompanyDto.FirstName = soldier.FirstName;
            soldierToCompanyDto.LastName = soldier.LastName;
            soldierToCompanyDto.Pesel = soldier.Pesel;
            soldierToCompanyDto.IsAssigned = soldier.CompanyId == classId;
            soldierToCompanyDto.Company =
                soldier.CompanyId != null ? classRepository.GetById(soldier.CompanyId).Result.Name : "Brak przydziału";
            soldierToCompanyDto.Id = soldier.Id;
            return soldierToCompanyDto;
        }
    }
}