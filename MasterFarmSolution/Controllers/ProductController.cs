using MasterFarmSolution.Entities;
using MasterFarmSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterFarmSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProduct()
        {
            return Ok(await _productService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
            {
                return BadRequest("Product not found");
            }
            return Ok(product);
        }
        [HttpPost("{productTypeId}/{name}")]
        public async Task<ActionResult<Product>> CreateProduct(int productTypeId, string name)
        {
            var newProduct = await _productService.CreateProduct(productTypeId, name);
            return CreatedAtAction(nameof(GetProduct), new { newProduct.id }, newProduct);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, int? productTypeId = null, string? name = null)
        {
            try
            {
                return Ok(await _productService.UpdateProduct(id, productTypeId, name));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _productService.DeleteProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
