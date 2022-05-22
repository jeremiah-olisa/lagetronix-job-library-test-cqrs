using MediatR;
using Persistence;

namespace API.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(DataContext context, IMediator mediator) : base(context, mediator)
        {
        }
    }
}
