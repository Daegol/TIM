using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIM_Server.Core.IRepositories;
using TIM_Server.Core.Model;
using TIM_Server.Infrastructure.Database;

namespace TIM_Server.Infrastructure.Repositories
{
    public class SoldierRepository : ISoldierRepository
    {
        private readonly DatabaseContext _context;

        public SoldierRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Soldier>> Get() =>
            await Task.FromResult(_context.Soldiers.ToList());

        public async Task<Soldier> GetById(Guid id) =>
            await Task.FromResult(_context.Soldiers.SingleOrDefault(x => x.Id == id));

        public async Task<Soldier> GetByEmail(string email) =>
            await Task.FromResult(_context.Soldiers.SingleOrDefault(x => x.Email == email));

        public async Task<Soldier> GetByPesel(string pesel) =>
            await Task.FromResult(_context.Soldiers.SingleOrDefault(x => x.Pesel == pesel));

        public async Task AddSoldier(Soldier soldier)
        {
            await _context.AddAsync(soldier);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteSoldier(string pesel)
        {
            var soldier = await GetByPesel(pesel);
            _context.Soldiers.Remove(soldier);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateSoldier(Soldier soldier)
        {
            _context.Soldiers.Update(soldier);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}