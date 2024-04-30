using MasterFarmSolution.Entities;
using MasterFarmSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterFarmSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Animal>>> GetAllAnimal()
        {
            return Ok(await _animalService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            var animal = await _animalService.GetAnimal(id);
            if (animal == null)
            {
                return BadRequest("Animal not found");
            }
            return Ok(animal);
        }
        [HttpPost("{nameAnimal}/{plotId}")]
        public async Task<ActionResult<Animal>> CreateAnimal(string nameAnimal, int plotId)
        {
            var newAnimal = await _animalService.CreateAnimal(nameAnimal, plotId);
            return CreatedAtAction(nameof(GetAnimal), new { newAnimal.id }, newAnimal);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Animal>> UpdateAnimal(int id, string? nameAnimal = null, int? plotId = null)
        {
            try
            {
                return Ok(await _animalService.UpdateAnimal(id, nameAnimal, plotId));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Animal>> DeleteAnimal(int id)
        {
            var animal = await _animalService.DeleteAnimal(id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }
    }
}
