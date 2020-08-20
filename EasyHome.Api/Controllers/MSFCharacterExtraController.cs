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
    public class MSFCharacterExtraController : ControllerBase
    {
        private readonly IMSFCharacterExtraRepository _extraRepository;

        public MSFCharacterExtraController(IMSFCharacterExtraRepository extraRepository)
        {
            _extraRepository = extraRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCharactersAsync()
        {
            return Ok(await _extraRepository.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterByIDAsync(int id)
        {
            return Ok(await _extraRepository.GetByID(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MSFCharacterExtra extra)
        {
            if (extra == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var extraToUpdate = await _extraRepository.GetByID(extra.ID);

            if (extraToUpdate == null)
                return NotFound();

            await _extraRepository.Update(extra);

            return NoContent(); //success
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MSFCharacterExtra extra)
        {
            if (extra == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            await _extraRepository.Create(extra);

            return NoContent(); //success
        }
    }
}