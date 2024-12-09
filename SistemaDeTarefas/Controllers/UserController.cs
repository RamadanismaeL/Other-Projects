using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SistemaDeTarefas.Controllers
{
/*
*@author Ramadan ismaeL
*/
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository iuserRepository;
        public UserController(IUserRepository iuserRepository)
        {
            this.iuserRepository = iuserRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> ListAll()
        {
            try
            {
                List<UserModel> users = await iuserRepository.ListAll();
                return Ok(users);
            }
            catch (Exception error)
            {
                return StatusCode(500, "Internal server error: " + error.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> ListById(int id)
        {
            try
            {
                UserModel userById = await iuserRepository.ListById(id);
                return Ok(userById);
            }
            catch (Exception error)
            {
                return StatusCode(500, "Internal server error: "+error.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<UserModel>> Add([FromBody] UserModel userModel)
        {
            try
            {
                UserModel user = await iuserRepository.Add(userModel);
                return Ok(user);
            }
            catch(Exception error)
            {
                return StatusCode(500, "Internal server error: "+error.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
        {
            try
            {
                userModel.Id = id;
                UserModel user = await iuserRepository.Update(userModel, id);
                return Ok(user);
            }
            catch(Exception error)
            {
                return StatusCode(500, "Internal server error: "+ error.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
            bool remove = await iuserRepository.Delete(id);
            return Ok(remove);
        }
    }
}