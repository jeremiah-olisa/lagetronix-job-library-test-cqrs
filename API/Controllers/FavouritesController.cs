using Application.UserFavourites;
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
    public class FavouritesController : BaseController
    {
        public FavouritesController(DataContext context, IMediator mediator) : base(context, mediator)
        {
        }

        // GET: api/<FavouritesController>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<UserFavourite>>> Get([FromQuery] PaginationQuery paginationQuery)
        {
            return Ok(await _mediator.Send(new List.Query { paginationQuery = paginationQuery }));
        }

        // GET: api/<FavouritesController>/User/5
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<PaginatedList<UserFavourite>>> Get(int userId, [FromQuery] PaginationQuery paginationQuery)
        {
            return Ok(await _mediator.Send(new List.Query { userId = userId, paginationQuery = paginationQuery }));
        }

        // GET api/<FavoritesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserFavourite>> Get(int id)
        {
            var data = await _mediator.Send(new Get.Query { id = id });
            if (data == null) return NotFound();
            return Ok(data);
        }

        // POST api/<FavoritesController>
        [HttpPost]
        public async Task<ActionResult<UserFavourite>> Post([FromBody] CreateUserFavouriteDto userFavourite)
        {
            var _book = await _mediator.Send(new Create.Command { userFavourite = userFavourite });

            return Created($"/api/Favorites/{_book.Id}", _book);
        }

        // PUT api/<FavoritesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserFavourite>> Put(int id, [FromBody] CreateUserFavouriteDto userFavourite)
        {
            var data = await _mediator.Send(new Update.Command { userFavourite = userFavourite, id = id });

            return Ok(data);
        }

        // DELETE api/<FavoritesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            var data = await _mediator.Send(new Delete.Command { id = id });

            return NoContent();
        }
    }
}
