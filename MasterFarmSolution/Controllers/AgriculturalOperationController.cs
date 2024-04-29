using MasterFarmSolution.Entities;
using MasterFarmSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MasterFarmSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgriculturalOperationController : ControllerBase
    {
        private readonly IAgriculturalOperationService _agriculturalOperationService;
        public AgriculturalOperationController(IAgriculturalOperationService agriculturalOperationService)
        {
            _agriculturalOperationService = agriculturalOperationService;
        }
        [HttpGet]
        public async Task<ActionResult<List<AgriculturalOperation>>> GetAllAgriculturalOperations()
        {
            return Ok(await _agriculturalOperationService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AgriculturalOperation>> GetAgriculturalOperation(int id)
        {
            var AgriculturalOperation = await _agriculturalOperationService.GetAgriculturalOperation(id);
            if (AgriculturalOperation == null)
            {
                return BadRequest("Agricultural Operation not found");
            }
            return Ok(AgriculturalOperation);
        }
        [HttpPost("{cropId}/{dateOperation}/{operationTypeId}/{description}")]
        public async Task<ActionResult<AgriculturalOperation>> CreateAgriculturalOperation(int cropId, string dateOperation, int operationTypeId, string description)
        {
            var newAgriculturalOperation = await _agriculturalOperationService.CreateAgriculturalOperation(cropId, dateOperation, operationTypeId, description);
            return CreatedAtAction(nameof(GetAgriculturalOperation), new { newAgriculturalOperation.id }, newAgriculturalOperation);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<AgriculturalOperation>> UpdateAgriculturalOperation(int id, int? cropId = null, string? dateOperation = null, int? operationTypeId = null, string? description = null)
        {
            try
            {
                return Ok(await _agriculturalOperationService.UpdateAgriculturalOperation(id, cropId, dateOperation, operationTypeId, description));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<AgriculturalOperation>> DeleteAgriculturalOperation(int id)
        {
            var agriculturalOperation = await _agriculturalOperationService.DeleteAgriculturalOperation(id);
            if (agriculturalOperation == null)
            {
                return NotFound();
            }
            return Ok(agriculturalOperation);
        }
    }
}
