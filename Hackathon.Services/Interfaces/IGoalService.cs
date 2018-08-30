using Hackathon.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Services.Interfaces
{
    public interface IGoalService
    {
        List<GoalType> GetAllGoalTypes();
        Task<UserGoal> GetUserGoalDetails(int userGoalId, int loggedUserId);
    }
}
