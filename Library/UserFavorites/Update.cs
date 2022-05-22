using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Domain.Dtos;
using AutoMapper;

namespace Application.UserFavourites
{
    public class Update
    {
        public class Command : IRequest<UserFavourite>
        {
            public CreateUserFavouriteDto userFavourite { get; set; }
            public int id { get; set; }
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
                var userFavouriteFromDb = await _context.UserFavourites.FindAsync(request.id);
                
                _mapper.Map(request.userFavourite, userFavouriteFromDb);

                await _context.SaveChangesAsync(cancellationToken);

                return userFavouriteFromDb;
            }
        }
    }
}
