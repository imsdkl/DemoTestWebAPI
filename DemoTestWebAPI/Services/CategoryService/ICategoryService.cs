namespace DemoTestWebAPI.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category?> GetCategoryById(int id);       
        Task CreateCategory(Category category);
        Task UpdateCategory(int id, Category updatedCategory);
        Task DeleteCategory(int id);
    }
}
