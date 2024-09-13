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
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories(int skip, int take) {
           return await _categoryRepository.GetAll(skip, take);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetOneCategories(int id) {
           var category = await _categoryRepository.GetOne(id);

           if (category is null ) return NotFound();
           else return Ok(category);
           
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CategoryCreateDTO categoryDTO) {
            return await _categoryRepository.Create(categoryDTO);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Category?>> UpdateCategory(int id, CategoryCreateDTO categoryDTO) {
           return await _categoryRepository.Update(id, categoryDTO); 
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<bool> DeleteCategory(int id) {
            return await _categoryRepository.Delete(id);
        }
    }
}