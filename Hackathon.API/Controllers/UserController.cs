using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.Services.Interfaces;
using Hackathon.Services.Model;
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
            return _loginService.Login(userName);
        }

    }
}
