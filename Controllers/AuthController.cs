using Microsoft.AspNetCore.Mvc;
using SwaggerAutoAuthentication.Services.Interfaces;
using SwaggerAutoAuthentication.ViewModels;

namespace SwaggerAutoAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequest authLogin)
        {
            var result = await authService.LoginUserAsync(authLogin);

            return Ok(result);
        }

    }

}
