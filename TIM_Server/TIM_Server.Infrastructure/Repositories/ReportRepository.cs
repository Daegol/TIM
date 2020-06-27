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
    public class ReportRepository : IReportRepository
    {
        private readonly DatabaseContext _context;

        public ReportRepository(DatabaseContext context)
        {
            _context = context;
        }


        public async Task<Report> GetById(Guid id) =>
            await Task.FromResult(_context.Reports.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Report>> GetAll(Guid companyId) =>
            await Task.FromResult(_context.Reports.Where(x => x.CompanyId == companyId));

        public async Task AddReport(Report report)
        {
            await _context.AddAsync(report);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteReport(Guid id)
        {
            var report = await GetById(id);
            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateReport(Report report)
        {
            _context.Reports.Update(report);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}