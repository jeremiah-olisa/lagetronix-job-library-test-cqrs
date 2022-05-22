using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Books
{
    public class Get
    {
        public class Query : IRequest<Book>
        {
            public int id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Book>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Book> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Books.Where(col => col.Id == request.id).Include(tbl => tbl.LikedBy).FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}
