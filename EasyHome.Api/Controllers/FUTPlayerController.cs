using EasyHome.Data.Repositories;
using EasyHome.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FUTPlayerController : BaseController<FUTPlayer, IFUTPlayerRepository>
    {
        public FUTPlayerController(IFUTPlayerRepository repository) : base(repository)
        {
        }
    }
}
