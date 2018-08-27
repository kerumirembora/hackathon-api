using Hackathon.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Repositories.InMemory.MockData
{
    public static class GoalsMockData
    {
        private static readonly List<Goal> _goals = new List<Goal> {
            new Goal {Id= 1,
                Name = "1000 pushups on one week",
                DeadLineDays =7,
                StartDate = DateTime.Now,
                Description ="Make a LOT of pushups!!!!",
                Members = new List<User>{ } }
        };

        public static List<Goal> AllData
        {
            get
            {
                return _goals;
            }
        }

    }
}
