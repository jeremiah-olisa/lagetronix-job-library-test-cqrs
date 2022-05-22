using Domain.Models;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using System.Threading;
using Domain.Dtos;
using AutoMapper;

namespace Application.Users
{
    public class Create
    {
        public class Command : IRequest<User>
        {
            public CreateUserDto user { get; set; }
        }

        public class Handler : IRequestHandler<Command, User>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper; 

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = _mapper.Map<User>(request.user);
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync(cancellationToken);
                return user;
            }
        }
    }
}
