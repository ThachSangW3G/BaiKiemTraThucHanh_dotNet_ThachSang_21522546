using EComerce.Models;

namespace EComerce.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int Id);
        Task<Product> CreateAsync(Product product);
        Task<Product?> UpdateAsync(int Id, Product product);
        Task<Product?> DeleteAsync(int Id);
        Task<List<Product>> GetByCategoryIdAsync(int categoryId);
    }
}
