using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHome.Api.Migrations
{
    public partial class teamToTeamID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Member1ID",
                table: "MSFTeam");

            migrationBuilder.DropColumn(
                name: "Member2ID",
                table: "MSFTeam");

            migrationBuilder.DropColumn(
                name: "Member3ID",
                table: "MSFTeam");

            migrationBuilder.DropColumn(
                name: "Member4ID",
                table: "MSFTeam");

            migrationBuilder.DropColumn(
                name: "Member5ID",
                table: "MSFTeam");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "MSFCharacters");

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "MSFCharacters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "MSFCharacters");

            migrationBuilder.AddColumn<int>(
                name: "Member1ID",
                table: "MSFTeam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Member2ID",
                table: "MSFTeam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Member3ID",
                table: "MSFTeam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Member4ID",
                table: "MSFTeam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Member5ID",
                table: "MSFTeam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Team",
                table: "MSFCharacters",
                type: "int",
                nullable: true);
        }
    }
}
