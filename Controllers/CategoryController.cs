namespace furniro_server.Controllers
{
    using furniro_server.Data;
    using furniro_server.Models;
    using furniro_server.Models.DTOs;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseApiController
    {
        
        protected readonly FurniroContext _context;

        public CategoryController(FurniroContext context)
        {
            _context = context;
        }   

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories() {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id) {
            return await _context.Categories.FindAsync(id);
        }
    
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CategoryCreateDTO categoryDto) {
            var category = new Category {
                Name = categoryDto.Name,
                CoverPhoto = categoryDto.CoverPhoto
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }
    }
}