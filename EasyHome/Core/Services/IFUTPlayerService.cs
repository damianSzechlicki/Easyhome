using EasyHome.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHome.Core.Services
{
    public interface IFUTPlayerService : IBaseService<FUTPlayer>
    {
        Task<IEnumerable<FUTPlayer>> GetAllActive();
    }
}
