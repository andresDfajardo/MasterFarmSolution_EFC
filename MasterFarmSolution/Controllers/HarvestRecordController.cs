using MasterFarmSolution.Entities;
using MasterFarmSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterFarmSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarvestRecordController : ControllerBase
    {
        private readonly IHarvestRecordService _harvestRecordService;
        public HarvestRecordController(IHarvestRecordService harvestRecordService)
        {
            _harvestRecordService = harvestRecordService;
        }
        [HttpGet]
        public async Task<ActionResult<List<HarvestRecord>>> GetAllHarvestRecord()
        {
            return Ok(await _harvestRecordService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<HarvestRecord>> GetHarvestRecord(int id)
        {
            var harvestRecord = await _harvestRecordService.GetHarvestRecord(id);
            if (harvestRecord == null)
            {
                return BadRequest("Harvest Record not found");
            }
            return Ok(harvestRecord);
        }
        [HttpPost("{operationId}/{productId}/{quantity}")]
        public async Task<ActionResult<HarvestRecord>> CreateHarvestRecord(int operationId, int productId, int quantity)
        {
            var newHarvestRecord = await _harvestRecordService.CreateHarvestRecord(operationId, productId, quantity);
            return CreatedAtAction(nameof(GetHarvestRecord), new { newHarvestRecord.id }, newHarvestRecord);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<HarvestRecord>> UpdateHarvestRecord(int id, int? operationId = null, int? productId = null, int? quantity = null)
        {
            try
            {
                return Ok(await _harvestRecordService.UpdateHarvestRecord(id, operationId, productId, quantity));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<HarvestRecord>> DeleteHarvestRecord(int id)
        {
            var harvestRecord = await _harvestRecordService.DeleteHarvestRecord(id);
            if (harvestRecord == null)
            {
                return NotFound();
            }
            return Ok(harvestRecord);
        }
    }
}
