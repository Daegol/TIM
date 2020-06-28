using TIM_Server.Core.Model;
using TIM_Server.Services.DTOs.Company;
using TIM_Server.Services.DTOs.Users;

namespace TIM_Server.Services.Mappers
{
    public static class CommanderMapper
    {
        public static CommanderDto CommanderMap(Commander commander)
        {
            return new CommanderDto
            {
                Id = 0,
                FirstName = commander.FirstName,
                LastName = commander.LastName,
                Email = commander.Email,
                PhoneNumber = commander.PhoneNumber,
                Pesel = commander.Pesel,
                Address = commander.Street + ' ' + commander.HouseNumber + '\n' + commander.PostCode + ' ' + commander.City,
                MilitaryRank = commander.MilitaryRank
            };

        }

        public static Commander UpdateCommanderMap(UpdateCommanderDto commanderDto, Commander commander)
        {
            commander.FirstName = commanderDto.FirstName;
            commander.LastName = commanderDto.LastName;
            commander.Email = commanderDto.Email;
            commander.Pesel = commanderDto.Pesel;
            commander.PhoneNumber = commanderDto.PhoneNumber;
            commander.Street = commanderDto.Address.Substring(0, commanderDto.Address.IndexOf(' '));
            commanderDto.Address = commanderDto.Address.Remove(0, commanderDto.Address.IndexOf(' ') + 1);
            commander.HouseNumber = commanderDto.Address.Substring(0, commanderDto.Address.IndexOf(' '));
            commanderDto.Address = commanderDto.Address.Remove(0, commanderDto.Address.IndexOf(' ') + 1);
            commander.PostCode = commanderDto.Address.Substring(0, commanderDto.Address.IndexOf(' '));
            commanderDto.Address = commanderDto.Address.Remove(0, commanderDto.Address.IndexOf(' ') + 1);
            commander.City = commanderDto.Address.Substring(0, commanderDto.Address.Length);
            commander.MilitaryRank = commanderDto.MilitaryRank;
            return commander;
        }

        public static CommanderToCompanyDto CommanderToCompanyMap(Commander commander)
        {
            return new CommanderToCompanyDto
            {
                Id = commander.Id,
                FirstName = commander.FirstName,
                LastName = commander.LastName,
                Pesel = commander.Pesel
            };

        }
    }
}