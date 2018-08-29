using Hackathon.API.DataTransferObjects;
using Hackathon.API.Mappers;
using Hackathon.Model;
using Hackathon.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hackathon.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public UserController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult<UserLoginOutputDto>> Post([FromBody] UserLoginInputDto input)
        {
            User user = await _loginService.Login(input.UserName);

            if (user == null)
                return NotFound();
            else
                return user.ToUserLoginOutputDto();

        }

        // GET: api/Default/5
        [HttpGet("{id}/usergoal", Name = "GetUserGoals")]
        public string GetUserGoals(int id)
        {
            return "value";
        }


    }
}
