using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Services.DataTransferObjects
{
    public class Transfer
    {
        public string FromAccountId { get; set; }
        public string ToAccountId { get; set; }
        public string Message { get; set; }
        public double Amount { get; set; }
    }
}
