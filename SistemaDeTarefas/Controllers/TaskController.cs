using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Controllers
{
/*
*@author Ramadan ismaeL
*/
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskRepository itaskRepository;
        public TaskController(ITaskRepository itaskRepository)
        {
            this.itaskRepository = itaskRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> ListAll()
        {
            try
            {
                List<TaskModel> taks = await itaskRepository.ListAll();
                return Ok(taks);
            }
            catch(Exception error)
            {
                return StatusCode(500, "Internal server error: "+error.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> ListById(int id)
        {
            try
            {
                TaskModel taskById = await itaskRepository.ListById(id);
                return Ok(taskById);
            }
            catch(Exception error)
            {
                return StatusCode(500, "Internal server error: "+error.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<TaskModel>> Add([FromBody] TaskModel taskModel)
        {
            try
            {
                TaskModel task = await itaskRepository.Add(taskModel);
                return Ok(task);
            }
            catch(Exception error)
            {
                return StatusCode(500, "Internal server error: "+error.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel taskModel, int id)
        {
            try
            {
                taskModel.Id = id;
                TaskModel task = await itaskRepository.Update(taskModel, id);
                return Ok(task);
            }
            catch(Exception error)
            {
                return StatusCode(500, "Internal server error: "+error.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> Delete(int id)
        {
            try
            {
                bool remove = await itaskRepository.Delete(id);
                return Ok(remove);
            }
            catch(Exception error)
            {
                return StatusCode(500, "Internal server error: "+error.Message);
            }
        }
    }
}