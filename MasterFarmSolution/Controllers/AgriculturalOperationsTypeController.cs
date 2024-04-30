using MasterFarmSolution.Entities;
using MasterFarmSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterFarmSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgriculturalOperationsTypeController : ControllerBase
    {
        private readonly IAgriculturalOperationsTypeService _agriculturalOperationsTypeService;
        public AgriculturalOperationsTypeController(IAgriculturalOperationsTypeService agriculturalOperationsTypeService)
        {
            _agriculturalOperationsTypeService = agriculturalOperationsTypeService;
        }
        [HttpGet]
        public async Task<ActionResult<List<AgriculturalOperationsType>>> GetAllAgriculturalOperationsType()
        {
            return Ok(await _agriculturalOperationsTypeService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AgriculturalOperationsType>> GetAgriculturalOperationsType(int id)
        {
            var agriculturalOperationsType = await _agriculturalOperationsTypeService.GetAgriculturalOperationsType(id);
            if (agriculturalOperationsType == null)
            {
                return BadRequest("Agricultural Operations Type not found");
            }
            return Ok(agriculturalOperationsType);
        }
        [HttpPost("{type}")]
        public async Task<ActionResult<AgriculturalOperationsType>> CreateAgriculturalOperationsType(string type)
        {
            var newAgriculturalOperationsType = await _agriculturalOperationsTypeService.CreateAgriculturalOperationsType(type);
            return CreatedAtAction(nameof(GetAgriculturalOperationsType), new { newAgriculturalOperationsType.id }, newAgriculturalOperationsType);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<AgriculturalOperationsType>> UpdateAgriculturalOperationsType(int id, string? type = null)
        {
            try
            {
                return Ok(await _agriculturalOperationsTypeService.UpdateAgriculturalOperationsType(id, type));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<AgriculturalOperationsType>> DeleteAgriculturalOperationsType(int id)
        {
            var agriculturalOperationsType = await _agriculturalOperationsTypeService.DeleteAgriculturalOperationsType(id);
            if (agriculturalOperationsType == null)
            {
                return NotFound();
            }
            return Ok(agriculturalOperationsType);
        }
    }
}
