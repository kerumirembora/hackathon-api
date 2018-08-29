using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Repositories.SQLLite
{
    public class SQLLiteUserGoalRepository : BaseRepository<UserGoal>, IUserGoalRepository
    {
        public SQLLiteUserGoalRepository(SQLLiteContext dbContext) : base(dbContext) { }

      
    }
}
