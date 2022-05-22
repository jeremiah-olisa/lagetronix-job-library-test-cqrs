using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class Seed
    {
        private static Random gen = new Random();

        private static DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        public static async Task SeedUsers(DataContext context)
        {
            if (context.Users.Any()) return;

            var users = new List<User> {
                new User
                {
                    Name = Faker.Name.FullName(),
                    Email = "admin@library.lagetronix.com",
                    IsAdmin = true,
                    Password = "5F4DCC3B5AA765D61D8327DEB882CF99", // password
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,

                },
                new User
                {
                    Name = "Jeremiah Olisa",
                    Email = "jeremiah@lagetronix.com",
                    IsAdmin = true,
                    Password = "5F4DCC3B5AA765D61D8327DEB882CF99", // password
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,

                },
            };


            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();

        }

        public static async Task SeedCategories(DataContext context)
        {
            if (context.Categories.Any()) return;

            var categories = new List<Category> { };

            for (int i = 1; i <= 5; i++)
            {
                categories.Add(new Category
                {
                    Name = $"Category {i}",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,

                });
            }

            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();

        }

        public static async Task SeedBooks(DataContext context)
        {
            if (context.Books.Any()) return;

            var books = new List<Book> { };

            for (int i = 1; i <= 10; i++)
            {
                books.Add(new Book
                {
                    Title = $"Book {i}",
                    PublishDate = RandomDay(),
                    Description = String.Join(" ", Faker.Lorem.Sentences(3)),
                    AuthorName = Faker.Name.FullName(),
                    CategoryId = gen.Next(1, 5),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,

                });
            }

            await context.Books.AddRangeAsync(books);
            await context.SaveChangesAsync();
        }
    }
}
