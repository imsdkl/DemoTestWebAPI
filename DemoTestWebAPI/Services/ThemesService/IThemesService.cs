namespace DemoTestWebAPI.Services.ThemesService
{
    public interface IThemesService
    {
        Task<IEnumerable<Themes>> GetAllThemes(int categoryId);
        Task<Themes> GetThemeByThemeNumber(int categoryId, int themeNumber);
        Task CreateTheme(int categoryId, Themes themes);
        Task UpdateTheme(int categoryId, int themeNumber, Themes updatedTheme);
        Task DeleteTheme(int categoryId, int themeNumber);
    }
}
