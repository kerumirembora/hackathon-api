﻿using Hackathon.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Repositories.SQLLite
{
    public class SQLLiteContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<GoalType> GoalTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<GoalSubscriber> GoalSubscribers { get; set; }
        public DbSet<UserGoal> UserGoals { get; set; }

        public SQLLiteContext(DbContextOptions<SQLLiteContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=hackathon.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            DataSeeder.SeedUsers(builder);
            
        }
    }
}