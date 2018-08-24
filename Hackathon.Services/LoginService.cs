using Hackathon.Services.Interfaces;
using System;

namespace Hackathon.Services
{
    public class LoginService : ILoginService
    {
        public bool Login(string userName, string userPassword)
        {
            return true;
        }
    }
}
