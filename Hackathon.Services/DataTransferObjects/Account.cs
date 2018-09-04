using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Services.DataTransferObjects
{
    public class Account
    {
        public string AccountId { get; set; }
        public decimal Available { get; set; }
        public decimal Balance { get; set; }

    }
}
