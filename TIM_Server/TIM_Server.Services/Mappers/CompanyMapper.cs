using System;
using System.Linq;
using TIM_Server.Core.IRepositories;
using TIM_Server.Core.Model;
using TIM_Server.Services.DTOs.Company;

namespace TIM_Server.Services.Mappers
{
    public static class CompanyMapper
    {
        public static Company AddCompanyMap(CompanyToAddDto classToAdd, Company cl)
        {
            cl.CommanderId = classToAdd.CommanderId;
            cl.Name = classToAdd.Name;
            return cl;
        }

        public static CompanyesDto CompanyesToSend(Company cl, ICommanderRepository commanderRepository)
        {
            var classesDto = new CompanyesDto();
            classesDto.Name = cl.Name;
            classesDto.DatabaseId = cl.Id;
            classesDto.SoldiersNumber = cl.Soldiers.Count();
            var tutor = commanderRepository.GetById((Guid)cl.CommanderId).Result;
            classesDto.Commander = tutor.FirstName + ' ' + tutor.LastName;
            classesDto.CommanderPesel = tutor.Pesel;
            return classesDto;
        }

        public static Company UpdateCompanyMap(UpdateCompanyDto updateCompany, Company cl, ICommanderRepository commanderRepository)
        {
            cl.Name = updateCompany.Name;
            cl.CommanderId = commanderRepository.GetByPesel(updateCompany.CommanderId).Result.Id;
            return cl;
        }
    }
}