using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Hackathon.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hackathon.Services
{
    public class GoalService : IGoalService
    {
        IGoalTypeRepository _goalTypeRepository;

        public GoalService(IGoalTypeRepository goalTypeRepository)
        {
            _goalTypeRepository = goalTypeRepository;
        }

        public List<GoalType> GetAllGoalTypes()
        {
            return _goalTypeRepository.GetAll().ToList();
        }

        public List<UserGoal> GetUserGoalDetails(int userGoalId)
        {
            throw new System.NotImplementedException();
        }
    }
}
