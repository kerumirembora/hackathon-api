using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.API.DataTransferObjects
{
    public class GetUserNotificationsOutputDto
    {
        public List<UserNotificationsOutputDto> Notifications { get; set; }

        public GetUserNotificationsOutputDto()
        {
            Notifications = new List<UserNotificationsOutputDto>();
        }
    }

    public class UserNotificationsOutputDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }
        public int? UserGoalId { get; set; }
    }
}
