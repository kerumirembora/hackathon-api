using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Model
{
    public class User : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<UserGoal> DefinedGoals { get; set; }
        public List<GoalSubscriber> SubscribedGoals { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
