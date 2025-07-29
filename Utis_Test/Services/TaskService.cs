using System.Collections.Generic;
using Utis_Test.Interfaces;
using Utis_Test.Models;

namespace Utis_Test.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        public TaskModel? GetTaskById(int id)
        {
            return _taskRepository.GetTaskById(id);
        }

        public TaskModel AddTask(TaskModel task)
        {
            _taskRepository.AddTask(task);
            return task;
        }

        public TaskModel? UpdateTask(int id, TaskModel task)
        {
            var updatingTask = _taskRepository.UpdateTask(id, task);
            return updatingTask;
        }

        public void DeleteTask(int id)
        {
            _taskRepository.DeleteTask(id);
        }
    }
}
