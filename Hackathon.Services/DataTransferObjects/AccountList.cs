using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Services.DataTransferObjects
{
    public class AccountsList
    {
        public int AvailableItems { get; set; }
        public List<Account> Items { get; set; }
    }
}
