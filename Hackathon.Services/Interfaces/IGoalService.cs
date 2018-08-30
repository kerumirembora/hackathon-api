using Hackathon.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Services.Interfaces
{
    public interface IGoalService
    {
        List<GoalType> GetAllGoalTypes();
        Task<(UserGoal UserGoal, List<Event> LoggedUserEvents)> GetUserGoalDetails(int userGoalId, int loggedUserId);
    }
}
