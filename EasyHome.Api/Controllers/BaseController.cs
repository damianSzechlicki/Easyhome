using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyHome.Data.Repositories;
using EasyHome.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EasyHome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TRepository> : ControllerBase
        where TEntity : BaseEntity
        where TRepository : IBaseRepository<TEntity>
    {
        protected readonly TRepository _repository;

        public BaseController(TRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCharactersAsync()
        {
            return Ok(await _repository.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterByIDAsync(int id)
        {
            return Ok(await _repository.GetByID(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TEntity extra)
        {
            if (extra == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var extraToUpdate = await _repository.GetByID(extra.ID);

            if (extraToUpdate == null)
                return NotFound();

            await _repository.Update(extra);

            return NoContent(); //success
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TEntity extra)
        {
            if (extra == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            await _repository.Create(extra);

            return NoContent(); //success
        }

    }
}