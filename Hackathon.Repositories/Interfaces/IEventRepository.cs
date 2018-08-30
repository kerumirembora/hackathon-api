using Hackathon.Model;
using System.Collections.Generic;

namespace Hackathon.Repositories.Interfaces
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        List<Event> GetUserGoalSubscriberEvents(int userGoalId, int loggedUserId);
    }
}
