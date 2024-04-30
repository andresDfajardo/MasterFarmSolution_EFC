using MasterFarmSolution.Entities;
using MasterFarmSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterFarmSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlotTypeController : ControllerBase
    {
        private readonly IPlotTypeService _plotTypeService;
        public PlotTypeController(IPlotTypeService plotTypeService)
        {
            _plotTypeService = plotTypeService;
        }
        [HttpGet]
        public async Task<ActionResult<List<PlotType>>> GetAllPlotType()
        {
            return Ok(await _plotTypeService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PlotType>> GetPlotType(int id)
        {
            var plotType = await _plotTypeService.GetPlotType(id);
            if (plotType == null)
            {
                return BadRequest("Plot Type not found");
            }
            return Ok(plotType);
        }
        [HttpPost("{number}/{farmId}/{plotTypeId}")]
        public async Task<ActionResult<PlotType>> CreatePlotType(string plotType)
        {
            var newPlotType = await _plotTypeService.CreatePlotType(plotType);
            return CreatedAtAction(nameof(GetPlotType), new { newPlotType.id }, newPlotType);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<PlotType>> UpdatePlotType(int id, string? plotType = null)
        {
            try
            {
                return Ok(await _plotTypeService.UpdatePlotType(id, plotType));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlotType>> DeletePlotType(int id)
        {
            var plotType = await _plotTypeService.DeletePlotType(id);
            if (plotType == null)
            {
                return NotFound();
            }
            return Ok(plotType);
        }
    }
}
