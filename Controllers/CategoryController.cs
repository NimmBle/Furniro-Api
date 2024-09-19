namespace furniro_server.Controllers
{
    using furniro_server.DTOs.CategoryDTOs;
    using furniro_server.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _cRepo;

        public CategoryController(ICategoryRepository cRepo)
        {
            _cRepo = cRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories(int skip, int take) 
        {
            var response = await _cRepo.GetAllCategories(skip, take);

            if (response.Success == false) return NotFound(response);

            return Ok(response);
        }

        [HttpGet]
        [Route("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(Guid id) 
        {
            var response = await _cRepo.GetCategoryById(id);

            if (response.Success == false) return NotFound(response);

            return Ok(response);
        }

        [HttpGet]
        [Route("{categoryName}")]
        public async Task<IActionResult> GetCategoryByName(string CategoryName) 
        {
            var response = await _cRepo.GetCategoryByName(CategoryName);
            
            if (response.Success == false) return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDTO addCategory) 
        {
            var response = await _cRepo.AddCategory(addCategory);

            if (response.Success == false) return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        [Route("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(Guid id, AddCategoryDTO updateCategory)
        {
            var response = await _cRepo.UpdateCategory(id, updateCategory);

            if (response.Success == false) return NotFound(response);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(Guid id) 
        {
            var response = await _cRepo.DeleteCategory(id);

            if (response.Success == false) return NotFound(response);

            return Ok(response);
        }
    }
}