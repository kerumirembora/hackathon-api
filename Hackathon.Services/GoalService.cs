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
        IEventRepository _eventRepository;

        public GoalService(IGoalTypeRepository goalTypeRepository, IUserGoalRepository userGoalRepository, IEventRepository eventRepository)
        {
            _goalTypeRepository = goalTypeRepository;
            _userGoalRepository = userGoalRepository;
            _eventRepository = eventRepository;
        }

        public List<GoalType> GetAllGoalTypes()
        {
            return _goalTypeRepository.GetAll().ToList();
        }

        public async Task<(UserGoal UserGoal, List<Event> LoggedUserEvents)> GetUserGoalDetails(int userGoalId, int loggedUserId)
        {
            UserGoal userGoal = await _userGoalRepository.GetUserGoalWithSubscribers(userGoalId);
            List<Event> loggedUserEvents = _eventRepository.GetUserGoalSubscriberEvents(userGoalId, loggedUserId);

            return (userGoal, loggedUserEvents);
        }
    }
}
