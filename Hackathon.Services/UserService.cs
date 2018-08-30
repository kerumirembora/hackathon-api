using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Hackathon.Repositories.SQLLite;
using Hackathon.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        INotificationRepository _notificationRepository;
        IUserGoalRepository _userGoalRepository;
        IGoalSubscriberRepository _goalSubscriberRepository;

        public UserService(IUserRepository userRepository, INotificationRepository notificationRepository, IUserGoalRepository userGoalRepository, IGoalSubscriberRepository goalSubscriberRepository)
        {
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
            _userGoalRepository = userGoalRepository;
            _goalSubscriberRepository = goalSubscriberRepository;
        }

        public async Task<int> AddSubscriberToUserGoal(int userId, int userGoalId)
        {
            int subscriberId = -1;

            bool exists = await _goalSubscriberRepository.Exists(userId, userGoalId);
            if (!exists)
            {
                subscriberId = await _goalSubscriberRepository.Create(new GoalSubscriber {
                    CompletedAmount = 0,
                    MoneyAmountSaved = 0,
                    SavingTransferAmount = 0,
                    SubscriberId = userId,
                    UserGoalId = userGoalId
                });
            }

            return subscriberId;
        }

        public async Task<int> CreateUserGoal(int userId, string name, int amount, string unit, DateTime deadlineDate, int goalTypeId, int savingsAmount)
        {
            //Create user goal and add creating user as a subscriber
            UserGoal userGoal = new UserGoal
            {
                AdministrationUserId = userId,
                Amount = amount,
                DeadlineDate = deadlineDate,
                GoalTypeId = goalTypeId,
                Name = name,
                Unit = unit,
                Subscribers = new List<GoalSubscriber> { new GoalSubscriber
                                {
                                    CompletedAmount = 0,
                                    MoneyAmountSaved = 0,
                                    SubscriberId = userId,
                                    SavingTransferAmount = savingsAmount
                                }
                }
            };

            // return created user goal id
            return await _userGoalRepository.Create(userGoal);
        }

        public List<User> GetAllSubscribableUsers(int userGoalId)
        {
            var allUsers = _userRepository.GetAll();
            var userGoalSubscribers = _userRepository.GetAllUserGoalSubscribers(userGoalId);
            return allUsers.Where(x => !userGoalSubscribers.Any(y => y.Id == x.Id)).ToList();

            //return allUsers.Except(userGoalSubscribers).ToList();
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll().ToList();
        }

        public List<Notification> GetNotifications(int userId)
        {
            return _notificationRepository.GetByUserId(userId);
        }

        public async Task<User> Login(string userName)
        {
            return await _userRepository.GetByUserName(userName);
        }

    }
}
