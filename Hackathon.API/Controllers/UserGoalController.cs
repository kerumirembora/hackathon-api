﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.API.DataTransferObjects;
using Hackathon.API.Mappers;
using Hackathon.Model;
using Hackathon.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [Route("api/usergoal")]
    [ApiController]
    public class UserGoalController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public UserGoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        /// <summary>
        /// Gets a user goal detail
        /// </summary>
        /// <returns>List of Goal Types</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserGoalDetailsOutputDto>> GetUserGoalDetails(int id, int loggedUserId)
        {
            var userGoal = await _goalService.GetUserGoalDetails(id, loggedUserId);
            return userGoal.ToGetUserGoalDetailsOutputDto(loggedUserId);
        }

        /// <summary>
        /// Updates User Goal Amount
        /// </summary>
        /// <returns>List of Goal Types</returns>
        [HttpPost("{id}/subscriber/{subscriberId}")]
        public async Task<ActionResult<GetUserGoalDetailsOutputDto>> Get(int id, int subscriberId)
        {
            //var userGoal = await _goalService.GetUserGoalDetails(id, loggedUserId);
            //return userGoal.ToGetUserGoalDetailsOutputDto(loggedUserId);
        }

    }
}