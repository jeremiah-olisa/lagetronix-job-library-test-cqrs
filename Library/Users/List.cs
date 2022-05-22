using Domain.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users
{
    public class List
    {
        public class Query : IRequest<PaginatedList<User>>
        {
            public PaginationQuery paginationQuery { get; set; }
        }

        public class Handler : IRequestHandler<Query, PaginatedList<User>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<PaginatedList<User>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await PaginatedList<User>.CreateAsync(_context.Users, request.paginationQuery.pageIndex, request.paginationQuery.pageSize);
            }
        }
    }
}
