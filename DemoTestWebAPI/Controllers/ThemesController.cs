using DemoTestWebAPI.Services.ThemesService;
using Microsoft.AspNetCore.Mvc;

namespace DemoTestWebAPI.Controllers
{
    [Route("api/category/{category.id}/[controller]")]
    [ApiController]
    public class ThemesController : ControllerBase
    {
        private readonly IThemesService _themesService;

        public ThemesController(IThemesService themesService)
        {
            _themesService = themesService;
        }

        [HttpGet]
        public async Task<IEnumerable<Themes>> GetAllThemes(int categoryId)
        {
           return await _themesService.GetAllThemes(categoryId);
        }

        [HttpGet("{themeNumber}")]
        public async Task<ActionResult<Themes>> GetTheme(int categoryId, int themeNumber)
        {
            var result = await _themesService.GetThemeByThemeNumber(categoryId, themeNumber);
            if (result is null)
                return NotFound("Theme not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTheme(int categoryId, [FromBody] Themes newTheme)
        {
            await _themesService.CreateTheme(categoryId, newTheme);
            return Ok();
        }

        [HttpPut("{themeNumber}")]
        public async Task<ActionResult<Category>> UpdateCategory(int categoryId, int themeNumber, [FromBody] Themes updatedTheme)
        {
            await _themesService.UpdateTheme(categoryId, themeNumber, updatedTheme);
            return Ok();
        }

        [HttpDelete("{themeNumber}")]
        public async Task<ActionResult<Category>> DeleteCategory(int categoryId, int themeNumber)
        {
            await _themesService.DeleteTheme(categoryId, themeNumber);
            return Ok();
        }
    }
}
