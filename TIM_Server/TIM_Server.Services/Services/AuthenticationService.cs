using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TIM_Server.Core.IRepositories;
using TIM_Server.Core.Model;
using TIM_Server.Infrastructure.Authorization;
using TIM_Server.Services.IServices;

namespace TIM_Server.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly ICommanderRepository _commanderRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly ISoldierRepository _soldierRepository;

        public AuthenticationService(IJwtHandler jwtHandler, IAdminRepository adminRepository,
            ISoldierRepository soldierRepository, ICommanderRepository commanderRepository)
        {
            _jwtHandler = jwtHandler;
            _adminRepository = adminRepository;
            _soldierRepository = soldierRepository;
            _commanderRepository = commanderRepository;
        }

        public async Task<string> Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return null;

            var soldier = await _soldierRepository.GetByEmail(userName);

            if (soldier != null)
                return !_jwtHandler.VerifyPasswordHash(password, soldier.PasswordHash, soldier.PasswordSalt)
                    ? null
                    : _jwtHandler.CreateToken(soldier);
            var commander = await _commanderRepository.GetByEmail(userName);
            if (commander != null)
                return !_jwtHandler.VerifyPasswordHash(password, commander.PasswordHash, commander.PasswordSalt)
                    ? null
                    : _jwtHandler.CreateToken(commander);
            var admin = await _adminRepository.GetByEmail(userName);
            if (admin != null)
                return !_jwtHandler.VerifyPasswordHash(password, admin.PasswordHash, admin.PasswordSalt)
                    ? null
                    : _jwtHandler.CreateToken(admin);
            return null;
        }

        public async Task Register(string role, string millitaryRank, string firstName, string lastName, string email,
            string phoneNumber, string pesel,
            string postCode, string city, string street, string houseNumber, string password)
        {
            if (await IfExistTask(email, pesel)) throw new Exception("User already exist");

            var hmac = new HMACSHA512();

            switch (role)
            {
                case "Soldier":
                    var soldierToCreate = new Soldier(Guid.NewGuid(),
                        hmac.ComputeHash(Encoding.UTF8.GetBytes(password)), hmac.Key, role, millitaryRank, firstName,
                        lastName, email, phoneNumber, pesel, postCode, city, street, houseNumber);

                    await _soldierRepository.AddSoldier(soldierToCreate);
                    break;
                case "Commander":
                    var commanderToCreate = new Commander(Guid.NewGuid(),
                        hmac.ComputeHash(Encoding.UTF8.GetBytes(password)), hmac.Key, role, millitaryRank, firstName,
                        lastName, email, phoneNumber, pesel, postCode, city, street, houseNumber);
                    await _commanderRepository.AddCommander(commanderToCreate);
                    break;
                case "Admin":
                    var adminToCreate = new Admin(Guid.NewGuid(),
                        hmac.ComputeHash(Encoding.UTF8.GetBytes(password)), hmac.Key, role, millitaryRank, firstName,
                        lastName, email, phoneNumber, pesel, postCode, city, street, houseNumber);
                    await _adminRepository.AddAdmin(adminToCreate);
                    break;
                default:
                    throw new Exception("Something went wrong");
            }
        }

        private async Task<bool> IfExistTask(string email, string pesel)
        {
            var soldier = await _soldierRepository.GetByEmail(email);
            if (soldier != null) return true;
            soldier = await _soldierRepository.GetByPesel(pesel);
            if (soldier != null) return true;

            var commander = await _commanderRepository.GetByEmail(email);
            if (commander != null) return true;
            commander = await _commanderRepository.GetByPesel(pesel);
            if (commander != null) return true;

            var admin = await _adminRepository.GetByEmail(email);
            if (admin != null) return true;
            admin = await _adminRepository.GetByPesel(pesel);
            if (admin != null) return true;

            return false;
        }
    }
}