using MasterFarmSolution.Entities;
using MasterFarmSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterFarmSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly IFarmService _farmService;
        public FarmController(IFarmService farmService)
        {
            _farmService = farmService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Farm>>> GetAllFarm()
        {
            return Ok(await _farmService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Farm>> GetFarm(int id)
        {
            var farm = await _farmService.GetFarm(id);
            if (farm == null)
            {
                return BadRequest("Farm not found");
            }
            return Ok(farm);
        }
        [HttpPost("{farmName}/{farmerId}")]
        public async Task<ActionResult<Farm>> CreateFarm(string farmName, int farmerId)
        {
            var newFarm = await _farmService.CreateFarm(farmName, farmerId);
            return CreatedAtAction(nameof(GetFarm), new { newFarm.id }, newFarm);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Farm>> UpdateFarm(int id, string? farmName = null, int? farmerId = null)
        {
            try
            {
                return Ok(await _farmService.UpdateFarm(id, farmName, farmerId));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Farm>> DeleteFarm(int id)
        {
            var farm = await _farmService.DeleteFarm(id);
            if (farm == null)
            {
                return NotFound();
            }
            return Ok(farm);
        }
    }
}
