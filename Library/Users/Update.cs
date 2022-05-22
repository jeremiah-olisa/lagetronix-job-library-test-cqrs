using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Domain.Dtos;
using AutoMapper;

namespace Application.Users
{
    public class Update
    {
        public class Command : IRequest<User>
        {
            public CreateUserDto user { get; set; }
            public int id { get; set; }
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
                var userFromDb = await _context.Users.FindAsync(request.id);
                
                _mapper.Map(request.user, userFromDb);

                await _context.SaveChangesAsync(cancellationToken);

                return userFromDb;
            }
        }
    }
}
