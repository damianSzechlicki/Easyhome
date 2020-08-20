using EasyHome.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyHome.Data.Repositories
{
    public interface IFUTPlayerRepository : IBaseRepository<FUTPlayer>
    {
        Task<IEnumerable<FUTPlayer>> GetAllActive();
    }
}
