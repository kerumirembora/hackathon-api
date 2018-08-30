using Hackathon.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByUserName(string userName);
        List<User> GetAllUserGoalSubscribers(int userGoalId);
    }
}
