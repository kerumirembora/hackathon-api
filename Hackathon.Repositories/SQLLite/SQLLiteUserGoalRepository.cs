using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Repositories.SQLLite
{
    public class SQLLiteUserGoalRepository : BaseRepository<UserGoal>, IUserGoalRepository
    {
        public SQLLiteUserGoalRepository(SQLLiteContext dbContext) : base(dbContext) { }

        public async Task<UserGoal> GetUserGoalWithSubscribers(int userGoalId)
        {
            return await Context.UserGoals
                .Include(ug => ug.Subscribers)
                    .ThenInclude(s=>s.Subscriber)
                .Include(ug => ug.GoalType)
                .FirstOrDefaultAsync(ug => ug.Id == userGoalId);
        }
    }
}
