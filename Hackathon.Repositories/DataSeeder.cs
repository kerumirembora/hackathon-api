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
                new User { Id = 1, Age = 32, Name = "John Doe", UserName = "JohnDoe", Email = "johndoe@gmail.com" },
                new User { Id = 2, Age = 45, Name = "Anna Doe", UserName = "AnnaDoe", Email = "annadoe@outlook.com" },
                new User { Id = 3, Age = 28, Name = "Jimmy Chamberlin", UserName = "Jimmy", Email = "jimmy@gmail.com" },
                new User { Id = 5, Age = 55, Name = "Dominic Howard", UserName = "Dominic", Email = "dominic@yahoo.com" }
            );
        }

        public static void SeedGoalTypes(ModelBuilder builder)
        {
            builder.Entity<GoalType>().HasData(
                new GoalType { Id = 1, Name = "Facebook", Description = "Stop spending so much time on Facebook", MetricDescription = "Time spent on Facebook" },
                new GoalType { Id = 2, Name = "Curse Jar", Description = "Stop cursing", MetricDescription = "Curses said" },
                new GoalType { Id = 3, Name = "Trip", Description = "Save for a trip", MetricDescription = "Money saved" }
            );
        }

        public static void SeedUserGoals(ModelBuilder builder)
        {
            builder.Entity<UserGoal>().HasData(
                new UserGoal
                {
                    Id = 1,
                    Name = "Decrease facebook usage this month",
                    AdministrationUserId = 1,
                    Amount = 100,
                    Unit = "Minutes",
                    GoalTypeId = 1,
                    DeadlineDate = new DateTime(2018, 8, 29)
                }
            );

            builder.Entity<UserGoal>().HasData(
               new UserGoal
               {
                   Id = 2,
                   Name = "Stop cursing so much",
                   AdministrationUserId = 1,
                   Amount = 1000,
                   Unit = "Curses",
                   GoalTypeId = 2,
                   DeadlineDate = new DateTime(2018, 9, 29)
               }
            );
        }

        public static void SeedGoalSubscribers(ModelBuilder builder)
        {
            builder.Entity<GoalSubscriber>().HasData(
                new GoalSubscriber
                {
                    Id = 1,
                    SubscriberId = 1,
                    CompletedAmount = 20,
                    MoneyAmountSaved = 12,
                    UserGoalId = 1
                });

            builder.Entity<GoalSubscriber>().HasData(
                 new GoalSubscriber
                 {
                     Id = 2,
                     SubscriberId = 1,
                     CompletedAmount = 30,
                     MoneyAmountSaved = 20,
                     UserGoalId = 2
                 });

            builder.Entity<GoalSubscriber>().HasData(
                new GoalSubscriber
                {
                    Id = 3,
                    SubscriberId = 2,
                    CompletedAmount = 40,
                    MoneyAmountSaved = 30,
                    UserGoalId = 2
                });

        }

        public static void SeedNotifications(ModelBuilder builder)
        {
            builder.Entity<Notification>().HasData(
                new Notification
                {
                    Id = 1,
                    CreationDate = new DateTime(2018, 8, 29, 12, 12, 12),
                    ExpirationDate = new DateTime(2018, 10, 29, 12, 12, 12),
                    Message = "You just got invited to do stuff",
                    UserId = 1
                });

            builder.Entity<Notification>().HasData(
               new Notification
               {
                   Id = 2,
                   CreationDate = new DateTime(2018, 8, 26, 11, 52, 12),
                   ExpirationDate = new DateTime(2018, 10, 29, 12, 12, 12),
                   Message = "Yesterday you were online on Facebook for 30 minutes. You can do better!!!!",
                   UserId = 1,
                   UserGoalId = 1
               });

            builder.Entity<Notification>().HasData(
              new Notification
              {
                  Id = 3,
                  CreationDate = new DateTime(2018, 8, 27, 17, 2, 12),
                  ExpirationDate = new DateTime(2018, 10, 29, 12, 12, 12),
                  Message = "Yesterday you cursed 45 times. Wash your mounth with soap bitch!!",
                  UserId = 1,
                  UserGoalId = 2
              });
        }
    }
}
