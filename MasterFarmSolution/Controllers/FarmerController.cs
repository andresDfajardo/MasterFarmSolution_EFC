using MasterFarmSolution.Entities;
using MasterFarmSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterFarmSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private readonly IFarmerService _farmerService;
        public FarmerController(IFarmerService farmerService)
        {
            _farmerService = farmerService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Farmer>>> GetAllFarmer()
        {
            return Ok(await _farmerService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Farmer>> GetFarmer(int id)
        {
            var farmer = await _farmerService.GetFarmer(id);
            if (farmer == null)
            {
                return BadRequest("Farmer not found");
            }
            return Ok(farmer);
        }
        [HttpPost("{firstNameFarmer}/{lastNameFarmer}/{emailFarmer}/{phoneFarmer}/{addressFarmer}")]
        public async Task<ActionResult<Farmer>> CreateFarmer(string firstNameFarmer, string lastNameFarmer, string emailFarmer, string phoneFarmer, string addressFarmer)
        {
            var newFarmer = await _farmerService.CreateFarmer(firstNameFarmer, lastNameFarmer, emailFarmer, phoneFarmer, addressFarmer);
            return CreatedAtAction(nameof(GetFarmer), new { newFarmer.id }, newFarmer);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Farmer>> UpdateFarmer(int id, string? firstNameFarmer = null, string? lastNameFarmer = null, string? emailFarmer = null, string? phoneFarmer = null, string? addressFarmer = null)
        {
            try
            {
                return Ok(await _farmerService.UpdateFarmer(id, firstNameFarmer, lastNameFarmer, emailFarmer, phoneFarmer, addressFarmer));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Farmer>> DeleteFarmer(int id)
        {
            var farmer = await _farmerService.DeleteFarmer(id);
            if (farmer == null)
            {
                return NotFound();
            }
            return Ok(farmer);
        }
    }
}
