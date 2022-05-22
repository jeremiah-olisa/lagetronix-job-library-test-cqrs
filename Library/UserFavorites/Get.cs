using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserFavourites
{
    public class Get
    {
        public class Query : IRequest<UserFavourite>
        {
            public int id { get; set; }
        }

        public class Handler : IRequestHandler<Query, UserFavourite>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<UserFavourite> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.UserFavourites.FindAsync(request.id);
            }
        }
    }
}
