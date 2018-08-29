using Hackathon.Model;
using Hackathon.Repositories.Interfaces;

namespace Hackathon.Repositories.SQLLite
{
    public class SQLLiteGoalTypeRepository : BaseRepository<GoalType>, IGoalTypeRepository
    {
        public SQLLiteGoalTypeRepository(SQLLiteContext dbContext) : base(dbContext) { }

    }
}
