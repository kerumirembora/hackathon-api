using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Repositories.SQLLite
{
    public class SQLLiteNotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public SQLLiteNotificationRepository(SQLLiteContext dbContext) : base(dbContext) { }

        public List<Notification> GetByUserId(int userId)
        {
            return Context.Notifications
                .Where(n => n.UserId == userId)
                .ToList();
        }

    }
}
