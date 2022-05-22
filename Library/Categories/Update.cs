using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Domain.Dtos;
using AutoMapper;

namespace Application.Categories
{
    public class Update
    {
        public class Command : IRequest<Category>
        {
            public CreateCategoryDto category { get; set; }
            public int id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Category>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<Category> Handle(Command request, CancellationToken cancellationToken)
            {
                var categoryFromDb = await _context.Categories.FindAsync(request.id);
                
                _mapper.Map(request.category, categoryFromDb);

                await _context.SaveChangesAsync(cancellationToken);

                return categoryFromDb;
            }
        }
    }
}
