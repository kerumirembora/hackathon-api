using Hackathon.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Services.Interfaces
{
    public interface ILoginService
    {
        Task<User> Login(string userName);
    }
}
