namespace furniro_server.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using furniro_server.Data;
    using furniro_server.DTOs.CategoryDTOs;
    using furniro_server.Entities;
    using furniro_server.Entities.Common;
    using furniro_server.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<GetCategoryDTO>>> GetAllCategories(int skip, int take)
        {
            ServiceResponse<IEnumerable<GetCategoryDTO>> sResponse = new();

            sResponse.Data = await _context.Categories
                .Select(c => _mapper.Map<GetCategoryDTO>(c))
                .Take(take)
                .ToListAsync();
            return sResponse;
        }

        public async Task<ServiceResponse<GetCategoryDTO>> GetCategoryById(Guid id)
        {
            Category category = new();
            ServiceResponse<GetCategoryDTO> sResponse = new();

            try 
            {
                category = await _context.Categories
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            sResponse.Data = _mapper.Map<GetCategoryDTO>(category);
            return sResponse;
                
        }

        public async Task<ServiceResponse<GetCategoryDTO>> GetCategoryByName(string CategoryName) 
        {
            Category category = new();
            ServiceResponse<GetCategoryDTO> sResponse = new();

            try
            {
                category = await _context.Categories
                .Where(c => c.Name == CategoryName)
                .FirstOrDefaultAsync();
                sResponse.Data = _mapper.Map<GetCategoryDTO>(category); 
            }
            catch (Exception ex)
            {
                sResponse.Success = false;
                sResponse.Message = ex.Message;
            }

            return sResponse; 
        }

        public async Task<ServiceResponse<GetCategoryDTO>> AddCategory(AddCategoryDTO addCategory)
        {
            ServiceResponse<GetCategoryDTO> sResponse = new();
            Category category = _mapper.Map<Category>(addCategory);

            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                sResponse.Message = "Category was added successfully";
            }
            catch (Exception ex)
            {
                sResponse.Success = false;
                sResponse.Message = ex.Message;
            }
            return sResponse;
        }
              
        public async Task<ServiceResponse<GetCategoryDTO>> UpdateCategory(Guid id, AddCategoryDTO updateCategory)
        {
            ServiceResponse<GetCategoryDTO> sResponse = new();
            Category category = new();

            try
            {
                category = await _context.Categories
                    .Where(c => c.Id == id)
                    .FirstOrDefaultAsync();
                category = _mapper.Map<Category>(updateCategory);
                await _context.SaveChangesAsync();
                sResponse.Data = _mapper.Map<GetCategoryDTO>(category);
                sResponse.Message = "Category was updated successfully";

            }
            catch (Exception ex)
            {
                sResponse.Success = false;
                sResponse.Message = ex.Message;
            }
            return sResponse;

        }

        public async Task<ServiceResponse<GetCategoryDTO>> DeleteCategory(Guid id)
        {
            ServiceResponse<GetCategoryDTO> sResponse = new();
            try
            {
                await _context.Categories
                    .Where(c => c.Id == id)
                    .ExecuteDeleteAsync();
                sResponse.Message = "Category was deleted succesfully";
            }
            catch (Exception ex)
            {
                sResponse.Success = false;
                sResponse.Message = ex.Message;
            }
            return sResponse;
        }

    }
}