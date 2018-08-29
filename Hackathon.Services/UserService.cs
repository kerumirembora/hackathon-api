using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Hackathon.Repositories.SQLLite;
using Hackathon.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        INotificationRepository _notificationRepository;
        IUserGoalRepository _userGoalRepository;

        public UserService(IUserRepository userRepository, INotificationRepository notificationRepository, IUserGoalRepository userGoalRepository)
        {
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
            _userGoalRepository = userGoalRepository;
        }

        public async Task<int> CreateUserGoal(int userId, string name, int amount, string unit, DateTime deadlineDate, int goalTypeId)
        {
            //Create user goal
            UserGoal userGoal = new UserGoal
            {
                AdministrationUserId = userId,
                Amount = amount,
                DeadlineDate = deadlineDate,
                GoalTypeId = goalTypeId,
                Name = name,
                Unit = unit
            };

            int userGoalId = await _userGoalRepository.Create(userGoal);

            //add user goal creating user as a subscriber to the previously created goal
            GoalSubscriber subscriber = new GoalSubscriber
            {
                CompletedAmount = 0,
                MoneyAmountSaved = 0,
                SubscriberId = userId,
                UserGoalId = userGoalId
            };

            await _userGoalRepository.Create(userGoal);

            return userGoalId;
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
