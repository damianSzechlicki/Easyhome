using EasyHome.Shared;
using EasyHome.Shared.MSF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHome.Core.Services
{
    public interface IMSFCharacterService : IBaseService<MSFCharacter>
    {
        Task<List<MSFCharacter>> GetForTeam(int teamID);
        Task<List<MSFCharacter>> GetWithoutTeam();

    }
}
