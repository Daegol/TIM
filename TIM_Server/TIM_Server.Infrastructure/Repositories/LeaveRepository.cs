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
    public class LeaveRepository : ILeaveRepository
    {
        private readonly DatabaseContext _context;

        public LeaveRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Leave> GetById(Guid id) =>
            await Task.FromResult(_context.Leaves.SingleOrDefault(x => x.Id == id));

        public async Task AddLeave(Leave leave)
        {
            await _context.AddAsync(leave);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteLeave(Guid id)
        {
            var leave = await GetById(id);
            leave.Returned = true;
            _context.Leaves.Update(leave);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateLeave(Leave leave)
        {
            _context.Leaves.Update(leave);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Leave>> GetAllFromCompany(Guid companyId) =>
            await Task.FromResult(_context.Leaves.Where(x => x.Soldier.CompanyId == companyId && x.Returned==false).Include(x => x.Soldier));
    }
}