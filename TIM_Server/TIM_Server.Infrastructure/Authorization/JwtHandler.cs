using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TIM_Server.Core.Model;

namespace TIM_Server.Infrastructure.Authorization
{
    public class JwtHandler : IJwtHandler
    {
        private readonly IOptions<JwtOptions> _jwtOptions;
        public JwtHandler(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }
        public string CreateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("FirstName",user.FirstName),
                new Claim("LastName",user.LastName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_jwtOptions.Value.SecretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var now = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = creds,
                Issuer = _jwtOptions.Value.Issuer
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenToReturn = tokenHandler.WriteToken(token);
            return tokenToReturn;
        }

        public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}