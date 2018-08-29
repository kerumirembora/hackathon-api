using Hackathon.Model;
using Hackathon.Repositories.Interfaces;

namespace Hackathon.Repositories.SQLLite
{
    public class SQLLiteEventRepository : BaseRepository<Event>, IEventRepository
    {
        public SQLLiteEventRepository(SQLLiteContext dbContext) : base(dbContext) { }

    }
}
