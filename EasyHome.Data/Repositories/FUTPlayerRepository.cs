using EasyHome.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHome.Data.Repositories
{
    public class FUTPlayerRepository : BaseRepository<FUTPlayer>, IFUTPlayerRepository
    {
        public FUTPlayerRepository(EasyHomeDbContext easyHomeDbContext) : base(easyHomeDbContext)
        {
        }

        public async Task<IEnumerable<FUTPlayer>> GetAllActive()
        {
            return await _easyHomeDbContext.FUTPlayer.Where(p=>p.Active).OrderByDescending(p=>p.Rating).ToListAsync();
        }
    }
}
