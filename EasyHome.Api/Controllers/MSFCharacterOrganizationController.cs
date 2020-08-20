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
    public class MSFCharacterOrganizationController : ControllerBase
    {
        private readonly IMSFCharacterOrganizationRepository _organizationRepository;

        public MSFCharacterOrganizationController(IMSFCharacterOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCharactersAsync()
        {
            return Ok(await _organizationRepository.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterByIDAsync(int id)
        {
            return Ok(await _organizationRepository.GetByID(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MSFCharacterOrganization organization)
        {
            if (organization == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var organizationToUpdate = await _organizationRepository.GetByID(organization.ID);

            if (organizationToUpdate == null)
                return NotFound();

            await _organizationRepository.Update(organization);

            return NoContent(); //success
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MSFCharacterOrganization organization)
        {
            if (organization == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            await _organizationRepository.Create(organization);

            return NoContent(); //success
        }
    }
}