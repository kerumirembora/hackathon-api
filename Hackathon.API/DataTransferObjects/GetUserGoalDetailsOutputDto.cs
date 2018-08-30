using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.API.DataTransferObjects
{
    public class GetUserGoalDetailsOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public DateTime DeadlineDate { get; set; }
        public int AdministrationUserId { get; set; }
        public GoalTypeOutputDto GoalType { get; set; }
        public List<UserOutputDto> ParticipatingUsers { get; set; }
    }

    public class GetUserGoalDetailsOutputDtoe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public DateTime DeadlineDate { get; set; }
        public int AdministrationUserId { get; set; }
        public GoalTypeOutputDto GoalType { get; set; }
    }

}
