using Application.Categories;
using Domain.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public class CategoriesController : BaseController
    {
        public CategoriesController(DataContext context, IMediator mediator) : base(context, mediator)
        {
        }

        // GET: api/<CategoriesController>
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<Category>>> Get([FromQuery] PaginationQuery paginationQuery)
        {
            return Ok(await _mediator.Send(new List.Query { paginationQuery = paginationQuery }));
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            return Ok(await _mediator.Send(new Get.Query { id = id }));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] CreateCategoryDto category)
        {
            var _category = await _mediator.Send(new Create.Command { category = category });

            return Created($"/api/Categories/{_category.Id}", _category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> Put(int id, [FromBody] CreateCategoryDto category)
        {
            var data = await _mediator.Send(new Update.Command { category = category, id = id });

            return Ok(data);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            var data = await _mediator.Send(new Delete.Command { id = id });

            return NoContent();
        }
    }
}
