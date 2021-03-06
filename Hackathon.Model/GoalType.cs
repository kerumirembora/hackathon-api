﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Model
{
    public class GoalType : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MetricDescription { get; set; }
        public List<UserGoal> UserGoals { get; set; }
    }
}
