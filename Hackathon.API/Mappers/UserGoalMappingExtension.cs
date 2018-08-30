using Hackathon.API.DataTransferObjects;
using Hackathon.Model;
using System.Collections.Generic;
using System.Linq;

namespace Hackathon.API.Mappers
{
    public static class UserGoalMappingExtension
    {
        public static GetUserGoalDetailsOutputDto ToGetUserGoalDetailsOutputDto(this (UserGoal UserGoal, List<Event> LoggedUserEvents) input, int loggedUserId)
        {
            var output = new GetUserGoalDetailsOutputDto
            {
                AdministrationUserId = input.UserGoal.AdministrationUserId,
                Amount = input.UserGoal.Amount,
                DeadlineDate = input.UserGoal.DeadlineDate,
                GoalType = new GoalTypeOutputDto
                {
                    Description = input.UserGoal.GoalType.Description,
                    Id = input.UserGoal.GoalType.Id,
                    Name = input.UserGoal.GoalType.Name
                },
                Id = input.UserGoal.Id,
                Name = input.UserGoal.Name,
                Unit = input.UserGoal.Unit,
                ParticipatingUsers = input.UserGoal.Subscribers.Select(u => new UserOutputDto
                {
                    Age = u.Subscriber.Age,
                    Email = u.Subscriber.Email,
                    Id = u.Subscriber.Id,
                    Name = u.Subscriber.Name,
                    UserName = u.Subscriber.UserName
                }).ToList(),
                LoggedUserEvents = input.LoggedUserEvents.Select(e => new EventOutputDto
                {
                    CreationDate = e.CreationDate,
                    Description = e.Description,
                    Id = e.Id,
                    UserId = e.GoalSubscriber.Subscriber.Id
                }).ToList()
                
            };

            var subscriber = input.UserGoal.Subscribers.FirstOrDefault(s => s.SubscriberId == loggedUserId);

            output.Metrics.Add(new MetricOutputDto {
                Amount = subscriber.CompletedAmount,
                Description = input.UserGoal.GoalType.MetricDescription,
                Limit = input.UserGoal.Amount,
                Unit = input.UserGoal.Unit
            });
            output.Metrics.Add(new MetricOutputDto
            {
                Description = "Amount saved",
                Amount = subscriber.MoneyAmountSaved,
                Unit = "NOK"
            });

            return output;
        }
    }
}
