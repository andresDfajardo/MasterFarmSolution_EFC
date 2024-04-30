using MasterFarmSolution.Entities;
using MasterFarmSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterFarmSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlotController : ControllerBase
    {
        private readonly IPlotService _plotService;
        public PlotController(IPlotService plotService)
        {
            _plotService = plotService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Plot>>> GetAllPlot()
        {
            return Ok(await _plotService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Plot>> GetPlot(int id)
        {
            var plot = await _plotService.GetPlot(id);
            if (plot == null)
            {
                return BadRequest("Plot not found");
            }
            return Ok(plot);
        }
        [HttpPost("{number}/{farmId}/{plotTypeId}")]
        public async Task<ActionResult<Plot>> CreatePlot(string number, int farmId, int plotTypeId)
        {
            var newPlot = await _plotService.CreatePlot(number, farmId, plotTypeId);
            return CreatedAtAction(nameof(GetPlot), new { newPlot.id }, newPlot);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Plot>> UpdatePlot(int id, string? number = null, int? farmId = null, int? plotTypeId = null)
        {
            try
            {
                return Ok(await _plotService.UpdatePlot(id, number, farmId, plotTypeId));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Plot>> DeletePlot(int id)
        {
            var plot = await _plotService.DeletePlot(id);
            if (plot == null)
            {
                return NotFound();
            }
            return Ok(plot);
        }
    }
}
