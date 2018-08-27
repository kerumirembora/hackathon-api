using Hackathon.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Services.Interfaces
{
    public interface ILoginService
    {
        User Login(string userName);
    }
}
