﻿using Hackathon.Model;
using System.Threading.Tasks;

namespace Hackathon.Repositories.Interfaces
{
    public interface IGoalSubscriberRepository : IBaseRepository<GoalSubscriber>
    {
        Task<bool> Exists(int userId, int userGoalId);
        Task<GoalSubscriber> Get(int userId, int userGoalId);
    }
}

