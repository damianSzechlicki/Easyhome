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
    public class MSFCharacterController : ControllerBase
    {
        private readonly IMSFCharacterRepository _characterRepository;

        public MSFCharacterController(IMSFCharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCharactersAsync()
        {
            return Ok(await _characterRepository.GetAll());
        }

        [HttpGet("GetByTeam/{teamID}")]
        public async Task<IActionResult> GetByTeam(int teamID)
        {
            return Ok(await _characterRepository.GetCharactersByTeamAsync(teamID));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterByIDAsync(int id)
        {
            return Ok(await _characterRepository.GetByID(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MSFCharacter character)
        {
            if (character == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var characterToUpdate = await _characterRepository.GetByID(character.ID);

            if (characterToUpdate == null)
                return NotFound();

            await _characterRepository.Update(character);

            return NoContent(); //success
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MSFCharacter character)
        {
            if (character == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            await _characterRepository.Create(character);

            return NoContent(); //success
        }
    }
}