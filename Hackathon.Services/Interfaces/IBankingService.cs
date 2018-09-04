using Hackathon.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Services.Interfaces
{
    public interface IBankingService
    {
        Task<bool> TransferToSavingsAccount(int userId, int transferAmount);
    }
}
