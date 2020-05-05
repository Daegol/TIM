using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIM_Server.Core.IRepositories;
using TIM_Server.Core.Model;
using TIM_Server.Infrastructure.Database;

namespace TIM_Server.Infrastructure.Repositories
{
    public class CommanderRepository : ICommanderRepository
    {
        private readonly DatabaseContext _context;

        public CommanderRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Commander>> Get() =>
            await Task.FromResult(_context.Commanders.ToList());

        public async Task<Commander> GetById(Guid id) =>
            await Task.FromResult(_context.Commanders.SingleOrDefault(x => x.Id == id));

        public async Task<Commander> GetByEmail(string email) =>
            await Task.FromResult(_context.Commanders.SingleOrDefault(x => x.Email == email));

        public async Task<Commander> GetByPesel(string pesel) =>
            await Task.FromResult(_context.Commanders.SingleOrDefault(x => x.Pesel == pesel));

        public async Task AddCommander(Commander commander)
        {
            await _context.AddAsync(commander);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteCommander(string pesel)
        {
            var commander = await GetByPesel(pesel);
            _context.Commanders.Remove(commander);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateCommander(Commander commander)
        {
            _context.Commanders.Update(commander);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}