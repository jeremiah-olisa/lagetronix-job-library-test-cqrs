using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users
{
    public class Get
    {
        public class Query : IRequest<User>
        {
            public int id { get; set; }
        }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Users.FindAsync(request.id);
            }
        }
    }
}
