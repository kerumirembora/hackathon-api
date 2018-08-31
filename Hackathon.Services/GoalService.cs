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
        IGoalSubscriberRepository _goalSubscriberRepository;

        public GoalService(IGoalTypeRepository goalTypeRepository, IUserGoalRepository userGoalRepository, IEventRepository eventRepository, IGoalSubscriberRepository goalSubscriberRepository)
        {
            _goalTypeRepository = goalTypeRepository;
            _userGoalRepository = userGoalRepository;
            _eventRepository = eventRepository;
            _goalSubscriberRepository = goalSubscriberRepository;
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

        public async Task<bool> UpdateGoalSubscriberAmount(int userId, int userGoalId, int completedAmountIncrement, int moneyAmountSaved, int? savingTransferAmount)
        {
            var subscriber = await _goalSubscriberRepository.Get(userId, userGoalId);
            if (subscriber != null)
            {
                subscriber.CompletedAmount += completedAmountIncrement;
                // for now update only completed amount
                //subscriber.MoneyAmountSaved = moneyAmountSaved;
                //subscriber.SavingTransferAmount = savingTransferAmount;

                await _goalSubscriberRepository.Update(subscriber.Id, subscriber);

                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}
