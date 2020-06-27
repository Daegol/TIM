using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIM_Server.Core.IRepositories;
using TIM_Server.Core.Model;
using TIM_Server.Infrastructure.Database;

namespace TIM_Server.Infrastructure.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly DatabaseContext _context;

        public EquipmentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Equipment> GetById(Guid id) =>
            await Task.FromResult(_context.Equipments.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Equipment>> GetAll(Guid companyId) =>
            await Task.FromResult(_context.Equipments.Where(x => x.CompanyId == companyId));

        public async Task AddEquipment(Equipment equipment)
        {
            await _context.Equipments.AddAsync(equipment);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteEquipment(Guid id)
        {
            var eq = await GetById(id);
            _context.Equipments.Remove(eq);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateEquipment(Equipment equipment)
        {
            _context.Equipments.Update(equipment);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}