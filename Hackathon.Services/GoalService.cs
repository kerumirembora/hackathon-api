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
        IEventService _eventService;
        IBankingService _bankingService;

        public GoalService(IGoalTypeRepository goalTypeRepository, IUserGoalRepository userGoalRepository, IEventRepository eventRepository, IGoalSubscriberRepository goalSubscriberRepository, IEventService eventService, IBankingService bankingService)
        {
            _goalTypeRepository = goalTypeRepository;
            _userGoalRepository = userGoalRepository;
            _eventRepository = eventRepository;
            _goalSubscriberRepository = goalSubscriberRepository;
            _eventService = eventService;
            _bankingService = bankingService;
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
            if (subscriber != null && completedAmountIncrement > 0)
            {
                subscriber.CompletedAmount += completedAmountIncrement;
                // for now update only completed amount
                //subscriber.MoneyAmountSaved = moneyAmountSaved;
                //subscriber.SavingTransferAmount = savingTransferAmount;

                await _goalSubscriberRepository.Update(subscriber.Id, subscriber);
                string eventMessage = $"{subscriber.Subscriber.Name} increased goal by {completedAmountIncrement}";
                await _eventService.AddEventToAllUserSubscribers(subscriber.UserGoalId, eventMessage);

                if (subscriber.SavingTransferAmount.HasValue)
                {
                    await _bankingService.TransferToSavingsAccount(userId, subscriber.SavingTransferAmount.Value);
                }

                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
