using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIM_Server.Core.IRepositories;
using TIM_Server.Services.DTOs.Company;
using TIM_Server.Services.DTOs.Users;
using TIM_Server.Services.IServices;
using TIM_Server.Services.Mappers;

namespace TIM_Server.Services.Services
{
    public class CommanderService : ICommanderService
    {
        private readonly ICommanderRepository _commanderRepository;

        public CommanderService(ICommanderRepository commanderRepository)
        {
            _commanderRepository = commanderRepository;
        }

        public async Task<IEnumerable<CommanderDto>> GetCommanders()
        {
            var commanders = await _commanderRepository.Get();
            var commanderDtos = commanders.Select(CommanderMapper.CommanderMap);
            int id = 1;
            foreach (var commander in commanderDtos)
            {
                commander.Id = id;
                id++;
            }

            return commanderDtos;
        }

        public async Task DeleteCommander(string pesel)
        {
            await _commanderRepository.DeleteCommander(pesel);
        }

        public async Task UpdateCommander(UpdateCommanderDto commanderDto)
        {
            var commander = await _commanderRepository.GetByPesel(commanderDto.Pesel);
            commander = CommanderMapper.UpdateCommanderMap(commanderDto, commander);
            await _commanderRepository.UpdateCommander(commander);
        }

        public async Task<IEnumerable<CommanderToCompanyDto>> GetCommandersToCompany()
        {
            var commanders = await _commanderRepository.Get();
            var commanderDtos = commanders.Select(CommanderMapper.CommanderToCompanyMap);
            return commanderDtos;
        }
    }
}