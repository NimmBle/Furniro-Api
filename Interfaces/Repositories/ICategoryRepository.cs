namespace furniro_server.Interfaces.Repositories
{
    using furniro_server.Models.DTOs;
    using furniro_server.Models.Entities;

    public interface ICategoryRepository
    {
        Task<ServiceResponse<IEnumerable<GetCategoryDto>>> GetAllCategories(int skip, int take);
        Task<ServiceResponse<GetCategoryDto>> GetCategoryById(int id);
        Task<ServiceResponse<GetCategoryDto>> AddCategory(AddCategoryDto categoryDTO);
        Task<ServiceResponse<GetCategoryDto>> UpdateCategory(int id, AddCategoryDto categoryDTO);
        Task<bool> DeleteCategory(int id);
    }
}