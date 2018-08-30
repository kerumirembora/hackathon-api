using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.Repositories.Migrations
{
    public partial class SeedEvenMoreEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreationDate", "Description", "GoalSubscriberId" },
                values: new object[] { 1, new DateTime(2018, 8, 29, 12, 12, 12, 0, DateTimeKind.Unspecified), "User John Doe invited.", 1 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreationDate", "Description", "GoalSubscriberId" },
                values: new object[] { 2, new DateTime(2018, 8, 29, 13, 52, 12, 0, DateTimeKind.Unspecified), "Neque porro quisquam est qui dolorem .", 1 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreationDate", "Description", "GoalSubscriberId" },
                values: new object[] { 3, new DateTime(2018, 8, 29, 12, 12, 12, 0, DateTimeKind.Unspecified), "Ipsum quia dolor sit amet, consectetur, adipisci velit.", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
