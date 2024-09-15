namespace furniro_server.Repositories
{
    using AutoMapper;
    using furniro_server.Data;
    using furniro_server.Interfaces.Repositories;
    using furniro_server.Models;
    using furniro_server.Models.DTOs;
    using furniro_server.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class CategoryRepository : ICategoryRepository
    {

        private readonly FurniroContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(FurniroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<ServiceResponse<IEnumerable<GetCategoryDto>>> GetAllCategories(int skip, int take)
        {
        
            ServiceResponse<IEnumerable<GetCategoryDto>> serviceResponse = new();
            serviceResponse.Data =  
                await _context.Categories
                .OrderBy(c => c.Id)
                .Skip(skip)
                .Take(take)
                .Select(c => _mapper.Map<GetCategoryDto>(c)).ToListAsync();
              
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCategoryDto>> GetCategoryById(int id)
        {
            ServiceResponse<GetCategoryDto> ServiceResponse = new();

            ServiceResponse.Data = _mapper.Map<GetCategoryDto>(
                await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id)
            );
            
            return ServiceResponse; 
        }

        public async Task<ServiceResponse<GetCategoryDto>> AddCategory(AddCategoryDto addCategory)
        {

            ServiceResponse<GetCategoryDto> ServiceResponse = new();

            await _context.Categories.AddAsync(_mapper.Map<Category>(addCategory));
            await _context.SaveChangesAsync();
            ServiceResponse.Data = _mapper.Map<GetCategoryDto>(addCategory);
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

        public async Task<ServiceResponse<GetCategoryDto>> UpdateCategory(int id, AddCategoryDto addCategory)
        {
            ServiceResponse<GetCategoryDto> ServiceResponse = new();
            var category = await _context.Categories.FindAsync(id);

            if (category is null) {
                ServiceResponse.Success = false;
                return ServiceResponse;
            } 

            category = _mapper.Map<Category>(addCategory);

            await _context.SaveChangesAsync();
            ServiceResponse.Data = _mapper.Map<GetCategoryDto>(addCategory);
            return ServiceResponse;
        }
    }
}