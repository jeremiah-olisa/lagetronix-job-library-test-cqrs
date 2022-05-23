using Domain.Dtos;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests.Brokers
{
    public partial class ApiBroker
    {
        private const string userRelativeUrl = "Api/Users";

        public async ValueTask<User> CreateUserAsync(CreateUserDto dto) =>
            await this.apiFactoryClient.PostContentAsync<CreateUserDto, User>(userRelativeUrl, dto);

        public async ValueTask<List<User>> GetUsersAsync() =>
            await this.apiFactoryClient.GetContentAsync<List<User>>(userRelativeUrl);

        public async ValueTask<User> GetUserAsync(int Id) =>
            await this.apiFactoryClient.GetContentAsync<User>($"{userRelativeUrl}/{Id}");

        public async ValueTask<User> UpdateUserAsync(CreateUserDto dto, int Id) =>
                await this.apiFactoryClient.PutContentAsync<CreateUserDto, User>($"{userRelativeUrl}/{Id}", dto);

        public async ValueTask DeleteUserAsync(int Id) =>
            await this.apiFactoryClient.DeleteContentAsync($"{userRelativeUrl}/{Id}");
    }
}
