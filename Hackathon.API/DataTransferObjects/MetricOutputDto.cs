using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.API.DataTransferObjects
{
    public class MetricOutputDto
    {
        public string Description { get; set; }
        public string Unit { get; set; }
        public int Amount { get; set; }
        public int Limit { get; set; }
    }
  
}
