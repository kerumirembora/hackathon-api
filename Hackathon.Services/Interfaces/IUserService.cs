﻿using Hackathon.Model;
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
        Task<int> CreateUserGoal(int userId, string name, int amount, string unit, DateTime deadlineDate, int goalTypeId);
        Task<int> AddSubscriberToUserGoal(int userId, int userGoalId);
    }
}
