using Hackathon.API.DataTransferObjects;
using Hackathon.API.Mappers;
using Hackathon.Model;
using Hackathon.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserLoginOutputDto>> Post([FromBody] UserLoginInputDto input)
        {
            User user = await _userService.Login(input.UserName);

            if (user == null)
                return NotFound();
            else
                return user.ToUserLoginOutputDto();

        }

        [HttpGet("{userId}/notification", Name = "GetUserNotifications")]
        public IEnumerable<Notification> GetUserNotifications(int userId)
        {
            return _userService.GetNotifications(userId);
        }


    }
}
