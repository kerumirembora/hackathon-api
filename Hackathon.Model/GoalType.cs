using System;
using System.Collections.Generic;

namespace Hackathon.Model
{
    public class GoalType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
