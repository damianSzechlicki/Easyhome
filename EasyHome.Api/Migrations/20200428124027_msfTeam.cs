using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHome.Api.Migrations
{
    public partial class msfTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MSFTeam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    Member1ID = table.Column<int>(nullable: false),
                    Member2ID = table.Column<int>(nullable: false),
                    Member3ID = table.Column<int>(nullable: false),
                    Member4ID = table.Column<int>(nullable: false),
                    Member5ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSFTeam", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MSFTeam");
        }
    }
}
