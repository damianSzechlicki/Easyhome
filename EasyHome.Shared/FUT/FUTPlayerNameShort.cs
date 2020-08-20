using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyHome.Shared
{
    public class FUTPlayerCSV
    {
        public List<FUTPlayerNameShort> LegendsPlayers { get; set; }
        public List<FUTPlayerNameShort> Players { get; set; }
    }
    public class FUTPlayerNameShort
    {
        [JsonProperty("id")] 
        public long ID { get; set; }
        [JsonProperty("f")]
        public string Firstname { get; set; }
        [JsonProperty("l")]
        public string Lastname { get; set; }
        [JsonProperty("r")]
        public int Rating { get; set; }
    }
}
