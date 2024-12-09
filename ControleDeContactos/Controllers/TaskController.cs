using ControleDeContactos.Models;
using ControleDeContactos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContactos.Controllers
{
    /*
    *@author Ramadan ismaeL
    */
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase, ITaskController
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<TaskController> _logger;
        public TaskController(ITaskRepository taskRepository, ILogger<TaskController> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }
        [HttpPost]
        public async Task<ActionResult<TaskModel>> Add([FromBody] TaskModel task)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                TaskModel tasks = await _taskRepository.Add(task);
                return Ok(tasks);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured while adding task.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> Delete(int id)
        {
            try
            {
                bool remove = await _taskRepository.Delete(id);
                if(!remove) return NotFound($"Task with ID {id} not found.");
                return NoContent();
            }
            catch(Exception error)
            {
                _logger.LogError(error, $"An error occured while deleting task with ID {id}.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> ListAll()
        {
            try
            {
                List<TaskModel> tasks = await _taskRepository.ListAll();
                if(tasks == null || tasks.Count == 0) return NotFound("No tasks found.");
                return Ok(tasks);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured while retrieving tasks.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<TaskModel>> ListByID(int id)
        {
            try
            {
                TaskModel task = await _taskRepository.ListByID(id);
                if(task == null) return NotFound($"Task with ID {id} not found.");
                return Ok(task);
            }
            catch(Exception error)
            {
                _logger.LogError(error, $"An error occured while retrieving task with ID {id}.");
                return StatusCode(500, "Internal server error. Plase try again later.");            }
        }
        [HttpPut]
        public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel task, int id)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var check = await _taskRepository.ListByID(id);
                if(check == null) return NotFound($"Task with ID {id} not found.");
                task.Id = id;
                TaskModel tasks = await _taskRepository.Update(task, id);
                return Ok(tasks);
            }
            catch(Exception error)
            {
                _logger.LogError(error, $"An error occured while updating task with ID: {id}.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}