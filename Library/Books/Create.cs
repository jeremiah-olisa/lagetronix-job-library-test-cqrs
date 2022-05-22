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
    public class Create
    {
        public class Command : IRequest<Book>
        {
            public CreateBookDto book { get; set; }
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
                var book = _mapper.Map<Book>(request.book);
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync(cancellationToken);
                return book;
            }
        }
    }
}
