using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;

namespace EasyHome.Shared
{
    public partial class FUTPlayer : BaseEntity
    {
        [JsonProperty("id")]
        public long FUTID { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("formation")]
        public string Formation { get; set; }

        [JsonProperty("untradeable")]
        public bool Untradeable { get; set; }

        [JsonProperty("assetId")]
        public long AssetId { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("itemType")]
        public string ItemType { get; set; }

        [JsonProperty("resourceId")]
        public long ResourceId { get; set; }

        [JsonProperty("owners")]
        public long Owners { get; set; }

        [JsonProperty("discardValue")]
        public long DiscardValue { get; set; }

        [JsonProperty("itemState")]
        public string ItemState { get; set; }

        [JsonProperty("cardsubtypeid")]
        public long Cardsubtypeid { get; set; }

        [JsonProperty("lastSalePrice")]
        public long LastSalePrice { get; set; }

        [JsonProperty("fitness")]
        public long Fitness { get; set; }

        [JsonProperty("injuryType")]
        public string InjuryType { get; set; }

        [JsonProperty("injuryGames")]
        public long InjuryGames { get; set; }

        [JsonProperty("preferredPosition")]
        public string PreferredPosition { get; set; }

        [JsonProperty("training")]
        public long Training { get; set; }

        [JsonProperty("contract")]
        public long Contract { get; set; }

        [JsonProperty("teamid")]
        public long Teamid { get; set; }
        public string Team { get; set; }

        [JsonProperty("rareflag")]
        public long Rareflag { get; set; }

        [JsonProperty("playStyle")]
        public long PlayStyle { get; set; }

        [JsonProperty("leagueId")]
        public long LeagueId { get; set; }
        public string League { get; set; }

        [JsonProperty("assists")]
        public long Assists { get; set; }

        [JsonProperty("lifetimeAssists")]
        public long LifetimeAssists { get; set; }

        [JsonProperty("loans")]
        public long Loans { get; set; }

        [JsonProperty("loyaltyBonus")]
        public long LoyaltyBonus { get; set; }

        [JsonProperty("pile")]
        public long Pile { get; set; }

        [JsonProperty("nation")]
        public long Nation { get; set; }
        public string Nationality { get; set; }

        [JsonProperty("marketDataMinPrice")]
        public long MarketDataMinPrice { get; set; }

        [JsonProperty("marketDataMaxPrice")]
        public long MarketDataMaxPrice { get; set; }

        [JsonProperty("resourceGameYear")]
        public long ResourceGameYear { get; set; }

        [JsonProperty("attributeArray")]
        [NotMapped]
        public List<long> AttributeArray { get; set; }
        public string AttributeString { get; set; }

        [JsonProperty("statsArray")]
        [NotMapped]
        public List<long> StatsArray { get; set; }
        public string StatsString { get; set; }

        [JsonProperty("lifetimeStatsArray")]
        [NotMapped]
        public List<long> LifetimeStatsArray { get; set; }
        public string LifetimeStats { get; set; }

        [JsonProperty("skillmoves")]
        public long Skillmoves { get; set; }

        [JsonProperty("weakfootabilitytypecode")]
        public long Weakfootabilitytypecode { get; set; }

        [JsonProperty("attackingworkrate")]
        public long Attackingworkrate { get; set; }

        [JsonProperty("defensiveworkrate")]
        public long Defensiveworkrate { get; set; }

        [JsonProperty("trait1")]
        public long Trait1 { get; set; }

        [JsonProperty("trait2")]
        public long Trait2 { get; set; }

        [JsonProperty("preferredfoot")]
        public long Preferredfoot { get; set; }

        public bool SkipSBC { get; set; }
    }

    public partial class FutPlayerSource
    {
        [JsonProperty("itemData")]
        public List<FUTPlayer> ItemData { get; set; }
    }
}
