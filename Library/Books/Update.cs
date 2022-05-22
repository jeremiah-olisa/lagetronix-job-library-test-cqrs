using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Domain.Dtos;
using AutoMapper;

namespace Application.Books
{
    public class Update
    {
        public class Command : IRequest<Book>
        {
            public CreateBookDto book { get; set; }
            public int id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Book>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<Book> Handle(Command request, CancellationToken cancellationToken)
            {
                var bookFromDb = await _context.Books.FindAsync(request.id);
                
                _mapper.Map(request.book, bookFromDb);

                await _context.SaveChangesAsync(cancellationToken);

                return bookFromDb;
            }
        }
    }
}
