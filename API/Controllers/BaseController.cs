using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]

    public class BaseController : ControllerBase
    {
        public readonly DataContext _context;
        public readonly IMediator _mediator;

        public BaseController(DataContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

    }
}
