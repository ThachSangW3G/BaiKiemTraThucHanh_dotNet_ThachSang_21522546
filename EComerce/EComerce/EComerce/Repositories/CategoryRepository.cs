using EComerce.Datas;
using EComerce.Interfaces;
using EComerce.Models;
using Microsoft.EntityFrameworkCore;

namespace EComerce.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public CategoryRepository(ApplicationDBContext dbContext)
        {
            _dBContext = dbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await _dBContext.Categories.AddAsync(category);
            await _dBContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteAsync(int Id)
        {
            var category = await _dBContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == Id);
            if (category == null)
            {
                return null;
            }

            _dBContext.Categories.Remove(category);
            await _dBContext.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _dBContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int Id)
        {
            return await _dBContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == Id);
        }

        public async Task<Category?> UpdateAsync(int Id, Category category)
        {
            var existingCategory = await _dBContext.Categories.FindAsync(Id);
            if (existingCategory == null)
            {
                return null;
            }
            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            existingCategory.ImageUrl = category.ImageUrl;

            await _dBContext.SaveChangesAsync();
            return existingCategory;
        }
    }
}
