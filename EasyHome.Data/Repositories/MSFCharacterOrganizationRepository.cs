using EasyHome.Shared.MSF;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyHome.Data.Repositories
{
    public class MSFCharacterOrganizationRepository : BaseRepository<MSFCharacterOrganization>, IMSFCharacterOrganizationRepository
    {
        public MSFCharacterOrganizationRepository(EasyHomeDbContext easyHomeDbContext) : base(easyHomeDbContext)
        {
        }
    }
}
