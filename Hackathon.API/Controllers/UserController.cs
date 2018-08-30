﻿using Hackathon.API.DataTransferObjects;
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

        /// <summary>
        /// Gets a list of all available users
        /// </summary>
        /// <returns>List of Users</returns>
        [HttpGet]
        public ActionResult<GetAllUsersOutputDto> GetAllUsers()
        {
            return _userService.GetAllUsers().ToGetAllUsersOutputDto();
        }

        /// <summary>
        /// Fake Login/Authentication 
        /// </summary>
        /// <param name="input">User Name</param>
        /// <returns>User info and subscribed goals</returns>
        [HttpPost]
        public async Task<ActionResult<UserLoginOutputDto>> LoginSortOf([FromBody] UserLoginInputDto input)
        {
            User user = await _userService.Login(input.UserName);

            if (user == null)
                return NotFound();
            else
                return user.ToUserLoginOutputDto();

        }

        /// <summary>
        /// Creates a User Goal
        /// </summary>
        /// <param name="input">Data needed to commit the request</param>
        /// <returns>Created user goal id</returns>
        [HttpPost("{userId}/usergoal")]
        public async Task<ActionResult<CreateUserGoalOutputDto>> CreateUserGoal([FromBody] CreateUserGoalInputDto input)
        {
            int userGoalId = await _userService.CreateUserGoal(input.UserId, input.Name, input.AmountLimit, input.Unit, input.DeadlineDate, input.GoalTypeId);

            return new CreateUserGoalOutputDto { UserGoalId = userGoalId };
        }

        /// <summary>
        /// Subscribes/adds/invites a user to a user goal
        /// </summary>
        /// <param name="input">Data needed to commit the request</param>
        /// <returns>Subscriber id</returns>
        [HttpPut("{userId}/usergoal/{userGoalId}/subscriber")]
        public async Task<ActionResult<SubscribeUserGoalOutputDto>> SubscribeUserGoal([FromBody] SubscribeUserGoalInputDto input, [FromRoute] int userGoalId)
        {
            int subscriberId = await _userService.AddSubscriberToUserGoal(input.UserId, userGoalId);

            return new SubscribeUserGoalOutputDto { SubscriberId = subscriberId };
        }

        /// <summary>
        /// Get user notifications
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>List of user notifications</returns>
        [HttpGet("{userId}/notification", Name = "GetUserNotifications")]
        public ActionResult<GetUserNotificationsOutputDto> GetUserNotifications(int userId)
        {
            return _userService.GetNotifications(userId).ToGetUserNotificationsOutputDto();
        }


    }
}
