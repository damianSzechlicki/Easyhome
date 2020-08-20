using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyHome.Data.Repositories;
using EasyHome.Shared.MSF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyHome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MSFTeamController : ControllerBase
    {
        private readonly IMSFTeamRepository _teamRepository;

        public MSFTeamController(IMSFTeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeamsAsync()
        {
            return Ok(await _teamRepository.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamByIDAsync(int id)
        {
            return Ok(await _teamRepository.GetByID(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MSFTeam team)
        {
            if (team == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var teamToUpdate = await _teamRepository.GetByID(team.ID);

            if (teamToUpdate == null)
                return NotFound();

            await _teamRepository.Update(team);

            return NoContent(); //success
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MSFTeam team)
        {
            if (team == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            await _teamRepository.Create(team);

            return NoContent(); //success
        }
    }
}