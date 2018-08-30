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
        public List<EventOutputDto> LoggedUserEvents { get; set; }
        public List<MetricOutputDto> Metrics { get; set; }


        public GetUserGoalDetailsOutputDto()
        {
            ParticipatingUsers = new List<UserOutputDto>();
            LoggedUserEvents = new List<EventOutputDto>();
            Metrics = new List<MetricOutputDto>();
        }
    }

}
