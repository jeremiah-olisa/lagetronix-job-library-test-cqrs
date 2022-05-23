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
    public class CategoryTest : BaseTest
    {
        private readonly ApiBroker _broker;

        public CategoryTest(ApiBroker broker) =>
            _broker = broker;

        private CreateCategoryDto CategoryDto() => new Filler<CreateCategoryDto>().Create();



        [Fact]
        public async Task GetCategory()
        {
            // given
            CreateCategoryDto inputCategory = CategoryDto();
            Category categoryCreated = await _broker.CreateCategoryAsync(inputCategory);

            categoryCreated.Should().BeOfType<Category>();

            // when
            Category category = await _broker.GetCategoryAsync(categoryCreated.Id);

            //expected
            category.Should().BeOfType<Category>();
            //category.Should().BeSameAs(inputCategory.Name, categoryCreated.Name);

            await _broker.DeleteCategoryAsync(categoryCreated.Id);
        }

        [Fact]
        public async Task GetCategories()
        {
            // given
            // when
            List<Category> categories = await _broker.GetCategoriesAsync();

            //expected
            categories.Should().BeOfType<List<Category>>(); ;

        }

        [Fact]
        public async Task CreateCategory()
        {
            // given
            CreateCategoryDto inputCategory = CategoryDto();

            // when
            Category categoryCreated = await _broker.CreateCategoryAsync(inputCategory);

            categoryCreated.Should().BeOfType<Category>();

            await _broker.DeleteCategoryAsync(categoryCreated.Id);

        }
        
        [Fact]
        public async Task UpdateCategory()
        {
            // given
            CreateCategoryDto createInputCategory = CategoryDto();
            Category categoryCreated = await _broker.CreateCategoryAsync(createInputCategory);

            CreateCategoryDto updateInputCategory = CategoryDto();
            Category categoryUpdated = await _broker.UpdateCategoryAsync(updateInputCategory, categoryCreated.Id);

            categoryCreated.Should().BeOfType<Category>();
            Assert.Equal(updateInputCategory.Name, categoryUpdated.Name);

            await _broker.DeleteCategoryAsync(categoryUpdated.Id);

        }
    }
}
