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
        public async Task<IActionResult> Login(AuthLogin authLogin)
        {
            var result = await authService.LoginUserAsync(new UserLoginRequest() { Username = authLogin.Kuser, Password = authLogin.Kpass });

            return Ok(result);
        }

    }

    public class AuthLogin
    {
        public string Kuser { get; set; }
        public string Kpass { get; set; }
    }


}
