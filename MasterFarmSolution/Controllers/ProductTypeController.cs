using MasterFarmSolution.Entities;
using MasterFarmSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterFarmSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;
        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductType>>> GetAllProductType()
        {
            return Ok(await _productTypeService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> GetProductType(int id)
        {
            var productType = await _productTypeService.GetProductType(id);
            if (productType == null)
            {
                return BadRequest("Product Type not found");
            }
            return Ok(productType);
        }
        [HttpPost("{productType}")]
        public async Task<ActionResult<ProductType>> CreateProductType(string productType)
        {
            var newProductType = await _productTypeService.CreateProductType(productType);
            return CreatedAtAction(nameof(GetProductType), new { newProductType.id }, newProductType);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductType>> UpdateProductType(int id, string? productType = null)
        {
            try
            {
                return Ok(await _productTypeService.UpdateProductType(id, productType));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductType>> DeleteProductType(int id)
        {
            var productType = await _productTypeService.DeleteProductType(id);
            if (productType == null)
            {
                return NotFound();
            }
            return Ok(productType);
        }
    }
}
