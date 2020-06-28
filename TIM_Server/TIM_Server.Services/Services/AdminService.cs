using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIM_Server.Core.IRepositories;
using TIM_Server.Core.Model;
using TIM_Server.Services.DTOs.Users;
using TIM_Server.Services.IServices;
using TIM_Server.Services.Mappers;

namespace TIM_Server.Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<IEnumerable<AdminDto>> GetAdmins()
        {
            var admins = await _adminRepository.Get();
            var adminDtos = admins.Select(AdminMapper.AdminMap);
            int id = 1;
            foreach (var admin in adminDtos)
            {
                admin.Id = id;
                id++;
            }

            return adminDtos;
        }

        public async Task DeleteAdmin(string pesel)
        {
            await _adminRepository.DeleteAdmin(pesel);
        }

        public async Task UpdateAdmin(UpdateAdminDto adminDto)
        {
            var admin = await _adminRepository.GetByPesel(adminDto.Pesel);
            admin = AdminMapper.UpdateAdminMap(adminDto, admin);
            await _adminRepository.UpdateAdmin(admin);
        }
    }
}