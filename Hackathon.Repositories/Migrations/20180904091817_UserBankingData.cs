using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.Repositories.Migrations
{
    public partial class UserBankingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DestinationSavingsAccountId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginDepositAccountId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SbankenCustomerId",
                table: "Users",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DestinationSavingsAccountId", "OriginDepositAccountId", "SbankenCustomerId" },
                values: new object[] { "88E0F99D3E11010C971AA1B9127D2E4E", "BE674A52B05850EC1E9E7EBBEB75BC45", 10128512336L });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DestinationSavingsAccountId", "OriginDepositAccountId", "SbankenCustomerId" },
                values: new object[] { "2A2B1758EDAB9101D744F7A777EC33D8", "E7963591FDA781A1912083390CCF6F3A", 14093623453L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationSavingsAccountId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OriginDepositAccountId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SbankenCustomerId",
                table: "Users");
        }
    }
}
