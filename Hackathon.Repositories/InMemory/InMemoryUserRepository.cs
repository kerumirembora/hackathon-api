﻿using Hackathon.Model;
using Hackathon.Repositories.InMemory.MockData;
using Hackathon.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackathon.Repositories.InMemory
{
    public class InMemoryUserRepository : IUserRepository
    {
        public InMemoryUserRepository() { }

        public User Get(string userName)
        {
            return UsersMockData.AllData.FirstOrDefault(u => u.UserName == userName);
        }

        public User Get(int id)
        {
            return UsersMockData.AllData.FirstOrDefault(u => u.Id == id);
        }
    }
}