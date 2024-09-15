namespace furniro_server.Controllers
{
    using furniro_server.Interfaces.Repositories;
    using furniro_server.Models;
    using furniro_server.Models.DTOs;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseApiController
    {
        
        protected readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }   

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories(int skip, int take) 
        {
           return Ok(await _categoryRepository.GetAllCategories(skip, take));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetOneCategories(int id) 
        {

           var category = await _categoryRepository.GetCategoryById(id);

           if (category is null ) return NotFound();
           else return Ok(category);
           
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(AddCategoryDto categoryDTO) 
        {
            return Ok(await _categoryRepository.AddCategory(categoryDTO));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Category?>> UpdateCategory(int id, AddCategoryDto categoryDTO) 
        {
            return Ok(await _categoryRepository.UpdateCategory(id, categoryDTO)); 
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id) 
        {
            await _categoryRepository.DeleteCategory(id);
            return NoContent();
        }
    }
}