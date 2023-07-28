using DemoTestWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoTestWebAPI.Services.ThemesService
{
    public class ThemesService : IThemesService
    {
        private readonly DataContext _context;

        public ThemesService(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Themes>> GetAllThemes(int categoryId)
        {
            return await _context.Themes.Where(t => t.Category == categoryId).ToListAsync();
        }

        public async Task<Themes> GetThemeByThemeNumber(int categoryId, int themeNumber)
        {
            return await _context.Themes.FirstOrDefaultAsync(t => t.Category == categoryId && t.ThemeNumber == themeNumber);
        }

        public async Task CreateTheme(int categoryId, Themes themes)
        {
            themes.Category = categoryId;
            _context.Themes.Add(themes);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTheme(int categoryId, int themeNumber, Themes updatedTheme)
        {
            var theme = await _context.Themes.FirstOrDefaultAsync(t => t.Category == categoryId && t.ThemeNumber == themeNumber);
            if (theme is null)
                throw new Exception("Theme is not found.");

            theme.ThemeNumber = updatedTheme.ThemeNumber;
            theme.Name = updatedTheme.Name;
            theme.Description = updatedTheme.Description;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTheme(int categoryId, int themeNumber)
        {
            var theme = await _context.Themes.FirstOrDefaultAsync(t => t.Category == categoryId && t.ThemeNumber == themeNumber);
            if (theme is null)
                throw new Exception("Theme is not found.");

            _context.Themes.Remove(theme);
            await _context.SaveChangesAsync();
        }
    }
}
