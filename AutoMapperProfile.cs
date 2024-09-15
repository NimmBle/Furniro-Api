namespace furniro_server
{
    using AutoMapper;
    using furniro_server.Models;
    using furniro_server.Models.DTOs;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, GetCategoryDto>();
            CreateMap<AddCategoryDto, Category>();
            CreateMap<AddCategoryDto, GetCategoryDto>();
        }
    }
}