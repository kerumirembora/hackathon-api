using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Model
{
    public class Event : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public GoalSubscriber GoalSubscriber { get; set; }
        public int GoalSubscriberId { get; set; }
    }
}
