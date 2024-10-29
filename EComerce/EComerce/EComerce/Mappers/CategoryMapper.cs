using EComerce.Dtos.Categories;
using EComerce.Models;

namespace EComerce.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
                ImageUrl = category.ImageUrl,
            };
        }
        public static Category ToCategoryFromUpdateDTO(this UpdateProductDto categoryDto)
        {
            return new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                ImageUrl = categoryDto.ImageUrl,
            };
        }

        public static Category ToCategoryFromCreateDTO(this CreateCategoryDto categoryDto)
        {
            return new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                ImageUrl = categoryDto.ImageUrl,
            };
        }
    }
}
