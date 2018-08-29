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
                Id = user.Id,
                UserName = user.UserName
            };

            foreach (var subscribedGoal in user.SubscribedGoals)
            {
                UserLoginGoalOutputDto goal =  new UserLoginGoalOutputDto {
                    Name = subscribedGoal.UserGoal.GoalType.Name,
                    Deadline = subscribedGoal.UserGoal.DeadlineDate,
                    GoalTypeId = subscribedGoal.UserGoal.GoalTypeId,
                    GoalId = subscribedGoal.UserGoal.Id
                };

                goal.Metrics.Add(new UserLoginMetricOutputDto {
                    Description = subscribedGoal.UserGoal.GoalType.MetricDescription,
                    Amount = subscribedGoal.CompletedAmount,
                    Limit = subscribedGoal.UserGoal.Amount,
                    Unit = subscribedGoal.UserGoal.Unit
                });

                goal.Metrics.Add(new UserLoginMetricOutputDto
                {
                    Description = "Amount saved",
                    Amount = subscribedGoal.MoneyAmountSaved,
                    Unit = "NOK"
                });

                output.Goals.Add(goal);
            }

            return output;

        }
    }
}
