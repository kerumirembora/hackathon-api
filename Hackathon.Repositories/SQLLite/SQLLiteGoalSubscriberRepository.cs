using Hackathon.Model;
using Hackathon.Repositories.Interfaces;

namespace Hackathon.Repositories.SQLLite
{
    public class SQLLiteGoalSubscriberRepository : BaseRepository<GoalSubscriber>, IGoalSubscriberRepository
    {
        public SQLLiteGoalSubscriberRepository(SQLLiteContext dbContext) : base(dbContext) { }

    }
}
