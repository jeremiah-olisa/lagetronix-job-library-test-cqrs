using Application.Books;
using Domain.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public class BooksController : BaseController
    {
        public BooksController(DataContext context, IMediator mediator) : base(context, mediator)
        {
        }


        // GET: api/<BooksController>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<Book>>> Get([FromQuery] PaginationQuery paginationQuery)
        {
            return Ok(await _mediator.Send(new List.Query { paginationQuery = paginationQuery }));
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            return Ok(await _mediator.Send(new Get.Query { id = id }));
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<ActionResult<Book>> Post([FromBody] CreateBookDto book)
        {
            var _book = await _mediator.Send(new Create.Command { book = book });

            return Created($"/api/Books/{_book.Id}", _book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Put(int id, [FromBody] CreateBookDto book)
        {
            var data = await _mediator.Send(new Update.Command { book = book, id = id });

            return Ok(data);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            var data = await _mediator.Send(new Delete.Command { id = id });

            return NoContent();
        }
    }
}
