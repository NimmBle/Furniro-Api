namespace furniro_server
{
    using AutoMapper;
    using furniro_server.Models;
    using furniro_server.Models.DTOs;
    using furniro_server.Models.DTOs.ProductDtos;
    using furniro_server.Models.DTOs.UserDtos;
    using furniro_server.Models.Entities;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, GetCategoryDto>();
            CreateMap<AddCategoryDto, Category>();
            CreateMap<AddCategoryDto, GetCategoryDto>();

            CreateMap<AddUserDto, User>();

            CreateMap<AddProductDto, Product>();
            CreateMap<Product, GetProductDto>();
            CreateMap<GetProductDto, Product>();
        }
    }
}