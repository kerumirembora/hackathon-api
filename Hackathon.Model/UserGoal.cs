using System;
using System.Collections.Generic;

namespace Hackathon.Model
{
    public class UserGoal : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public DateTime DeadlineDate { get; set; }
        public User AdministrationUser { get; set; }
        public int AdministrationUserId { get; set; }
        public GoalType GoalType { get; set; }
        public int GoalTypeId { get; set; }
    }
}
