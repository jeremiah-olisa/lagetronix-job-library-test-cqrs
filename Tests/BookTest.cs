using Application.Books;
using Domain.Models;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class BookTest : BaseTest
    {
        public BookTest(Mock<IMediator> mediator) : base(mediator)
        {
        }

        [Fact]
        public void GetBooks()
        {
            //var list = new List.Query();
            //var books = _mediator.Setup(m => m.Send(list)).ReturnsAsync();

            //Assert.IsType<List<Book>>(books)    

        }
    }
}
