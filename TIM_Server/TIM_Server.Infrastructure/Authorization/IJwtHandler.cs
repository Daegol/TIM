using TIM_Server.Core.Model;

namespace TIM_Server.Infrastructure.Authorization
{
    public interface IJwtHandler
    {
        string CreateToken(User user);
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
    }
}