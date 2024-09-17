namespace furniro_server.Controllers
{
    using System.Security.Claims;
    using furniro_server.Interfaces.Repositories;
    using furniro_server.Models;
    using furniro_server.Models.DTOs;
    using furniro_server.Models.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class CategoryController : BaseApiController
    {
        
        protected readonly ICategoryRepository _categoryRepository;
        public ClaimsPrincipal User { get; }

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }   

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories(int skip, int take) 
        {
            int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _categoryRepository.GetAllCategories(id, skip, take));
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
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> UpdateCategory(int id, AddCategoryDto categoryDTO) 
        {
            ServiceResponse<GetCategoryDto> serviceResponse = await _categoryRepository.UpdateCategory(id, categoryDTO); 
            if (serviceResponse.Data == null) return NotFound(serviceResponse);
            else return Ok(serviceResponse);
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