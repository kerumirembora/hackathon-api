using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Repositories.SQLLite
{
    public class SQLLiteUserRepository : BaseRepository<User>, IUserRepository
    {
        public SQLLiteUserRepository(SQLLiteContext dbContext) : base(dbContext) { }

        public async Task<User> GetByUserName(string userName)
        {
            return await Context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.UserName == userName);
        }
    }
}
