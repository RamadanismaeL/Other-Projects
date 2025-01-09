using ControleDeContactos.Models;
using ControleDeContactos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContactos.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase, IUserController
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        [HttpPost]
        public async Task<ActionResult<UserModel>> Add([FromBody] UserModel user)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                UserModel userModel  = await _userRepository.Add(user);
                return Ok(userModel);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured while adding user.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
            try
            {
                bool remove = await _userRepository.Delete(id);
                if (!remove) return NotFound($"User with ID {id} not found.");
                return NoContent();
            }
            catch(Exception error)
            {
                _logger.LogError(error, $"An error occured while deleting user with ID {id}.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> ListAll()
        {
            try
            {
                List<UserModel> users = await _userRepository.ListAll();
                if(users == null || !users.Any()) return NotFound("No users found.");
                return Ok(users);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured while retrieving users.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> ListByID(int id)
        {
            try
            {
                UserModel userID = await _userRepository.ListByID(id);
                if (userID == null) return NotFound($"User with ID {id} not found.");
                return Ok(userID);
            }
            catch(Exception error)
            {
                _logger.LogError(error, $"An error occured while retrieving user with ID {id}.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
        [HttpPut]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel user, int id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var existingUser = await _userRepository.ListByID(id);
                if (existingUser == null) return NotFound($"User with ID {id} not found.");
                user.Id = id;
                UserModel userModel = await _userRepository.Update(user, id);
                return Ok(userModel);
            }
            catch(Exception error)
            {
                _logger.LogError(error, $"An error occured while updating user with ID {id}.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}