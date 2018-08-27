using Hackathon.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Get(string userName);
    }
}
