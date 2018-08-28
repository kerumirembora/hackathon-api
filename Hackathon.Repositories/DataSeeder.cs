using Hackathon.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Repositories
{
    public static class DataSeeder
    {
        public static void SeedUsers(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User { Id = 1, Age = 32, Name = "John Doe", UserName = "JohnDoe" },
                new User { Id = 2, Age = 45, Name = "Anna Doe", UserName = "AnnaDoe" }
           );
        }
    }
}
