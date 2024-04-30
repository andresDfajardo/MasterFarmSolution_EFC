using MasterFarmSolution.Entities;
using MasterFarmSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterFarmSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CropController : ControllerBase
    {
        private readonly ICropService _cropService;
        public CropController(ICropService cropService)
        {
            _cropService = cropService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Crop>>> GetAllCrop()
        {
            return Ok(await _cropService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Crop>> GetCrop(int id)
        {
            var crop = await _cropService.GetCrop(id);
            if (crop == null)
            {
                return BadRequest("Crop not found");
            }
            return Ok(crop);
        }
        [HttpPost("{name}/{description}/{harvestDays}/{plotId}")]
        public async Task<ActionResult<Crop>> CreateCrop(string name, string description, string harvestDays, int plotId)
        {
            var newCrop = await _cropService.CreateCrop(name, description, harvestDays, plotId);
            return CreatedAtAction(nameof(GetCrop), new { newCrop.id }, newCrop);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Crop>> UpdateCrop(int id, string? name = null, string? description = null, string? harvestDays = null, int? plotId = null)
        {
            try
            {
                return Ok(await _cropService.UpdateCrop(id, name, description, harvestDays, plotId));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Crop>> DeleteCrop(int id)
        {
            var crop = await _cropService.DeleteCrop(id);
            if (crop == null)
            {
                return NotFound();
            }
            return Ok(crop);
        }
    }
}
