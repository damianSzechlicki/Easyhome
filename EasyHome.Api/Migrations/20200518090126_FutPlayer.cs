using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHome.Api.Migrations
{
    public partial class FutPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FUTPlayer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    FUTID = table.Column<long>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<long>(nullable: false),
                    Formation = table.Column<string>(nullable: true),
                    Untradeable = table.Column<bool>(nullable: false),
                    AssetId = table.Column<long>(nullable: false),
                    Rating = table.Column<long>(nullable: false),
                    ItemType = table.Column<string>(nullable: true),
                    ResourceId = table.Column<long>(nullable: false),
                    Owners = table.Column<long>(nullable: false),
                    DiscardValue = table.Column<long>(nullable: false),
                    ItemState = table.Column<string>(nullable: true),
                    Cardsubtypeid = table.Column<long>(nullable: false),
                    LastSalePrice = table.Column<long>(nullable: false),
                    Fitness = table.Column<long>(nullable: false),
                    InjuryType = table.Column<string>(nullable: true),
                    InjuryGames = table.Column<long>(nullable: false),
                    PreferredPosition = table.Column<string>(nullable: true),
                    Training = table.Column<long>(nullable: false),
                    Contract = table.Column<long>(nullable: false),
                    Teamid = table.Column<long>(nullable: false),
                    Team = table.Column<string>(nullable: true),
                    Rareflag = table.Column<long>(nullable: false),
                    PlayStyle = table.Column<long>(nullable: false),
                    LeagueId = table.Column<long>(nullable: false),
                    League = table.Column<string>(nullable: true),
                    Assists = table.Column<long>(nullable: false),
                    LifetimeAssists = table.Column<long>(nullable: false),
                    Loans = table.Column<long>(nullable: false),
                    LoyaltyBonus = table.Column<long>(nullable: false),
                    Pile = table.Column<long>(nullable: false),
                    Nation = table.Column<long>(nullable: false),
                    Nationality = table.Column<string>(nullable: true),
                    MarketDataMinPrice = table.Column<long>(nullable: false),
                    MarketDataMaxPrice = table.Column<long>(nullable: false),
                    ResourceGameYear = table.Column<long>(nullable: false),
                    AttributeString = table.Column<string>(nullable: true),
                    StatsString = table.Column<string>(nullable: true),
                    LifetimeStats = table.Column<string>(nullable: true),
                    Skillmoves = table.Column<long>(nullable: false),
                    Weakfootabilitytypecode = table.Column<long>(nullable: false),
                    Attackingworkrate = table.Column<long>(nullable: false),
                    Defensiveworkrate = table.Column<long>(nullable: false),
                    Trait1 = table.Column<long>(nullable: false),
                    Trait2 = table.Column<long>(nullable: false),
                    Preferredfoot = table.Column<long>(nullable: false),
                    SkipSBC = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUTPlayer", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FUTPlayer");
        }
    }
}
