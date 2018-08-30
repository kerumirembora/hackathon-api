using System;
using System.Collections.Generic;

namespace Hackathon.API.DataTransferObjects
{
    public class UserLoginOutputDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<UserLoginGoalOutputDto> Goals { get; set; }

        public UserLoginOutputDto()
        {
            Goals = new List<UserLoginGoalOutputDto>();
        }
    }

    public class UserLoginGoalOutputDto
    {
        public int GoalTypeId { get; set; }
        public int GoalId { get; set; }
        public string Name { get; set; }
        public string GoalTypeName { get; set; }
        public DateTime Deadline  { get; set; }
        public List<MetricOutputDto> Metrics { get; set; }

        public UserLoginGoalOutputDto()
        {
            Metrics = new List<MetricOutputDto>();
        }
    }

   
}
