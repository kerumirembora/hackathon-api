using Hackathon.Model;
using System.Threading.Tasks;

namespace Hackathon.Repositories.Interfaces
{
    public interface IUserGoalRepository : IBaseRepository<UserGoal>
    {
        Task<UserGoal> GetUserGoalWithSubscribers(int userGoalId);
    }
}
