using Hackathon.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Repositories.InMemory.MockData
{
    public static class UsersMockData
    {
        private static readonly List<User> _users = new List<User> {
            new User {Id= 1, Age = 21, Name = "Jimbras",UserName="TheJimbras" },
            new User {Id= 2,Age = 145, Name = "Coiso",UserName="Coiso" },
            new User {Id= 3,Age = 34, Name = "Coisinho",UserName="Coisinho" },
            new User {Id= 4,Age = 54, Name = "Coisinha",UserName="Coisinha" },
            new User {Id= 5,Age = 75, Name = "THA ONE!!!",UserName="THA ONE!!!" }
        };

        public static List<User> AllData
        {
            get
            {
                return _users;
            }
        }

    }
}
