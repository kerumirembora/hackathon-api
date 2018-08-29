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
                    goalTypeId = subscribedGoal.UserGoal.GoalTypeId,
                    goalId = subscribedGoal.UserGoal.Id
                };

                goal.metrics.Add(new UserLoginMetricOutputDto {
                    description = subscribedGoal.UserGoal.GoalType.MetricDescription,
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

        }
    }
}
