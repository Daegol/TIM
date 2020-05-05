using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIM_Server.Core.IRepositories;
using TIM_Server.Core.Model;
using TIM_Server.Infrastructure.Database;

namespace TIM_Server.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DatabaseContext _context;

        public AdminRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Admin>> Get() =>
            await Task.FromResult(_context.Admins.ToList());

        public async Task<Admin> GetById(Guid id) =>
            await Task.FromResult(_context.Admins.SingleOrDefault(x => x.Id == id));

        public async Task<Admin> GetByEmail(string email) =>
            await Task.FromResult(_context.Admins.SingleOrDefault(x => x.Email == email));

        public async Task<Admin> GetByPesel(string pesel) =>
            await Task.FromResult(_context.Admins.SingleOrDefault(x => x.Pesel == pesel));

        public async Task AddAdmin(Admin admin)
        {
            await _context.AddAsync(admin);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteAdmin(string pesel)
        {
            var admin = await GetByPesel(pesel);
            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateAdmin(Admin admin)
        {
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}