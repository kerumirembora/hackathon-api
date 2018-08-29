using Hackathon.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Repositories.Interfaces
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        List<Notification> GetByUserId(int userId);
    }
}
