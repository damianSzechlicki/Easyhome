using AutoMapper;
using EasyHome.Models;
using EasyHome.Shared;
using EasyHome.Shared.MSF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHome.Core.Profiles
{
    public class MSFProfile : Profile
    {
        public MSFProfile()
        {

            CreateMap<MSFCharacter, MSFCharacterOverviewModel>()
                .ForMember(c => c.Farmable, cd => cd.MapFrom(map => GetFarmableEnum(map.Farmable)))
                .ForMember(c => c.BasicSkillColor, cd => cd.MapFrom(map => GetBasicSkillColors(map.BasicSkill)))
                .ForMember(c => c.SpecialSkillColor, cd => cd.MapFrom(map => GetSpecialSkillColors(map.SpecialSkill)))
                .ForMember(c => c.UltimateSkillColor, cd => cd.MapFrom(map => GetUltimateSkillColors(map.UltimateSkill)))
                .ForMember(c => c.PassiveSkillColor, cd => cd.MapFrom(map => GetPassiveSkillColors(map.PassiveSkill)));
            CreateMap<MSFCharacterOverviewModel, MSFCharacter>()
                .ForMember(c => c.Farmable, cd => cd.MapFrom(map => GetFarmableString(map.Farmable)));
            CreateMap<MSFCharacter, MSFTeamCharacterModel>();

            CreateMap<MSFCharacter, MSFCharacterEditModel>()
                .ForMember(c => c.Farmable, cd => cd.MapFrom(map => GetFarmableEnum(map.Farmable)));
            CreateMap<MSFCharacterEditModel, MSFCharacter>()
                .ForMember(c => c.Farmable, cd => cd.MapFrom(map => GetFarmableString(map.Farmable)));

            CreateMap<MSFTeam, MSFTeamModel>();
            CreateMap<MSFTeamModel, MSFTeam>();
        }



        private List<MSFFarmable> GetFarmableEnum(string farmableString)
        {
            var farmable = new List<MSFFarmable>();
            if (!string.IsNullOrEmpty(farmableString))
            {
                var farmables = farmableString.Split(',');
                foreach (var item in farmables)
                {
                    var farmableEnum = Enum.Parse<MSFFarmable>(item);
                    farmable.Add(farmableEnum);
                }
            }
            return farmable;
        }

        private string GetFarmableString(List<MSFFarmable> farmables)
        {
            var farmable = string.Empty;
            foreach (var item in farmables)
            {
                farmable += item;
                if (item != farmables.Last())
                {
                    farmable += ",";
                }
            }
            return farmable;
        }

        private string GetBasicSkillColors(int skill)
        {
            if (skill == 7)
            {
                return "red";
            }
            else if (skill == 6)
            {
                return "orange";
            }
            else if (skill >= 4 && skill <= 5)
            {
                return "purple";
            }
            else if (skill >= 2 && skill <= 3)
            {
                return "blue";
            }
            else
            {
                return "green";
            }
        }

        private string GetSpecialSkillColors(int skill)
        {
            if (skill == 7)
            {
                return "red";
            }
            else if (skill == 6)
            {
                return "orange";
            }
            else if (skill >= 4 && skill <= 5)
            {
                return "purple";
            }
            else if (skill >= 2 && skill <= 3)
            {
                return "blue";
            }
            else
            {
                return "green";
            }
        }

        private string GetUltimateSkillColors(int? skill)
        {
            if (skill == null)
            {
                return "black";
            }
            else if (skill == 7)
            {
                return "red";
            }
            else if (skill == 6)
            {
                return "orange";
            }
            else if (skill >= 4 && skill <= 5)
            {
                return "purple";
            }
            else if (skill >= 2 && skill <= 3)
            {
                return "blue";
            }
            else
            {
                return "green";
            }
        }

        private string GetPassiveSkillColors(int skill)
        {
            if (skill == 5)
            {
                return "red";
            }
            else if (skill == 4)
            {
                return "orange";
            }
            else if (skill >= 2 && skill <= 3)
            {
                return "purple";
            }
            else if (skill == 1)
            {
                return "blue";
            }
            else
            {
                return "green";
            }
        }
    }
}
