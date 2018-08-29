using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Hackathon.Repositories.SQLLite;
using Hackathon.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        INotificationRepository _notificationRepository;

        public UserService(IUserRepository userRepository, INotificationRepository notificationRepository)
        {
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
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
