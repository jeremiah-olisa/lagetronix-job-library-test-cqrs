using Domain.Dtos;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests.Brokers
{
    public partial class ApiBroker
    {
        private const string booksRelativeUrl = "Api/Books";

        public async ValueTask<Book> CreateBookAsync(CreateBookDto dto) =>
            await this.apiFactoryClient.PostContentAsync<CreateBookDto, Book>(booksRelativeUrl, dto);

        public async ValueTask<List<Book>> GetBooksAsync() =>
            await this.apiFactoryClient.GetContentAsync<List<Book>>(booksRelativeUrl);

        public async ValueTask<Book> GetBookAsync(int Id) =>
            await this.apiFactoryClient.GetContentAsync<Book>($"{booksRelativeUrl}/{Id}");

        public async ValueTask<Book> UpdateBookAsync(CreateBookDto dto, int Id) =>
                await this.apiFactoryClient.PutContentAsync<CreateBookDto, Book>($"{booksRelativeUrl}/{Id}", dto);

        public async ValueTask DeleteBookAsync(int Id) =>
            await this.apiFactoryClient.DeleteContentAsync($"{booksRelativeUrl}/{Id}");
    }
}
