using Hackathon.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Services.Interfaces
{
    public interface IGoalService
    {
        User Goal(string userName);
    }
}
