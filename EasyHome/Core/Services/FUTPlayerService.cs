using EasyHome.Data.Repositories;
using EasyHome.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHome.Core.Services
{
    public class FUTPlayerService : BaseService<FUTPlayer>, IFUTPlayerService
    {
        public FUTPlayerService(IFUTPlayerRepository repository) : base(repository)
        {
        }

        public async Task<IEnumerable<FUTPlayer>> GetAllActive()
        {
            return (await _repository.GetAll(p => p.Active));
        }
    }
}
