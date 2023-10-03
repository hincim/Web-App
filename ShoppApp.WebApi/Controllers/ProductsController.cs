using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.Entity;
using ShopApp.WebUI.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // local/api/Products
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAll();

            var productsDto = new List<ProductDTO>();

            foreach (var product in products)
            {
                productsDto.Add(ProductToDTO(product));
            }

            return Ok(productsDto); // 200
        }
        // local/api/Products/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound(); // 404
            }
            return Ok(ProductToDTO(product));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product entity)
        {
            await _productService.CreateAsync(entity);
            return CreatedAtAction(nameof(GetProduct),new {id = entity.ProductId}, ProductToDTO(entity));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product entity)
        {
            if (id != entity.ProductId)
            {
                return BadRequest();
            }
            var product = await _productService.GetById(entity.ProductId);

            if (product == null)
            {
                return NotFound();
            }

            await _productService.UpdateAsync(product,entity);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productService.DeleteAsync(product);
            return NoContent();
        }
        private static ProductDTO ProductToDTO(Product product)
        {
            return new ProductDTO()
            {
                Url = product.Url,
                ProductId = product.ProductId,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Name = product.Name
            };
        }
    }
}
