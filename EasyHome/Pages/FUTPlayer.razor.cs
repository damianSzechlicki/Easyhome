using AutoMapper;
using EasyHome.Core.Services;
using EasyHome.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHome.Pages
{
    public partial class FUTPlayer : ComponentBase
    {
        private IEnumerable<FUTPlayerModel> Players { get; set; }
        [Inject]
        private IMapper _mapper { get; set; }
        [Inject]
        private IFUTPlayerService _futPlayerService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var players = await _futPlayerService.GetAllActive();
            Players = _mapper.Map<IEnumerable<FUTPlayerModel>>(players);
        }

        protected async Task EditEventAsync(FUTPlayerModel e)
        {
            var entity = _mapper.Map<Shared.FUTPlayer>(e);
            await _futPlayerService.Update(entity);
        }
    }
}
