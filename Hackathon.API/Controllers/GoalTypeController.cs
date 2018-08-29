using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.Model;
using Hackathon.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [Route("api/goaltype")]
    [ApiController]
    public class GoalTypeController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalTypeController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet]
        public IEnumerable<GoalType> Get()
        {
            return  _goalService.GetGoalTypes();
        }

    }
}
