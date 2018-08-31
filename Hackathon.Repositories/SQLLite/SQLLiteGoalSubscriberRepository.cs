using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Repositories.SQLLite
{
    public class SQLLiteGoalSubscriberRepository : BaseRepository<GoalSubscriber>, IGoalSubscriberRepository
    {
        public SQLLiteGoalSubscriberRepository(SQLLiteContext dbContext) : base(dbContext) { }

        public async Task<bool> Exists(int userId, int userGoalId)
        {
            return await Context.GoalSubscribers
                .AnyAsync(gs => gs.UserGoalId == userGoalId && gs.SubscriberId == userId);
        }

        public async Task<GoalSubscriber> Get(int userId, int userGoalId)
        {
            return await Context.GoalSubscribers
                .Include(gs=>gs.Subscriber)
                .FirstOrDefaultAsync(gs => gs.SubscriberId == userId && gs.UserGoalId == userGoalId);
        }

        public List<GoalSubscriber> GetAllByUserGoal(int userGoalId)
        {
            return Context.GoalSubscribers
                .Include(gs=>gs.Events)
                .Where(gs => gs.UserGoalId == userGoalId).ToList();
        }
    }
}
