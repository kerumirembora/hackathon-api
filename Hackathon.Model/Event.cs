using System;
using System.Collections.Generic;

namespace Hackathon.Model
{
    public class Event : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public GoalSubscriber GoalSubscriber { get; set; }
        public int GoalSubscriberId { get; set; }
    }
}
