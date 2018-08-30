using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.API.DataTransferObjects
{
    public class SubscribeUserGoalOutputDto
    {
        public int SubscriberId { get; set; }
        public int UserGoalId { get; set; }
    }
}
