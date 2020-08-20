using System;
using System.Collections.Generic;
using System.Text;

namespace EasyHome.Shared.MSF
{
    public class MSFCharacter : BaseEntity
    {
        public string Name { get; set; }
        public bool Available { get; set; }
        public int Level { get; set; }
        public int Power { get; set; }
        public int Tier { get; set; }
        public int Star { get; set; }
        public int RedStar { get; set; }
        public int BasicSkill { get; set; }
        public int SpecialSkill { get; set; }
        public int? UltimateSkill { get; set; }
        public int PassiveSkill { get; set; }
        public MSFAllegiance Allegiance { get; set; }
        public MSFJurisdiction Jurisdiction { get; set; }
        public MSFOrigin Origin { get; set; }
        public MSFCharacterClass Class { get; set; }
        public string Organizations { get; set; }
        public string Extras { get; set; }
        public int TeamID { get; set; }
        public bool Favorite { get; set; }
        public int Shard { get; set; }
        public string Farmable { get; set; }
    }
}
