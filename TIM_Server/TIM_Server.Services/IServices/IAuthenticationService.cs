using System.Threading.Tasks;

namespace TIM_Server.Services.IServices
{
    public interface IAuthenticationService
    {
        Task<string> Login(string userName, string password);

        Task Register(string role, string millitaryRank, string firstName, string lastName, string email,
            string phoneNumber, string pesel,
            string postCode, string city, string street, string houseNumber, string password);
    }
}