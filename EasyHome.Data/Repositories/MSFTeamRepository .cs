using EasyHome.Shared.MSF;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyHome.Data.Repositories
{
    public class MSFTeamRepository : BaseRepository<MSFTeam>, IMSFTeamRepository
    {
        public MSFTeamRepository(EasyHomeDbContext easyHomeDbContext) : base(easyHomeDbContext)
        {
        }
    }
}
