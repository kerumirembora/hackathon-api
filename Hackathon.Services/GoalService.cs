using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Hackathon.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class GoalService : IGoalService
    {
        IGoalTypeRepository _goalTypeRepository;
        IUserGoalRepository _userGoalRepository;

        public GoalService(IGoalTypeRepository goalTypeRepository, IUserGoalRepository userGoalRepository)
        {
            _goalTypeRepository = goalTypeRepository;
            _userGoalRepository = userGoalRepository;
        }

        public List<GoalType> GetAllGoalTypes()
        {
            return _goalTypeRepository.GetAll().ToList();
        }

        public async Task<UserGoal> GetUserGoalDetails(int userGoalId, int loggedUserId)
        {
            UserGoal userGoal = await _userGoalRepository.GetUserGoalWithSubscribers(userGoalId);
            

            return userGoal;
        }
    }
}
