using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TIM_Server.Core.IRepositories;
using TIM_Server.Core.Model;
using TIM_Server.Infrastructure.Database;

namespace TIM_Server.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DatabaseContext _context;

        public CompanyRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAll() =>
            await Task.FromResult(_context.Companies.Include(x => x.Soldiers).ToList());

        public async Task AddCompany(Company company)
        {
            await _context.AddAsync(company);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<Company> GetById(Guid? id) =>
            await Task.FromResult(_context.Companies.SingleOrDefault(x => x.Id == id));

        public async Task DeleteCompany(Guid id)
        {
            var company = await GetById(id);
            _context.Remove(company);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}