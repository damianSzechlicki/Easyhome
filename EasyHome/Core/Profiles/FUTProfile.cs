using AutoMapper;
using EasyHome.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHome.Core.Profiles
{
    public class FUTProfile : Profile
    {
        public FUTProfile()
        {
            CreateMap<FUTPlayer, FUTPlayerModel>();
            CreateMap<FUTPlayerModel, FUTPlayer>();
        }
    }
}
