using AutoMapper;
using EasyHome.Core.Services;
using EasyHome.Shared;
using EasyHome.Shared.MSF;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHome.Pages
{
    public partial class MSFCharacterOverview : ComponentBase
    {
        private IEnumerable<MSFCharacterOverviewModel> Characters { get; set; }
        [Inject]
        private IMapper _mapper { get; set; }
        [Inject]
        private IMSFCharacterService _characterService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var characters = await _characterService.GetAll();
            Characters = _mapper.Map<IEnumerable<MSFCharacterOverviewModel>>(characters.OrderBy(c=>c.Favorite).ThenByDescending(c=>c.Power));
        }

        protected async Task EditEventAsync(MSFCharacterOverviewModel e)
        {
            var entity = _mapper.Map<MSFCharacter>(e);
            await _characterService.Update(entity);
        }
    }
}