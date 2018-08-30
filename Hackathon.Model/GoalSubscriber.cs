using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Model
{
    public class GoalSubscriber : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompletedAmount { get; set; }
        public int MoneyAmountSaved { get; set; }
        public int SavingTransferAmount { get; set; }
        public User Subscriber { get; set; }
        public int SubscriberId { get; set; }
        public UserGoal UserGoal { get; set; }
        public int UserGoalId { get; set; }
        public List<Event> Events { get; set; }
    }
}
