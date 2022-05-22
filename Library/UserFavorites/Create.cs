using Domain.Models;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using System.Threading;
using Domain.Dtos;
using AutoMapper;

namespace Application.UserFavourites
{
    public class Create
    {
        public class Command : IRequest<UserFavourite>
        {
            public CreateUserFavouriteDto userFavourite { get; set; }
        }

        public class Handler : IRequestHandler<Command, UserFavourite>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper; 

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<UserFavourite> Handle(Command request, CancellationToken cancellationToken)
            {
                var userFavourite = _mapper.Map<UserFavourite>(request.userFavourite);
                await _context.UserFavourites.AddAsync(userFavourite);
                await _context.SaveChangesAsync(cancellationToken);
                return userFavourite;
            }
        }
    }
}
