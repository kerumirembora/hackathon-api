using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Services.Interfaces
{
    public interface ILoginService
    {
        bool Login(string userName, string userPassword);
    }
}
