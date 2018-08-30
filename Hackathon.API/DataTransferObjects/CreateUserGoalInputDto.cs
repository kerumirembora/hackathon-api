using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.API.DataTransferObjects
{
    public class CreateUserGoalInputDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int AmountLimit { get; set; }
        public int? SavingsAmount { get; set; }
        public string Unit { get; set; }
        public DateTime DeadlineDate { get; set; }
        public int GoalTypeId { get; set; }
    }
}
