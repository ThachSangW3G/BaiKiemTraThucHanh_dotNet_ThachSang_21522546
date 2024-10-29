using EComerce.Datas;
using EComerce.Interfaces;
using EComerce.Models;
using Microsoft.EntityFrameworkCore;

namespace EComerce.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public ProductRepository(ApplicationDBContext dbContext)
        {
            _dBContext = dbContext;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            await _dBContext.Products.AddAsync(product);
            await _dBContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteAsync(int Id)
        {
            var product = await _dBContext.Products.FirstOrDefaultAsync(c => c.ProductId == Id);
            if (product == null)
            {
                return null;
            }

            _dBContext.Products.Remove(product);
            await _dBContext.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dBContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int Id)
        {
            return await _dBContext.Products.FirstOrDefaultAsync(c => c.ProductId == Id);
        }

        public async Task<Product?> UpdateAsync(int Id, Product product)
        {
            var existingProduct = await _dBContext.Products.FindAsync(Id);
            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.ImageUrl = product.ImageUrl;

            await _dBContext.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<List<Product>> GetByCategoryIdAsync(int categoryId)
        {
            return await _dBContext.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }
    }
}
