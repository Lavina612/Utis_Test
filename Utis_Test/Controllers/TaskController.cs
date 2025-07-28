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
            var addedTask = _taskService.AddTask(task);

            return CreatedAtAction(nameof(GetTaskById), new { id = addedTask.Id }, addedTask);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskModel task)
        {
            var updatedTask = _taskService.UpdateTask(id, task);

            if (updatedTask == null)
            {
                return NotFound();
            }

            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}
