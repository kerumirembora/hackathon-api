using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.Repositories.Migrations
{
    public partial class GoalTypeMetricDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MetricDescription",
                table: "GoalTypes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "GoalTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "MetricDescription", "Name" },
                values: new object[] { "Stop spending so much time on Facebook", "Time spent on Facebook", "Facebook" });

            migrationBuilder.UpdateData(
                table: "GoalTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "MetricDescription",
                value: "Curses said");

            migrationBuilder.UpdateData(
                table: "GoalTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "MetricDescription",
                value: "Money saved");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetricDescription",
                table: "GoalTypes");

            migrationBuilder.UpdateData(
                table: "GoalTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Stop spending so much time on social media", "Social Media" });
        }
    }
}
