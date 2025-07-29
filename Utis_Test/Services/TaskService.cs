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

        public List<TaskModel> GetAllTasks()
        {
            return _taskRepository.GetAll();
        }

        public TaskModel? GetTaskById(int id)
        {
            return _taskRepository.GetById(id);
        }

        public int AddTask(TaskModel addingTask)
        {
            _taskRepository.Add(addingTask);
            return addingTask.Id;
        }

        public bool UpdateTask(int id, TaskModel newTask)
        {
            var updatingTask = _taskRepository.GetById(id);

            if (updatingTask != null)
            {
                updatingTask.UpdateProperties(newTask);
                _taskRepository.Update(updatingTask);
                return true;
            }

            return false;
        }

        public void DeleteTask(int id)
        {
            var deletingTask = _taskRepository.GetById(id);

            if (deletingTask != null)
            {
                _taskRepository.Delete(deletingTask);
            }
        }
    }
}
