using Hackathon.Services.Interfaces;
using Hackathon.Services.Model;
using System;

namespace Hackathon.Services
{
    public class LoginService : ILoginService
    {
        public User Login(string userName)
        {
            return new User
            {
                Age = 34,
                Name = "Jimbras",
                UserName = "The Jimbras"
            };
        }
    }
}
