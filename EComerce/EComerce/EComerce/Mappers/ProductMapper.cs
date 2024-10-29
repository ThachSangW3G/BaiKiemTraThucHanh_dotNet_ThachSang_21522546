using EComerce.Dtos.Products;
using EComerce.Models;

namespace EComerce.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto
            {
                ProductId = product.ProductId,
                Price = product.Price,
                Name = product.Name,
                Description = product.Description,
                StockQuantity = product.StockQuantity,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
            };
        }
        public static Product ToProductFromUpdateDTO(this UpdateProductDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                ImageUrl = productDto.ImageUrl,
                Price = productDto.Price,
                StockQuantity= productDto.StockQuantity,
                CategoryId  = productDto.CategoryId,
            };
        }

        public static Product ToProductFromCreateDTO(this CreateProductDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                ImageUrl = productDto.ImageUrl,
                Price = productDto.Price,
                StockQuantity= productDto.StockQuantity,
                CategoryId  = productDto.CategoryId,
            };
        }
    }
}
