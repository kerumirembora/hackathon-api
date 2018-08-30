using System.Collections.Generic;
using System.Linq;
using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Repositories.SQLLite
{
    public class SQLLiteEventRepository : BaseRepository<Event>, IEventRepository
    {
        public SQLLiteEventRepository(SQLLiteContext dbContext) : base(dbContext) { }

        public List<Event> GetUserGoalSubscriberEvents(int userGoalId, int loggedUserId)
        {
            return Context.Events
                .Include(e=>e.GoalSubscriber)
                    .ThenInclude(gs => gs.Subscriber)
                .Where(e => e.GoalSubscriber.SubscriberId == loggedUserId &&
                            e.GoalSubscriber.UserGoal.Id == userGoalId)
                .ToList();
        }
    }
}
