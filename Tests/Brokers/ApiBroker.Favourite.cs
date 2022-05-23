using Domain.Dtos;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests.Brokers
{
    public partial class ApiBroker
    {
        private const string userFavouritesRelativeUrl = "Api/Favourites";

        public async ValueTask<UserFavourite> CreateUserFavouriteAsync(CreateUserFavouriteDto dto) =>
            await this.apiFactoryClient.PostContentAsync<CreateUserFavouriteDto, UserFavourite>(userFavouritesRelativeUrl, dto);

        public async ValueTask<List<UserFavourite>> GetUsersFavouritesAsync() =>
            await this.apiFactoryClient.GetContentAsync<List<UserFavourite>>(userFavouritesRelativeUrl);

        public async ValueTask<List<UserFavourite>> GetUserFavouritesAsync(int userId) =>
            await this.apiFactoryClient.GetContentAsync<List<UserFavourite>>($"{userFavouritesRelativeUrl}/User/{userId}");

        public async ValueTask<UserFavourite> GetUserFavouriteAsync(int Id) =>
            await this.apiFactoryClient.GetContentAsync<UserFavourite>($"{userFavouritesRelativeUrl}/{Id}");

        public async ValueTask<UserFavourite> UpdateUserFavouriteAsync(CreateUserFavouriteDto dto, int Id) =>
                await this.apiFactoryClient.PutContentAsync<CreateUserFavouriteDto, UserFavourite>($"{userFavouritesRelativeUrl}/{Id}", dto);

        public async ValueTask DeleteUserFavouriteAsync(int Id) =>
            await this.apiFactoryClient.DeleteContentAsync($"{userFavouritesRelativeUrl}/{Id}");
    }
}
