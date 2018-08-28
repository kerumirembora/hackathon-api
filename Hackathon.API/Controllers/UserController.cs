﻿using Hackathon.API.DTO;
using Hackathon.Model;
using Hackathon.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<ActionResult<User>> Post([FromBody] UserLoginInputDTO input)
        {
            User user = await _loginService.Login(input.UserName);
            if (user == null)
                return NotFound();
            else
                return user;

        }

    }
}
