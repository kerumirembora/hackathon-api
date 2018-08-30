using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.Repositories.Migrations
{
    public partial class SavingTransferAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SavingTransferAmount",
                table: "GoalSubscribers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "GoalSubscribers",
                keyColumn: "Id",
                keyValue: 1,
                column: "SavingTransferAmount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "GoalSubscribers",
                keyColumn: "Id",
                keyValue: 2,
                column: "SavingTransferAmount",
                value: 8);

            migrationBuilder.UpdateData(
                table: "GoalSubscribers",
                keyColumn: "Id",
                keyValue: 3,
                column: "SavingTransferAmount",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SavingTransferAmount",
                table: "GoalSubscribers");
        }
    }
}
