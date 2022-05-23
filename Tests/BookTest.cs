using Domain.Dtos;
using System.Threading.Tasks;
using Tests.Brokers;
using Xunit;
using Tynamix.ObjectFiller;
using FluentAssertions;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class BookTest : BaseTest
    {
        private readonly ApiBroker _broker;

        public BookTest(ApiBroker broker) =>
            _broker = broker;

        private CreateBookDto BookDto() => new Filler<CreateBookDto>().Create();
        private CreateCategoryDto CategoryDto() => new Filler<CreateCategoryDto>().Create();



        [Fact]
        public async Task GetBook()
        {
            // given
            CreateCategoryDto inputCategory = CategoryDto();
            Category categoryCreated = await _broker.CreateCategoryAsync(inputCategory);

            CreateBookDto inputBook = BookDto();
            inputBook.CategoryId = categoryCreated.Id;

            Book bookCreated = await _broker.CreateBookAsync(inputBook);

            bookCreated.Should().BeOfType<Book>();

            // when
            Book book = await _broker.GetBookAsync(bookCreated.Id);

            //expected
            book.Should().BeOfType<Book>();
            Assert.Equal(inputBook.AuthorName, bookCreated.AuthorName);

            await _broker.DeleteBookAsync(bookCreated.Id);
            await _broker.DeleteCategoryAsync(categoryCreated.Id);
        }

        [Fact]
        public async Task GetBooks()
        {
            // given
            // when
            List<Book> books = await _broker.GetBooksAsync();

            //expected
            books.Should().BeOfType<List<Book>>(); ;

        }

        [Fact]
        public async Task CreateBook()
        {
            // given
            CreateCategoryDto inputCategory = CategoryDto();
            Category categoryCreated = await _broker.CreateCategoryAsync(inputCategory);

            CreateBookDto inputBook = BookDto();
            inputBook.CategoryId = categoryCreated.Id;

            // when
            Book bookCreated = await _broker.CreateBookAsync(inputBook);

            bookCreated.Should().BeOfType<Book>();

            await _broker.DeleteBookAsync(bookCreated.Id);
            await _broker.DeleteCategoryAsync(categoryCreated.Id);
        }

        [Fact]
        public async Task UpdateBook()
        {
            // given
            CreateCategoryDto inputCategory = CategoryDto();
            Category categoryCreated = await _broker.CreateCategoryAsync(inputCategory);

            CreateBookDto createInputBook = BookDto();
            createInputBook.CategoryId = categoryCreated.Id;

            // when
            Book bookCreated = await _broker.CreateBookAsync(createInputBook);

            CreateBookDto updateInputBook = BookDto();
            updateInputBook.CategoryId = categoryCreated.Id;
            Book bookUpdated = await _broker.UpdateBookAsync(updateInputBook, bookCreated.Id);

            bookUpdated.Should().BeOfType<Book>();
            Assert.Equal(bookUpdated.AuthorName, updateInputBook.AuthorName);

            await _broker.DeleteBookAsync(bookUpdated.Id);
            await _broker.DeleteCategoryAsync(categoryCreated.Id);

        }
    }
}
