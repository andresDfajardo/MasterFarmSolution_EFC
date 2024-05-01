using MasterFarmSolution.Entities;
using MasterFarmSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterFarmSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationXGameController : ControllerBase
    {
        private readonly IOperationXGameService _operationXGameService;
        public OperationXGameController(IOperationXGameService operationXGameService)
        {
            _operationXGameService = operationXGameService;
        }
        [HttpGet]
        public async Task<ActionResult<List<OperationXGame>>> GetAllOperationXGame()
        {
            return Ok(await _operationXGameService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationXGame>> GetOperationXGame(int id)
        {
            var operationXGame = await _operationXGameService.GetOperationXGame(id);
            if (operationXGame == null)
            {
                return BadRequest("Operation X Game not found");
            }
            return Ok(operationXGame);
        }
        [HttpPost("{agriculturalOperationId}/{gameId}/{dateTimeOperationXGame}")]
        public async Task<ActionResult<OperationXGame>> CreateOperationXGame(int agriculturalOperationId, int gameId, DateTime dateTimeOperationXGame)
        {
            var newOperationXGame = await _operationXGameService.CreateOperationXGame(agriculturalOperationId, gameId, dateTimeOperationXGame);
            return CreatedAtAction(nameof(GetOperationXGame), new { newOperationXGame.id }, newOperationXGame);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<OperationXGame>> UpdateOperationXGame(int id, int? agriculturalOperationId = null, int? gameId = null, DateTime? dateTimeOperationXGame = null)
        {
            try
            {
                return Ok(await _operationXGameService.UpdateOperationXGame(id, agriculturalOperationId, gameId, dateTimeOperationXGame));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationXGame>> DeleteOperationXGame(int id)
        {
            var operationXGame = await _operationXGameService.DeleteOperationXGame(id);
            if (operationXGame == null)
            {
                return NotFound();
            }
            return Ok(operationXGame);
        }
    }
}
