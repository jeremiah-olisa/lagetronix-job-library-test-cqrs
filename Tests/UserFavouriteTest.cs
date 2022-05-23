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
    public class UserFavouriteTest : BaseTest
    {
        private readonly ApiBroker _broker;

        public UserFavouriteTest(ApiBroker broker) =>
            _broker = broker;

        private CreateBookDto BookDto() => new Filler<CreateBookDto>().Create();
        private CreateUserDto UserDto() => new Filler<CreateUserDto>().Create();
        private CreateCategoryDto CategoryDto() => new Filler<CreateCategoryDto>().Create();



        [Fact]
        public async Task GetUserFavorite()
        {
            // given
            CreateUserDto inputUser = UserDto();
            User userCreated = await _broker.CreateUserAsync(inputUser);
            userCreated.Should().BeOfType<User>();

            CreateCategoryDto inputCategory = CategoryDto();
            Category categoryCreated = await _broker.CreateCategoryAsync(inputCategory);
            categoryCreated.Should().BeOfType<Category>();
            
            CreateBookDto inputBook = BookDto();
            inputBook.CategoryId = categoryCreated.Id;
            Book bookCreated = await _broker.CreateBookAsync(inputBook);
            bookCreated.Should().BeOfType<Book>();

            CreateUserFavouriteDto inputUserFavouriteDto = new CreateUserFavouriteDto { BookId = bookCreated.Id, UserId = userCreated.Id };
            UserFavourite userFavouriteCreated = await _broker.CreateUserFavouriteAsync(inputUserFavouriteDto);
            userFavouriteCreated.Should().BeOfType<UserFavourite>();
            Assert.Equal(inputUserFavouriteDto.BookId, userFavouriteCreated.BookId);
            // when

            //expected

            await _broker.DeleteBookAsync(bookCreated.Id);
            await _broker.DeleteCategoryAsync(categoryCreated.Id);
            await _broker.DeleteUserFavouriteAsync(userFavouriteCreated.Id);
        }

        [Fact]
        public async Task GetUsersFavourites()
        {
            // given
            // when
            List<UserFavourite> books = await _broker.GetUsersFavouritesAsync();

            //expected
            books.Should().BeOfType<List<UserFavourite>>(); ;

        }
        
        [Fact]
        public async Task GetUserFavourites()
        {
            CreateUserDto inputUser = UserDto();
            User userCreated = await _broker.CreateUserAsync(inputUser);
            userCreated.Should().BeOfType<User>();

            List<UserFavourite> books = await _broker.GetUserFavouritesAsync(userCreated.Id);

            //expected
            books.Should().BeOfType<List<UserFavourite>>();

            await _broker.DeleteUserAsync(userCreated.Id);

        }
    }
}
