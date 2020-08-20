using System;
using System.Collections.Generic;
using System.Text;

namespace EasyHome.Shared
{
    public class FUTPlayerModel
    {
        public long ID { get; set; }
        public DateTime InsertDate { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }

        public bool Untradeable { get; set; }
        public long Rating { get; set; }
        public long Owners { get; set; }

        public string Team { get; set; }
        public string League { get; set; }
        public long LoyaltyBonus { get; set; }
        public string Nationality { get; set; }
        public long MarketDataMinPrice { get; set; }
        public long MarketDataMaxPrice { get; set; }
        public bool SkipSBC { get; set; }
    }
}