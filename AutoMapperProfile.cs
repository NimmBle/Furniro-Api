using AutoMapper;
using furniro_server.DTOs.CategoryDTOs;
using furniro_server.Entities;

namespace furniro_server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddCategoryDTO, Category>();
            CreateMap<Category, GetCategoryDTO>();
        }
    }
}