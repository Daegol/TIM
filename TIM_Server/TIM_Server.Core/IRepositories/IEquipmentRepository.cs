using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIM_Server.Core.Model;

namespace TIM_Server.Core.IRepositories
{
    public interface IEquipmentRepository
    {
        Task<Equipment> GetById(Guid id);
        Task<IEnumerable<Equipment>> GetAll(Guid companyId);
        Task AddEquipment(Equipment equipment);
        Task DeleteEquipment(Guid id);
        Task UpdateEquipment(Equipment equipment);
    }
}