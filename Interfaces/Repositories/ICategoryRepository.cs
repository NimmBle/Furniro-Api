namespace furniro_server.Interfaces.Repositories
{
    using furniro_server.Models;
    using furniro_server.Models.DTOs;
    using furniro_server.Models.Entities;

    public interface ICategoryRepository
    {
        Task<ServiceResponse<IEnumerable<Category>>> GetAllCategories(int skip, int take);
        Task<ServiceResponse<Category>> GetCategoryById(int id);
        Task<ServiceResponse<Category>> AddCategory(AddCategoryDto categoryDTO);
        Task<ServiceResponse<Category>> UpdateCategory(int id, AddCategoryDto categoryDTO);
        Task<bool> DeleteCategory(int id);
    }
}