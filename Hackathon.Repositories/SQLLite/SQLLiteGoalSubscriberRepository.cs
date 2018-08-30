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
            return await Context.GoalSubscribers.AnyAsync(gs => gs.UserGoalId == userGoalId && gs.SubscriberId == userId);
        }
    }
}
