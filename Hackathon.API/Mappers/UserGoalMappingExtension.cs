using Hackathon.API.DataTransferObjects;
using Hackathon.Model;
using System.Collections.Generic;
using System.Linq;

namespace Hackathon.API.Mappers
{
    public static class UserGoalMappingExtension
    {
        public static GetUserGoalDetailsOutputDto ToGetUserGoalDetailsOutputDto(this UserGoal userGoal)
        {
            return new GetUserGoalDetailsOutputDto
            {
                AdministrationUserId = userGoal.AdministrationUserId,
                Amount = userGoal.Amount,
                DeadlineDate = userGoal.DeadlineDate,
                GoalType = new GoalTypeOutputDto
                {
                    Description = userGoal.GoalType.Description,
                    Id = userGoal.GoalType.Id,
                    MetricDescription = userGoal.GoalType.MetricDescription,
                    Name = userGoal.GoalType.Name
                },
                Id = userGoal.Id,
                Name = userGoal.Name,
                Unit = userGoal.Unit,
                ParticipatingUsers = userGoal.Subscribers.Select(u=> new UserOutputDto
                {
                    Age = u.Subscriber.Age,
                    Email = u.Subscriber.Email,
                    Id = u.Subscriber.Id,
                    Name = u.Subscriber.Name,
                    UserName = u.Subscriber.UserName
                }).ToList()
            };

        }

    }
}
