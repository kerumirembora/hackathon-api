using System;
using System.Collections.Generic;

namespace Hackathon.Model
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DeadLineDays { get; set; }
        public DateTime StartDate { get; set; }
        public List<User> Members { get; set; }
    }
}
