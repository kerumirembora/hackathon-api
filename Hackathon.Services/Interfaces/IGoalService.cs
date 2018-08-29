using Hackathon.Model;
using System.Collections.Generic;

namespace Hackathon.Services.Interfaces
{
    public interface IGoalService
    {
        List<GoalType> GetGoalTypes();

        bool CreateUserGoal();
    }
}
