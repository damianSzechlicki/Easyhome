using EasyHome.Data.Repositories;
using EasyHome.Shared;
using EasyHome.Shared.MSF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHome.Core.Services
{
    public class MSFCharacterService : BaseService<MSFCharacter>, IMSFCharacterService
    {
        public MSFCharacterService(IMSFCharacterRepository repository) : base(repository)
        {
        }

        public async Task<List<MSFCharacter>> GetForTeam(int teamID)
        {
            return (await _repository.GetAll(where: c => c.TeamID == teamID)).ToList();
        }

        public async Task<List<MSFCharacter>> GetWithoutTeam()
        {
            return (await _repository.GetAll(order: c => c.Power, orderDirectory: Shared.Utilis.OrderDirectory.Desc, where: c => c.TeamID == 0 && c.Available)).ToList();
        }
    }
}
