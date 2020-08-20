using EasyHome.Shared.MSF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHome.Data.Repositories
{
    public class MSFCharacterRepository : BaseRepository<MSFCharacter>, IMSFCharacterRepository
    {

        public MSFCharacterRepository(EasyHomeDbContext easyHomeDbContext) : base(easyHomeDbContext)
        {
        }

        public async Task<IEnumerable<MSFCharacter>> GetCharactersByTeamAsync(int teamID)
        {
            return await _easyHomeDbContext.MSFCharacters.Where(c => c.TeamID == teamID).ToListAsync();
        }
    }
}
