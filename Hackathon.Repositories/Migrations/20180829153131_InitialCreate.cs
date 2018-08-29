using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.Repositories.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MetricDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Age = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGoals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    DeadlineDate = table.Column<DateTime>(nullable: false),
                    AdministrationUserId = table.Column<int>(nullable: false),
                    GoalTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGoals_Users_AdministrationUserId",
                        column: x => x.AdministrationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGoals_GoalTypes_GoalTypeId",
                        column: x => x.GoalTypeId,
                        principalTable: "GoalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoalSubscribers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompletedAmount = table.Column<int>(nullable: false),
                    MoneyAmountSaved = table.Column<int>(nullable: false),
                    SubscriberId = table.Column<int>(nullable: false),
                    UserGoalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalSubscribers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoalSubscribers_Users_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoalSubscribers_UserGoals_UserGoalId",
                        column: x => x.UserGoalId,
                        principalTable: "UserGoals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Message = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserGoalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_UserGoals_UserGoalId",
                        column: x => x.UserGoalId,
                        principalTable: "UserGoals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    GoalSubscriberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_GoalSubscribers_GoalSubscriberId",
                        column: x => x.GoalSubscriberId,
                        principalTable: "GoalSubscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GoalTypes",
                columns: new[] { "Id", "Description", "MetricDescription", "Name" },
                values: new object[] { 1, "Stop spending so much time on Facebook", "Time spent on Facebook", "Facebook" });

            migrationBuilder.InsertData(
                table: "GoalTypes",
                columns: new[] { "Id", "Description", "MetricDescription", "Name" },
                values: new object[] { 2, "Stop cursing", "Curses said", "Curse Jar" });

            migrationBuilder.InsertData(
                table: "GoalTypes",
                columns: new[] { "Id", "Description", "MetricDescription", "Name" },
                values: new object[] { 3, "Save for a trip", "Money saved", "Trip" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name", "UserName" },
                values: new object[] { 1, 32, "johndoe@gmail.com", "John Doe", "JohnDoe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name", "UserName" },
                values: new object[] { 2, 45, "annadoe@outlook.com", "Anna Doe", "AnnaDoe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name", "UserName" },
                values: new object[] { 3, 28, "jimmy@gmail.com", "Jimmy Chamberlin", "Jimmy" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name", "UserName" },
                values: new object[] { 5, 55, "dominic@yahoo.com", "Dominic Howard", "Dominic" });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreationDate", "ExpirationDate", "Message", "UserGoalId", "UserId" },
                values: new object[] { 1, new DateTime(2018, 8, 29, 12, 12, 12, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 29, 12, 12, 12, 0, DateTimeKind.Unspecified), "You just got invited to do stuff", null, 1 });

            migrationBuilder.InsertData(
                table: "UserGoals",
                columns: new[] { "Id", "AdministrationUserId", "Amount", "DeadlineDate", "GoalTypeId", "Name", "Unit" },
                values: new object[] { 1, 1, 100, new DateTime(2018, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Decrease facebook usage this month", "Minutes" });

            migrationBuilder.InsertData(
                table: "UserGoals",
                columns: new[] { "Id", "AdministrationUserId", "Amount", "DeadlineDate", "GoalTypeId", "Name", "Unit" },
                values: new object[] { 2, 1, 1000, new DateTime(2018, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Stop cursing so much", "Curses" });

            migrationBuilder.InsertData(
                table: "GoalSubscribers",
                columns: new[] { "Id", "CompletedAmount", "MoneyAmountSaved", "SubscriberId", "UserGoalId" },
                values: new object[] { 1, 20, 12, 1, 1 });

            migrationBuilder.InsertData(
                table: "GoalSubscribers",
                columns: new[] { "Id", "CompletedAmount", "MoneyAmountSaved", "SubscriberId", "UserGoalId" },
                values: new object[] { 2, 30, 20, 1, 2 });

            migrationBuilder.InsertData(
                table: "GoalSubscribers",
                columns: new[] { "Id", "CompletedAmount", "MoneyAmountSaved", "SubscriberId", "UserGoalId" },
                values: new object[] { 3, 40, 30, 2, 2 });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreationDate", "ExpirationDate", "Message", "UserGoalId", "UserId" },
                values: new object[] { 2, new DateTime(2018, 8, 26, 11, 52, 12, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 29, 12, 12, 12, 0, DateTimeKind.Unspecified), "Yesterday you were online on Facebook for 30 minutes. You can do better!!!!", 1, 1 });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreationDate", "ExpirationDate", "Message", "UserGoalId", "UserId" },
                values: new object[] { 3, new DateTime(2018, 8, 27, 17, 2, 12, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 29, 12, 12, 12, 0, DateTimeKind.Unspecified), "Yesterday you cursed 45 times. Wash your mounth with soap bitch!!", 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Events_GoalSubscriberId",
                table: "Events",
                column: "GoalSubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalSubscribers_SubscriberId",
                table: "GoalSubscribers",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalSubscribers_UserGoalId",
                table: "GoalSubscribers",
                column: "UserGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserGoalId",
                table: "Notifications",
                column: "UserGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGoals_AdministrationUserId",
                table: "UserGoals",
                column: "AdministrationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGoals_GoalTypeId",
                table: "UserGoals",
                column: "GoalTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "GoalSubscribers");

            migrationBuilder.DropTable(
                name: "UserGoals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GoalTypes");
        }
    }
}
