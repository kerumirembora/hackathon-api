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
                new User { Id = 1, Age = 32, Name = "John Doe", UserName = "JohnDoe", Email="johndoe@gmail.com" },
                new User { Id = 2, Age = 45, Name = "Anna Doe", UserName = "AnnaDoe", Email = "annadoe@outlook.com" },
                new User { Id = 3, Age = 28, Name = "Jimmy Chamberlin", UserName = "Jimmy", Email = "jimmy@gmail.com" },
                new User { Id = 5, Age = 55, Name = "Dominic Howard", UserName = "Dominic", Email = "dominic@yahoo.com" }
           );
        }

        public static void SeedGoalTypes(ModelBuilder builder)
        {
            builder.Entity<GoalType>().HasData(
                new GoalType { Id = 1, Name = "Social Media", Description = "Stop spending so much time on social media" },
                new GoalType { Id = 2, Name = "Curse Jar", Description = "Stop cursing" },
                new GoalType { Id = 3, Name = "Trip", Description = "Save for a trip" }
           );
        }
    }
}
