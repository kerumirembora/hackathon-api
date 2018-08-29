using System;
using System.Collections.Generic;

namespace Hackathon.API.DataTransferObjects
{
    public class UserLoginOutputDto
    {
        public int id { get; set; }
        public string userName { get; set; }
        public List<UserLoginGoalOutputDto> goals { get; set; }

        public UserLoginOutputDto()
        {
            goals = new List<UserLoginGoalOutputDto>();
        }
    }

    public class UserLoginGoalOutputDto
    {
        public int goalTypeId { get; set; }
        public int goalId { get; set; }
        public string name { get; set; }
        public DateTime deadline  { get; set; }
        public List<UserLoginMetricOutputDto> metrics { get; set; }

        public UserLoginGoalOutputDto()
        {
            metrics = new List<UserLoginMetricOutputDto>();
        }
    }

    public class UserLoginMetricOutputDto
    {
        public string description { get; set; }
        public string unit { get; set; }
        public int amount { get; set; }
        public int limit { get; set; }
    }
}
