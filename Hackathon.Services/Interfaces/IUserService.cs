using Hackathon.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Login(string userName);
        List<Notification> GetNotifications(int userId);

    }
}
