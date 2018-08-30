using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Repositories.SQLLite
{
    public class SQLLiteUserRepository : BaseRepository<User>, IUserRepository
    {
        public SQLLiteUserRepository(SQLLiteContext dbContext) : base(dbContext) { }

        public List<User> GetAllUserGoalSubscribers(int userGoalId)
        {
            return Context.UserGoals
                .Include(ug => ug.Subscribers)
                    .ThenInclude(s => s.Subscriber)
                .Where(ug => ug.Id == userGoalId)
                .SelectMany(ug => ug.Subscribers.Select(s => s.Subscriber))
                .ToList();
        }

        public async Task<User> GetByUserName(string userName)
        {
            return await Context.Users
                .Include(u => u.Notifications)
                .Include(u => u.SubscribedGoals)
                    .ThenInclude(sg=> sg.UserGoal)
                    .ThenInclude(ug=> ug.GoalType)
                .Include(u => u.SubscribedGoals)
                    .ThenInclude(sg=>sg.Events)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.UserName == userName);
        }
    }
}
