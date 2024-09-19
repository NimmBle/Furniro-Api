namespace furniro_server.Interfaces
{
    using furniro_server.DTOs.CategoryDTOs;
    using furniro_server.Entities.Common;

    public interface ICategoryRepository
    {
        Task<ServiceResponse<IEnumerable<GetCategoryDTO>>> GetAllCategories(int skip, int take);
        Task<ServiceResponse<GetCategoryDTO>> GetCategoryById(Guid id);
        Task<ServiceResponse<GetCategoryDTO>> GetCategoryByName(string CategoryName);
        Task<ServiceResponse<GetCategoryDTO>> AddCategory(AddCategoryDTO addCategory);
        Task<ServiceResponse<GetCategoryDTO>> UpdateCategory(Guid id, AddCategoryDTO updateCategory);
        Task<ServiceResponse<GetCategoryDTO>> DeleteCategory(Guid id);
    }
}