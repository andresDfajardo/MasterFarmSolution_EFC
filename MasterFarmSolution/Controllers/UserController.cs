using MasterFarmSolution.Entities;
using MasterFarmSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterFarmSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            return Ok(await _userService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(user);
        }
        [HttpPost("{userName}/{password}/{farmerId}")]
        public async Task<ActionResult<User>> CreateUser(string userName, string password, int farmerId)
        {
            var newUser = await _userService.CreateUser(userName, password, farmerId);
            return CreatedAtAction(nameof(GetUser), new { newUser.id }, newUser);
        }
        [HttpPost("authenticate")]
        public async Task<ActionResult<User>> Authenticate([FromBody] User user)
        {
            var authenticatedUser = await _userService.Authenticate(user.userName, user.password);

            if (authenticatedUser == null)
            {
                return BadRequest(new { message = "Nombre de usuario o contraseña incorrectos" });
            }

            return Ok(authenticatedUser);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, string? userName = null, string? password = null, int? farmerId = null)
        {
            try
            {
                return Ok(await _userService.UpdateUser(id, userName, password, farmerId));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _userService.DeleteUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
