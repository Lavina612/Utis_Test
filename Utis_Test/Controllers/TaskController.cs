using Microsoft.AspNetCore.Mvc;
using Utis_Test.Interfaces;
using Utis_Test.Models;

namespace Utis_Test.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("filter")]
        public IActionResult GetTasksByStatus([FromQuery] string status)
        {
            var tasks = _taskService.GetTasksByStatus(status);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _taskService.GetTaskById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public IActionResult AddTask([FromBody] TaskModel task)
        {
            task.Id = _taskService.AddTask(task);

            return CreatedAtAction(nameof(AddTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskModel task)
        {
            return _taskService.UpdateTask(id, task)
                ? Ok() 
                : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}
