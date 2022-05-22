using Domain.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Books
{
    public class List
    {
        public class Query : IRequest<PaginatedList<Book>>
        {
            public PaginationQuery paginationQuery { get; set; }
        }

        public class Handler : IRequestHandler<Query, PaginatedList<Book>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<PaginatedList<Book>> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = _context.Books;
                return await PaginatedList<Book>.CreateAsync(data, request.paginationQuery.pageIndex, request.paginationQuery.pageSize);
            }
        }
    }
}
