using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHome.Api.Migrations
{
    public partial class MSF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MSFCharacterExtra",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSFCharacterExtra", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MSFCharacterOrganization",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSFCharacterOrganization", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MSFCharacters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Available = table.Column<bool>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Power = table.Column<int>(nullable: false),
                    Tier = table.Column<int>(nullable: false),
                    Star = table.Column<int>(nullable: false),
                    RedStar = table.Column<int>(nullable: false),
                    BasicSkill = table.Column<int>(nullable: false),
                    SpecialSkill = table.Column<int>(nullable: false),
                    UltimateSkill = table.Column<int>(nullable: true),
                    PassiveSkill = table.Column<int>(nullable: false),
                    Allegiance = table.Column<int>(nullable: false),
                    Jurisdiction = table.Column<int>(nullable: false),
                    Origin = table.Column<int>(nullable: false),
                    Class = table.Column<int>(nullable: false),
                    Organizations = table.Column<string>(nullable: true),
                    Extras = table.Column<string>(nullable: true),
                    Team = table.Column<int>(nullable: true),
                    Favorite = table.Column<bool>(nullable: false),
                    Shard = table.Column<int>(nullable: false),
                    Farmable = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSFCharacters", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MSFCharacterExtra");

            migrationBuilder.DropTable(
                name: "MSFCharacterOrganization");

            migrationBuilder.DropTable(
                name: "MSFCharacters");
        }
    }
}
