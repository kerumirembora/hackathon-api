using System.Threading.Tasks;
using Hackathon.API.DataTransferObjects;
using Hackathon.API.Mappers;
using Hackathon.Services.Interfaces;
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
        [HttpPost("{id}/subscriber/{userId}")]
        public async Task<ActionResult<bool>> UpdateUserGoalAmount(int id, int userId, [FromBody] UpdateGoalSubscriberDetailsInputDto input)
        {
            var updated = await _goalService.UpdateGoalSubscriberAmount(userId, id, input.CompletedAmountIncrement, input.MoneyAmountSaved, input.SavingTransferAmount);

            return Ok();
        }

    }
}
