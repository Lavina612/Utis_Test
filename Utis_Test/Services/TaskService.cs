using System.Collections.Generic;
using Utis_Test.Interfaces;
using Utis_Test.Models;

namespace Utis_Test.Services
{
    public class TaskService : ITaskService
    {
        private readonly IAppDbContext _context;

        public TaskService(IAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            return _context.GetAllTasks();
        }

        public TaskModel? GetTaskById(int id)
        {
            return _context.GetTaskById(id);
        }

        public TaskModel AddTask(TaskModel task)
        {
            _context.AddTask(task);
            return task;
        }

        public TaskModel? UpdateTask(int id, TaskModel task)
        {
            var updatingTask = _context.UpdateTask(id, task);
            return updatingTask;
        }

        public void DeleteTask(int id)
        {
            _context.DeleteTask(id);
        }
    }
}
