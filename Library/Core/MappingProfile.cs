using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace Application.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<Book, CreateBookDto>();

            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<UserFavourite, CreateUserFavouriteDto>();
            CreateMap<CreateUserFavouriteDto, UserFavourite>();

            CreateMap<User, CreateUserDto>();
            CreateMap<CreateUserDto, User>();

        }
    }
}
