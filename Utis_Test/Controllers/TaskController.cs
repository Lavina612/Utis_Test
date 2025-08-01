using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Utis_Test.Interfaces;
using Utis_Test.Models;

namespace Utis_Test.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        private readonly ILogger<TaskController> _logger;

        public TaskController(ITaskService taskService, ILogger<TaskController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllTasks([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()}: Received GET request with params page = {page}, pageSize = {pageSize}.");

            var tasks = _taskService.GetAllTasks(page, pageSize);
            return Ok(tasks);
        }

        [HttpGet("filter")]
        public IActionResult GetTasksByStatus([FromQuery] string status, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()}: Received GET /filter request with params status = {status}, page = {page}, pageSize = {pageSize}.");


            var tasks = _taskService.GetTasksByStatus(status, page, pageSize);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()}: Received GET /<id> request.");


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
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()}: Received POST request with Task: {task}.");


            task.Id = _taskService.AddTask(task);

            return task.Id == 0
                ? BadRequest()
                : CreatedAtAction(nameof(AddTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskModel task)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()}: Received PUT request on update task with id = {id} and new properties: {task}.");


            return _taskService.UpdateTask(id, task)
                ? Ok() 
                : BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow.ToLongTimeString()}: Received DELETE request with id = {id}.");


            _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}
