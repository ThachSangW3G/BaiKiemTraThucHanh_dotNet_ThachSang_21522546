using EComerce.Datas;
using EComerce.Dtos.Categories;
using EComerce.Interfaces;
using EComerce.Mappers;
using EComerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace EComerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var communities = await _categoryRepository.GetAllAsync();

            var communityDto = communities.Select(c => c.ToCategoryDto());

            return Ok(communityDto);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Category>> GetCategory([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _categoryRepository.GetByIdAsync(Id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category.ToCategoryDto());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = categoryDto.ToCategoryFromCreateDTO();

            await _categoryRepository.CreateAsync(category);

            return Ok();


        }


        [HttpPut]
        [Route("{Id:int}")]
        public async Task<ActionResult> Update([FromRoute] int Id, [FromForm] UpdateProductDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoryRepository.UpdateAsync(Id, categoryDto.ToCategoryFromUpdateDTO());

            if (category == null)
            {
                return NotFound("Community not found");

            }

            return Ok(category.ToCategoryDto());
        }



        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int Id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoty = await _categoryRepository.DeleteAsync(Id);

            if (categoty == null)
            {
                return NotFound("Category does not exist");
            }

            return Ok(categoty);
        }


    }
}
