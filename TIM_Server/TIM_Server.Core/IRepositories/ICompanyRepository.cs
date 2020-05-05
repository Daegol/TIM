using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIM_Server.Core.Model;

namespace TIM_Server.Core.IRepositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAll();
        Task AddCompany(Company company);
        Task<Company> GetById(Guid? id);
        Task DeleteCompany(Guid id);
        Task UpdateCompany(Company company);
    }
}