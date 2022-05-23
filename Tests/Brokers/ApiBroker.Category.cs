using Domain.Dtos;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests.Brokers
{
    public partial class ApiBroker
    {
        private const string categoriesRelativeUrl = "Api/Categories";

        public async ValueTask<Category> CreateCategoryAsync(CreateCategoryDto dto) =>
            await this.apiFactoryClient.PostContentAsync<CreateCategoryDto, Category>(categoriesRelativeUrl, dto);

        public async ValueTask<List<Category>> GetCategoriesAsync() =>
            await this.apiFactoryClient.GetContentAsync<List<Category>>(categoriesRelativeUrl);

        public async ValueTask<Category> GetCategoryAsync(int Id) =>
            await this.apiFactoryClient.GetContentAsync<Category>($"{categoriesRelativeUrl}/{Id}");

        public async ValueTask<Category> UpdateCategoryAsync(CreateCategoryDto dto, int Id) =>
                await this.apiFactoryClient.PutContentAsync<CreateCategoryDto, Category>($"{categoriesRelativeUrl}/{Id}", dto);

        public async ValueTask DeleteCategoryAsync(int Id) =>
            await this.apiFactoryClient.DeleteContentAsync($"{categoriesRelativeUrl}/{Id}");
    }
}
