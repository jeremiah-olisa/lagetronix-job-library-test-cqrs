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
    public class UserTest : BaseTest
    {
        private readonly ApiBroker _broker;

        public UserTest(ApiBroker broker) =>
            _broker = broker;

        private CreateUserDto UserDto() => new Filler<CreateUserDto>().Create();



        [Fact]
        public async Task GetUser()
        {
            // given
            CreateUserDto inputUser = UserDto();
            User userCreated = await _broker.CreateUserAsync(inputUser);

            userCreated.Should().BeOfType<User>();

            // when
            User user = await _broker.GetUserAsync(userCreated.Id);

            //expected
            user.Should().BeOfType<User>();
            //user.Should().BeSameAs(inputUser.Name, userCreated.Name);

            await _broker.DeleteUserAsync(userCreated.Id);
        }

        [Fact]
        public async Task GetUsers()
        {
            // given
            // when
            List<User> users = await _broker.GetUsersAsync();

            //expected
            users.Should().BeOfType<List<User>>(); ;

        }

        [Fact]
        public async Task CreateUser()
        {
            // given
            CreateUserDto inputUser = UserDto();

            // when
            User userCreated = await _broker.CreateUserAsync(inputUser);

            userCreated.Should().BeOfType<User>();

            await _broker.DeleteUserAsync(userCreated.Id);

        }
        
        [Fact]
        public async Task UpdateUser()
        {
            // given
            CreateUserDto createInputUser = UserDto();
            User userCreated = await _broker.CreateUserAsync(createInputUser);

            CreateUserDto updateInputUser = UserDto();
            User userUpdated = await _broker.UpdateUserAsync(updateInputUser, userCreated.Id);

            userCreated.Should().BeOfType<User>();
            Assert.Equal(updateInputUser.Name, userUpdated.Name);

            await _broker.DeleteUserAsync(userUpdated.Id);

        }
    }
}
