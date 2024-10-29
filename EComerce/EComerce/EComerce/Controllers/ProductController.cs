using EComerce.Datas;
using EComerce.Dtos.Products;
using EComerce.Interfaces;
using EComerce.Mappers;
using EComerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace EComerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var products = await _productRepository.GetAllAsync();

            var producstDto = products.Select(c => c.ToProductDto());

            return Ok(producstDto);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Category>> GetProduct([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _productRepository.GetByIdAsync(Id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.ToProductDto());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = productDto.ToProductFromCreateDTO();

            await _productRepository.CreateAsync(product);

            return Ok();


        }


        [HttpPut]
        [Route("{Id:int}")]
        public async Task<ActionResult> Update([FromRoute] int Id, [FromForm] UpdateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productRepository.UpdateAsync(Id, productDto.ToProductFromUpdateDTO());

            if (product == null)
            {
                return NotFound("Community not found");

            }

            return Ok(product.ToProductDto());
        }



        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int Id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _productRepository.DeleteAsync(Id);

            if (product == null)
            {
                return NotFound("Category does not exist");
            }

            return Ok(product);
        }


        [HttpGet("category/{categoryId:int}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByCategoryId([FromRoute] int categoryId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var products = await _productRepository.GetByCategoryIdAsync(categoryId);

            if (products == null)
            {
                return NotFound("No products found for the specified category.");
            }

            var productsDto = products.Select(p => p.ToProductDto());

            return Ok(productsDto);
        }


    }
}
