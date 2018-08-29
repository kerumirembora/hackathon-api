using Hackathon.API.DataTransferObjects;
using Hackathon.Model;
using System.Linq;

namespace Hackathon.API.Mappers
{
    public static class UserMappingExtension
    {
        public static UserLoginOutputDto ToUserLoginOutputDto(this User user)
        {
            UserLoginOutputDto output = new UserLoginOutputDto {
                id = user.Id,
                userName = user.UserName
            };

            foreach (var subscribedGoal in user.SubscribedGoals)
            {
                UserLoginGoalOutputDto goal =  new UserLoginGoalOutputDto {
                    name = subscribedGoal.UserGoal.GoalType.Name,
                    deadline = subscribedGoal.UserGoal.DeadlineDate,
                    id = subscribedGoal.UserGoal.GoalTypeId,
                };

                goal.metrics.Add(new UserLoginMetricOutputDto {
                    description = subscribedGoal.UserGoal.GoalType.Description,
                    amount = subscribedGoal.CompletedAmount,
                    limit = subscribedGoal.UserGoal.Amount,
                    unit = subscribedGoal.UserGoal.Unit
                });

                goal.metrics.Add(new UserLoginMetricOutputDto
                {
                    description = "Amount saved",
                    amount = subscribedGoal.MoneyAmountSaved,
                    unit = "NOK"
                });

                output.goals.Add(goal);
            }

            return output;

            //return new UserLoginOutputDto {
            //      id = user.Id,
            //      userName = user.Name,
            //      goals = user.SubscribedGoals.Select(sg => new UserLoginGoalOutputDto {
            //          name = sg.UserGoal.GoalType.Name,
            //          deadline = sg.UserGoal.DeadlineDate,
            //          id = sg.UserGoal.GoalTypeId,
            //          metrics = sg.
            //      })
            //};
        }
    }
}
