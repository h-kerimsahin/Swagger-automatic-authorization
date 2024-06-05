using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerAutoAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var user = new List<string>();
            user.Add("Ahmet");
            user.Add("Kazım");
            user.Add("Mehmet");
            user.Add("Ayşe");
            user.Add("Fatma");
            user.Add("Elif");
            user.Add("Hazal");
            user.Add("Emre");
            user.Add("Ali");

            return Ok(user);
        }
    }
}
