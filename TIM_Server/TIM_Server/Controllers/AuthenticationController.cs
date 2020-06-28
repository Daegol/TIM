using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TIM_Server.Infrastructure.Authorization;
using TIM_Server.Services.DTOs;
using TIM_Server.Services.DTOs.Users;
using TIM_Server.Services.IServices;

namespace TIM_Server.Application.Controllers
{
    public class AuthenticationController : ApiBaseController
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService, IOptions<JwtOptions> jwtOptions)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userFromLoginDto)
        {
            var token = await _authService.Login(userFromLoginDto.Username, userFromLoginDto.Password);
            if (token == null) return BadRequest("Username or password is incorrect");
            return Ok(new
            {
                token = token
            });
        }

        //[Authorize(Policy = "Admin")]
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userFroRegisterDto)
        {

            await _authService.Register(userFroRegisterDto.Role, userFroRegisterDto.MilitaryRank, userFroRegisterDto.FirstName,
                userFroRegisterDto.LastName, userFroRegisterDto.Email, userFroRegisterDto.PhoneNumber,
                userFroRegisterDto.Pesel, userFroRegisterDto.PostCode, userFroRegisterDto.City,
                userFroRegisterDto.Street, userFroRegisterDto.HouseNumber, userFroRegisterDto.Password);

            return StatusCode(201);
        }
    }
}