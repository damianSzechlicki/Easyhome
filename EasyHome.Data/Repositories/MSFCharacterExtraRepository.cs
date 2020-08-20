using EasyHome.Shared.MSF;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyHome.Data.Repositories
{
    public class MSFCharacterExtraRepository : BaseRepository<MSFCharacterExtra>, IMSFCharacterExtraRepository
    {
        public MSFCharacterExtraRepository(EasyHomeDbContext easyHomeDbContext) : base(easyHomeDbContext)
        {
        }
    }
}
