using Application.Users;
using Domain.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(DataContext context, IMediator mediator) : base(context, mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<User>>> Get([FromQuery] PaginationQuery paginationQuery)
        {
            return Ok(await _mediator.Send(new List.Query { paginationQuery = paginationQuery }));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            return Ok(await _mediator.Send(new Get.Query { id = id }));
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] CreateUserDto user)
        {
            var _user = await _mediator.Send(new Create.Command { user = user });

            return Created($"/api/Users/{_user.Id}", _user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] CreateUserDto user)
        {
            var data = await _mediator.Send(new Update.Command { user = user, id = id });

            return Ok(data);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            var data = await _mediator.Send(new Delete.Command { id = id });

            return NoContent();
        }
    }
}
