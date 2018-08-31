using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.API.DataTransferObjects
{
    public class UpdateGoalSubscriberDetailsInputDto
    {
        public int CompletedAmountIncrement { get; set; }
        public int MoneyAmountSaved { get; set; }
        public int? SavingTransferAmount { get; set; }
    }
}
