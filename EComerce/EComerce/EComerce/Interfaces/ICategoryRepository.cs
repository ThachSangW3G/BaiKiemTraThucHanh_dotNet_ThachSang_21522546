using EComerce.Models;

namespace EComerce.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int Id);
        Task<Category> CreateAsync(Category category);
        Task<Category?> UpdateAsync(int Id, Category category);
        Task<Category?> DeleteAsync(int Id);
    }
}
