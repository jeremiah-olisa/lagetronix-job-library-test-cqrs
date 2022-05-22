using Domain.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categories
{
    public class List
    {
        public class Query : IRequest<PaginatedList<Category>>
        {
            public PaginationQuery paginationQuery { get; set; }
        }

        public class Handler : IRequestHandler<Query, PaginatedList<Category>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<PaginatedList<Category>> Handle(Query request, CancellationToken cancellationToken)
            {
               return await PaginatedList<Category>.CreateAsync(_context.Categories, request.paginationQuery.pageIndex, request.paginationQuery.pageSize);
            }
        }
    }
}
