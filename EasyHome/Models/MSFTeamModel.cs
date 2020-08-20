using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHome.Models
{
    public class MSFTeamModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<MSFTeamCharacterModel> Characters { get; set; } = new List<MSFTeamCharacterModel>();
        public int Power { get => Characters.Sum(c => c.Power); }
    }
}
