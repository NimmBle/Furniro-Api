namespace furniro_server.Repositories
{
    using furniro_server.Data;
    using furniro_server.Interfaces.Repositories;
    using furniro_server.Models;
    using furniro_server.Models.DTOs;
    using furniro_server.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class CategoryRepository : ICategoryRepository
    {

        private readonly FurniroContext _context;

        public CategoryRepository(FurniroContext context)
        {
            _context = context;
        }
        
        public async Task<ServiceResponse<IEnumerable<Category>>> GetAllCategories(int skip, int take)
        {
            ServiceResponse<IEnumerable<Category>> ServiceResponse = new();

            ServiceResponse.Data = await _context.Categories
                .OrderBy(c => c.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<Category>> GetCategoryById(int id)
        {
            ServiceResponse<Category> ServiceResponse = new();

            ServiceResponse.Data = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);
            return ServiceResponse; 
        }

        public async Task<ServiceResponse<Category>> AddCategory(AddCategoryDto categoryDTO)
        {
            var category = new Category {
                Name = categoryDTO.Name,
                CoverPhoto = categoryDTO.CoverPhoto
            };
            ServiceResponse<Category> ServiceResponse = new ServiceResponse<Category>();

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            ServiceResponse.Data = category;
            return ServiceResponse;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            try
            {       
                await _context
                    .Categories
                    .Where(c => c.Id.Equals(id))
                    .ExecuteDeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;   
            }             
        }

        public async Task<ServiceResponse<Category>> UpdateCategory(int id, AddCategoryDto categoryDTO)
        {
            ServiceResponse<Category> ServiceResponse = new();
            var category = await _context.Categories.FindAsync(id);

            if (category is null) {
                ServiceResponse.Success = false;
                return ServiceResponse;
            } 

            category.Name = categoryDTO.Name;
            category.CoverPhoto = categoryDTO.CoverPhoto;

            await _context.SaveChangesAsync();
            ServiceResponse.Data = category;
            return ServiceResponse;
        }
    }
}