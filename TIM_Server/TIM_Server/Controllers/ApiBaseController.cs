using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TIM_Server.Application.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public abstract class ApiBaseController : Controller
    {
        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
            Guid.Parse(User.Identity.Name) : Guid.Empty;
    }
}