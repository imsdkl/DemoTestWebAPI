using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DemoTestWebAPI.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;
        
        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(int id, Category updatedCategory)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
                throw new Exception("Category is not found.");

            category.Name = updatedCategory.Name;

            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
                throw new Exception("Category is not found.");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
