using Domain.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserFavourites
{
    public class List
    {
        public class Query : IRequest<PaginatedList<UserFavourite>>
        {

            public int? userId { get; set; }
            public PaginationQuery paginationQuery { get; set; }
        }

        public class Handler : IRequestHandler<Query, PaginatedList<UserFavourite>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<PaginatedList<UserFavourite>> Handle(Query request, CancellationToken cancellationToken)
            {

                IQueryable<UserFavourite> data;

                if (request.userId != 0 && !string.IsNullOrEmpty(request.userId.ToString()))
                {
                    data = _context.UserFavourites.Where(col => col.UserId == request.userId);
                }
                else
                {
                    data = _context.UserFavourites;
                }

                return await PaginatedList<UserFavourite>.CreateAsync(data, request.paginationQuery.pageIndex, request.paginationQuery.pageSize);
            }
        }
    }
}
