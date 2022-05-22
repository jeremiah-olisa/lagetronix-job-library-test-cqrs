using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categories
{
    public class Get
    {
        public class Query : IRequest<Category>
        {
            public int id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Category>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Category> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Categories.FindAsync(request.id);
            }
        }
    }
}
