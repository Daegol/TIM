using System.Collections.Generic;
using System.Threading.Tasks;
using TIM_Server.Services.DTOs.Users;

namespace TIM_Server.Services.IServices
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminDto>> GetAdmins();

        Task DeleteAdmin(string pesel);
        Task UpdateAdmin(UpdateAdminDto adminDto);
    }
}