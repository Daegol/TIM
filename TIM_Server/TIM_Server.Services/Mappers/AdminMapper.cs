using TIM_Server.Core.Model;
using TIM_Server.Services.DTOs.Users;

namespace TIM_Server.Services.Mappers
{
    public static class AdminMapper
    {
        public static AdminDto AdminMap(Admin admin)
        {
            return new AdminDto
            {
                Id = 0,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Email = admin.Email,
                PhoneNumber = admin.PhoneNumber,
                Pesel = admin.Pesel,
                Address = admin.Street + ' ' + admin.HouseNumber + '\n' + admin.PostCode + ' ' + admin.City,
                MilitaryRank = admin.MilitaryRank
            };

        }

        public static Admin UpdateAdminMap(UpdateAdminDto adminDto, Admin admin)
        {
            admin.FirstName = adminDto.FirstName;
            admin.LastName = adminDto.LastName;
            admin.Email = adminDto.Email;
            admin.Pesel = adminDto.Pesel;
            admin.PhoneNumber = adminDto.PhoneNumber;
            admin.Street = adminDto.Address.Substring(0, adminDto.Address.IndexOf(' '));
            adminDto.Address = adminDto.Address.Remove(0, adminDto.Address.IndexOf(' ') + 1);
            admin.HouseNumber = adminDto.Address.Substring(0, adminDto.Address.IndexOf(' '));
            adminDto.Address = adminDto.Address.Remove(0, adminDto.Address.IndexOf(' ') + 1);
            admin.PostCode = adminDto.Address.Substring(0, adminDto.Address.IndexOf(' '));
            adminDto.Address = adminDto.Address.Remove(0, adminDto.Address.IndexOf(' ') + 1);
            admin.City = adminDto.Address.Substring(0, adminDto.Address.Length);
            admin.MilitaryRank = adminDto.MilitaryRank;
            return admin;
        }
    }
}