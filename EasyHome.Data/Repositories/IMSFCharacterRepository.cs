using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyHome.Shared.MSF;

namespace EasyHome.Data.Repositories
{
    public interface IMSFCharacterRepository : IBaseRepository<MSFCharacter>
    {
        Task<IEnumerable<MSFCharacter>> GetCharactersByTeamAsync(int teamID);
    }
}
