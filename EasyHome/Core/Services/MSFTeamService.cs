using EasyHome.Data.Repositories;
using EasyHome.Shared.MSF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHome.Core.Services
{
    public class MSFTeamService : BaseService<MSFTeam>, IMSFTeamService
    {
        public MSFTeamService(IMSFTeamRepository repository) : base(repository)
        {
        }
    }
}
