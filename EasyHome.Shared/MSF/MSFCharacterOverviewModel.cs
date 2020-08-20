using System;
using System.Collections.Generic;
using System.Text;

namespace EasyHome.Shared.MSF
{
    public class MSFCharacterOverviewModel
    {
        public int ID { get; set; }
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
        public bool Favorite { get; set; }
        public int Shard { get; set; }
        public MSFAllegiance Allegiance { get; set; }
        public MSFJurisdiction Jurisdiction { get; set; }
        public MSFOrigin Origin { get; set; }
        public MSFCharacterClass Class { get; set; }
        public string Organizations { get; set; }
        public string Extras { get; set; }
        public int TeamID { get; set; }
        public string Team { get; set; }
        public List<MSFFarmable> Farmable { get; set; }


        public int MaxShard { get => GetMaxShard(); }
        public string BasicSkillColor { get; set; }
        public string SpecialSkillColor { get; set; }
        public string UltimateSkillColor { get; set; }
        public string PassiveSkillColor { get; set; }

        private int GetMaxShard()
        {
            return Star switch
            {
                1 => 45,
                2 => 55,
                3 => 80,
                4 => 130,
                5 => 200,
                6 => 300,
                _ => 0,
            };
        }
    }
}
