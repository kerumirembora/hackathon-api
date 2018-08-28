using System;
using System.Collections.Generic;

namespace Hackathon.Model
{
    public class GoalSubscriber : IEntity
    {
        public int Id { get; set; }
        public int CompletedAmount { get; set; }
        public User Subscriber { get; set; }
        public int SubscriberId { get; set; }
        public UserGoal UserGoal { get; set; }
        public int UserGoalId { get; set; }
    }
}
