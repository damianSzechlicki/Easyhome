using AutoMapper;
using EasyHome.Core.Services;
using EasyHome.Shared.MSF;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHome.Pages
{
    public partial class MSFCharacterEdit : ComponentBase
    {
        [Inject]
        private IMapper _mapper { get; set; }
        [Inject]
        public IMSFCharacterService CharacterService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public int ID { get; set; }
        public MSFCharacterEditModel Character { get; set; }

        public string Message { get; set; }

        public bool CampaignFarmable { get; set; }
        public bool BlitzFarmable { get; set; }
        public bool RaidFarmable { get; set; }
        public bool WarFarmable { get; set; }
        public bool ArenaFarmable { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ID == 0)
            {
                Character = new MSFCharacterEditModel();
            }
            else
            {
                var entity = await CharacterService.GetByID(ID);
                Character = _mapper.Map<MSFCharacterEditModel>(entity);
            }

            CampaignFarmable = Character.Farmable.Contains(EasyHome.Shared.MSFFarmable.Campaign);
            BlitzFarmable = Character.Farmable.Contains(EasyHome.Shared.MSFFarmable.Blitz);
            RaidFarmable = Character.Farmable.Contains(EasyHome.Shared.MSFFarmable.Raid);
            WarFarmable = Character.Farmable.Contains(EasyHome.Shared.MSFFarmable.War);
        }

        protected async Task HandleValidSubmit()
        {
            var entity = _mapper.Map<MSFCharacter>(Character);

            if (Character.ID == 0)
            {
                await CharacterService.Create(entity);
            }
            else
            {
                await CharacterService.Update(entity);
            }
            NavigationManager.NavigateTo("/MSF/Character");
        }

        protected void CampaignFarmableChange(ChangeEventArgs e)
        {
            CampaignFarmable = Boolean.Parse(e.Value.ToString());
            if (CampaignFarmable)
            {
                if (!Character.Farmable.Contains(EasyHome.Shared.MSFFarmable.Campaign))
                {
                    Character.Farmable.Add(EasyHome.Shared.MSFFarmable.Campaign);
                }
            }
            else
            {
                Character.Farmable.Remove(EasyHome.Shared.MSFFarmable.Campaign);
            }
        }

        protected void BlitzFarmableChange(ChangeEventArgs e)
        {
            BlitzFarmable = Boolean.Parse(e.Value.ToString());
            if (BlitzFarmable)
            {
                if (!Character.Farmable.Contains(EasyHome.Shared.MSFFarmable.Blitz))
                {
                    Character.Farmable.Add(EasyHome.Shared.MSFFarmable.Blitz);
                }
            }
            else
            {
                Character.Farmable.Remove(EasyHome.Shared.MSFFarmable.Blitz);
            }
        }

        protected void ArenaFarmableChange(ChangeEventArgs e)
        {
            ArenaFarmable = Boolean.Parse(e.Value.ToString());
            if (ArenaFarmable)
            {
                if (!Character.Farmable.Contains(EasyHome.Shared.MSFFarmable.Arena))
                {
                    Character.Farmable.Add(EasyHome.Shared.MSFFarmable.Arena);
                }
            }
            else
            {
                Character.Farmable.Remove(EasyHome.Shared.MSFFarmable.Arena);
            }
        }

        protected void RaidFarmableChange(ChangeEventArgs e)
        {
            RaidFarmable = Boolean.Parse(e.Value.ToString());
            if (RaidFarmable)
            {
                if (!Character.Farmable.Contains(EasyHome.Shared.MSFFarmable.Raid))
                {
                    Character.Farmable.Add(EasyHome.Shared.MSFFarmable.Raid);
                }
            }
            else
            {
                Character.Farmable.Remove(EasyHome.Shared.MSFFarmable.Raid);
            }
        }

        protected void WarFarmableChange(ChangeEventArgs e)
        {
            WarFarmable = Boolean.Parse(e.Value.ToString());
            if (WarFarmable)
            {
                if (!Character.Farmable.Contains(EasyHome.Shared.MSFFarmable.War))
                {
                    Character.Farmable.Add(EasyHome.Shared.MSFFarmable.War);
                }
            }
            else
            {
                Character.Farmable.Remove(EasyHome.Shared.MSFFarmable.War);
            }
        }
    }
}
