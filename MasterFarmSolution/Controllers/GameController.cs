using MasterFarmSolution.Entities;
using MasterFarmSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterFarmSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetAllGame()
        {
            return Ok(await _gameService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _gameService.GetGame(id);
            if (game == null)
            {
                return BadRequest("Game not found");
            }
            return Ok(game);
        }
        [HttpPost("{dateLastConnection}")]
        public async Task<ActionResult<Game>> CreateGame(string dateLastConnection)
        {
            var newGame = await _gameService.CreateGame(dateLastConnection);
            return CreatedAtAction(nameof(GetGame), new { newGame.id }, newGame);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Game>> UpdateGame(int id, string? dateLastConnection = null)
        {
            try
            {
                return Ok(await _gameService.UpdateGame(id, dateLastConnection));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame(int id)
        {
            var game = await _gameService.DeleteGame(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }
    }
}
