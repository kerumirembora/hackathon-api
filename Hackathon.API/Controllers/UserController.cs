using Hackathon.Model;
using Hackathon.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public UserController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<User> Post([FromBody] string userName)
        {
            User user = _loginService.Login(userName);
            if (user == null)
                return NotFound();
            else
                return user;

        }

    }
}
