using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyHome.Shared.MSF
{
    public class MSFCharacterEditModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }
        [Range(0,75)]
        public int Level { get; set; }
        public int Power { get; set; }
        public int Tier { get; set; }
        [Range(0,7)]
        public int Star { get; set; }
        [Range(0,7)]
        public int RedStar { get; set; }
        [Range(0,7)]
        public int BasicSkill { get; set; }
        [Range(0,7)]
        public int SpecialSkill { get; set; }
        [Range(0,7)]
        public int? UltimateSkill { get; set; }
        [Range(0,5)]
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
        public List<MSFFarmable> Farmable { get; set; }

    }
}
