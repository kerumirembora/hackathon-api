﻿// <auto-generated />
using System;
using Hackathon.Repositories.SQLLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hackathon.Repositories.Migrations
{
    [DbContext(typeof(SQLLiteContext))]
    [Migration("20180830171833_SeedEvenMoreEvents")]
    partial class SeedEvenMoreEvents
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("Hackathon.Model.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description");

                    b.Property<int>("GoalSubscriberId");

                    b.HasKey("Id");

                    b.HasIndex("GoalSubscriberId");

                    b.ToTable("Events");

                    b.HasData(
                        new { Id = 1, CreationDate = new DateTime(2018, 8, 29, 12, 12, 12, 0, DateTimeKind.Unspecified), Description = "User John Doe invited.", GoalSubscriberId = 1 },
                        new { Id = 2, CreationDate = new DateTime(2018, 8, 29, 13, 52, 12, 0, DateTimeKind.Unspecified), Description = "Neque porro quisquam est qui dolorem .", GoalSubscriberId = 1 },
                        new { Id = 3, CreationDate = new DateTime(2018, 8, 29, 12, 12, 12, 0, DateTimeKind.Unspecified), Description = "Ipsum quia dolor sit amet, consectetur, adipisci velit.", GoalSubscriberId = 1 }
                    );
                });

            modelBuilder.Entity("Hackathon.Model.GoalSubscriber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompletedAmount");

                    b.Property<int>("MoneyAmountSaved");

                    b.Property<int?>("SavingTransferAmount");

                    b.Property<int>("SubscriberId");

                    b.Property<int>("UserGoalId");

                    b.HasKey("Id");

                    b.HasIndex("SubscriberId");

                    b.HasIndex("UserGoalId");

                    b.ToTable("GoalSubscribers");

                    b.HasData(
                        new { Id = 1, CompletedAmount = 20, MoneyAmountSaved = 12, SavingTransferAmount = 3, SubscriberId = 1, UserGoalId = 1 },
                        new { Id = 2, CompletedAmount = 30, MoneyAmountSaved = 20, SavingTransferAmount = 8, SubscriberId = 1, UserGoalId = 2 },
                        new { Id = 3, CompletedAmount = 40, MoneyAmountSaved = 30, SavingTransferAmount = 5, SubscriberId = 2, UserGoalId = 2 }
                    );
                });

            modelBuilder.Entity("Hackathon.Model.GoalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("MetricDescription");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("GoalTypes");

                    b.HasData(
                        new { Id = 1, Description = "Stop spending so much time on Facebook", MetricDescription = "Time spent on Facebook", Name = "Facebook" },
                        new { Id = 2, Description = "Stop cursing", MetricDescription = "Curses said", Name = "Curse Jar" },
                        new { Id = 3, Description = "Save for a trip", MetricDescription = "Money saved", Name = "Trip" }
                    );
                });

            modelBuilder.Entity("Hackathon.Model.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<string>("Message");

                    b.Property<int?>("UserGoalId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserGoalId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");

                    b.HasData(
                        new { Id = 1, CreationDate = new DateTime(2018, 8, 29, 12, 12, 12, 0, DateTimeKind.Unspecified), ExpirationDate = new DateTime(2018, 10, 29, 12, 12, 12, 0, DateTimeKind.Unspecified), Message = "You just got invited to do stuff", UserId = 1 },
                        new { Id = 2, CreationDate = new DateTime(2018, 8, 26, 11, 52, 12, 0, DateTimeKind.Unspecified), ExpirationDate = new DateTime(2018, 10, 29, 12, 12, 12, 0, DateTimeKind.Unspecified), Message = "Yesterday you were online on Facebook for 30 minutes. You can do better!!!!", UserGoalId = 1, UserId = 1 },
                        new { Id = 3, CreationDate = new DateTime(2018, 8, 27, 17, 2, 12, 0, DateTimeKind.Unspecified), ExpirationDate = new DateTime(2018, 10, 29, 12, 12, 12, 0, DateTimeKind.Unspecified), Message = "Yesterday you cursed 45 times.", UserGoalId = 2, UserId = 1 }
                    );
                });

            modelBuilder.Entity("Hackathon.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, Age = 32, Email = "johndoe@gmail.com", Name = "John Doe", UserName = "JohnDoe" },
                        new { Id = 2, Age = 45, Email = "annadoe@outlook.com", Name = "Anna Doe", UserName = "AnnaDoe" },
                        new { Id = 3, Age = 28, Email = "jimmy@gmail.com", Name = "Jimmy Chamberlin", UserName = "Jimmy" },
                        new { Id = 5, Age = 55, Email = "dominic@yahoo.com", Name = "Dominic Howard", UserName = "Dominic" }
                    );
                });

            modelBuilder.Entity("Hackathon.Model.UserGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdministrationUserId");

                    b.Property<int>("Amount");

                    b.Property<DateTime>("DeadlineDate");

                    b.Property<int>("GoalTypeId");

                    b.Property<string>("Name");

                    b.Property<string>("Unit");

                    b.HasKey("Id");

                    b.HasIndex("AdministrationUserId");

                    b.HasIndex("GoalTypeId");

                    b.ToTable("UserGoals");

                    b.HasData(
                        new { Id = 1, AdministrationUserId = 1, Amount = 100, DeadlineDate = new DateTime(2018, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), GoalTypeId = 1, Name = "Decrease facebook usage this month", Unit = "Minutes" },
                        new { Id = 2, AdministrationUserId = 1, Amount = 1000, DeadlineDate = new DateTime(2018, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), GoalTypeId = 2, Name = "Stop cursing so much", Unit = "Curses" }
                    );
                });

            modelBuilder.Entity("Hackathon.Model.Event", b =>
                {
                    b.HasOne("Hackathon.Model.GoalSubscriber", "GoalSubscriber")
                        .WithMany("Events")
                        .HasForeignKey("GoalSubscriberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hackathon.Model.GoalSubscriber", b =>
                {
                    b.HasOne("Hackathon.Model.User", "Subscriber")
                        .WithMany("SubscribedGoals")
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hackathon.Model.UserGoal", "UserGoal")
                        .WithMany("Subscribers")
                        .HasForeignKey("UserGoalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hackathon.Model.Notification", b =>
                {
                    b.HasOne("Hackathon.Model.UserGoal", "UserGoal")
                        .WithMany()
                        .HasForeignKey("UserGoalId");

                    b.HasOne("Hackathon.Model.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hackathon.Model.UserGoal", b =>
                {
                    b.HasOne("Hackathon.Model.User", "AdministrationUser")
                        .WithMany("DefinedGoals")
                        .HasForeignKey("AdministrationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hackathon.Model.GoalType", "GoalType")
                        .WithMany("UserGoals")
                        .HasForeignKey("GoalTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
