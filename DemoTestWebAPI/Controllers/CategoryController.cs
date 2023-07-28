using DemoTestWebAPI.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace DemoTestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllCategories()
        {  
            return await _categoryService.GetAllCategories();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var result = await _categoryService.GetCategoryById(id);
            if (result is null)
                return NotFound("Category not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateParent([FromBody] Category category)
        {
            await _categoryService.CreateCategory(category);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(int id, [FromBody] Category updatedCategory)
        {
            await _categoryService.UpdateCategory(id, updatedCategory);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}
