using Hackathon.API.DataTransferObjects;
using Hackathon.Model;
using System.Collections.Generic;
using System.Linq;

namespace Hackathon.API.Mappers
{
    public static class NotificationMappingExtension
    {
        public static GetUserNotificationsOutputDto ToGetUserNotificationsOutputDto(this List<Notification> notifications)
        {
            if (notifications == null)
                return new GetUserNotificationsOutputDto();

            return new GetUserNotificationsOutputDto
            {
                Notifications = notifications.Select(n => new UserNotificationsOutputDto
                {
                    CreationDate = n.CreationDate,
                    ExpirationDate = n.ExpirationDate,
                    Id = n.Id,
                    Message = n.Message,
                    UserGoalId = n.UserGoalId,
                    UserId = n.UserId
                }).ToList()
            };


        }
    }
}
